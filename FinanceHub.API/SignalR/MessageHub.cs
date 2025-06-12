using AutoMapper;
using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Features.MessageFeatures.Commands.CreateMessageCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Extensions;
using FinanceHub.SignalR.Pag;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Hub = Microsoft.AspNetCore.SignalR.Hub;

namespace FinanceHub.SignalR;

public class MessageHub(IMessageRepository messageRepository, IMediator mediator, IMapper mapper,  PresenceTracker tracker, IHubContext<PresenceHub> presenceHubContext) : Hub
{
    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var otherUser = httpContext?.Request.Query["user"];

        if (Context.User == null || string.IsNullOrEmpty(otherUser))
            throw new Exception("Cannot join group");

        var currentUserEmail = Context.User.GetEmail();
        var sender = await mediator.Send(new GetByEmailUserQuery(currentUserEmail));
        var groupName = GetGroupName(sender.UserName!, otherUser);

        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        await AddToGroup(groupName);

        Context.Items["group"] = groupName;
    }

    public async Task LoadMessageThread(MessageThreadParams messageParams, string recipientUsername)
    {
        if (Context.User == null || string.IsNullOrEmpty(recipientUsername))
        {
            throw new HubException("Недостатньо даних для завантаження повідомлень.");
        }

        var currentUserEmail = Context.User.GetEmail();

        var sender = await mediator.Send(new GetByEmailUserQuery(currentUserEmail));

        if (sender.UserName != null)
        {
            var messagesPagedList =
                await messageRepository.GetMessageThread(sender.UserName, recipientUsername, messageParams);

            var resultForClient = new PaginatedResultSig<MessageDto>
            {
                // Конвертуємо PagedList в звичайний List для властивості Items
                Items = messagesPagedList.ToList(),
                // Створюємо об'єкт з метаданими пагінації
                Pagination = new PaginationHeaderSig(
                    messagesPagedList.CurrentPage,
                    messagesPagedList.PageSize,
                    messagesPagedList.TotalCount,
                    messagesPagedList.TotalPages
                )
            };

            // var groupName = GetGroupName(currentUserEmail, recipientUsername);
            // await Clients.Group(groupName).SendAsync("ReceivedMessageThread", messages);
            await Clients.Caller.SendAsync("ReceivedMessageThread", resultForClient);
        }
    }

    public async Task SendMessage(CreateMessageDto createMessageDto)
    {
        var currentUserEmail = Context.User.GetEmail();

        if (currentUserEmail.ToLower() == createMessageDto.RecipientUsername.ToLower())
        {
            throw new HubException("Ви не можете надсилати повідомлення самому собі");
        }

        var sender = await mediator.Send(new GetByEmailUserQuery(currentUserEmail));
        var recipient = await mediator.Send(new GetByUsernameUserQuery(createMessageDto.RecipientUsername));

        if (sender == null || recipient == null || sender.UserName == null || recipient.UserName == null)
            throw new Exception("Cannot sent message at this time");

        var message = new Message
        {
            Sender = sender,
            Recipient = recipient,
            SenderUserName = sender.UserName,
            RecipientUserName = recipient.UserName,
            Content = createMessageDto.Content,
            MessageSent = DateTime.UtcNow
        };

        var groupName = GetGroupName(sender.UserName, recipient.UserName);
        var group = await messageRepository.GetMessageGroup(groupName);

        if (group != null && group.Collections.Any(x => x.Username == recipient.UserName))
        {
            message.DateRead = DateTime.UtcNow;
        }
        
        await mediator.Send(new CreateMessageCommand(message));

        await Clients.Group(groupName).SendAsync("NewMessage", mapper.Map<MessageDto>(message));
        
        // Знаходимо connectionId отримувача, якщо він онлайн
        var recipientConnections = await tracker.GetConnectionsForUser(recipient.Email!); // Використовуємо Email, як у PresenceHub
        if (recipientConnections != null && recipientConnections.Any())
        {
            // Рахуємо кількість непрочитаних повідомлень від цього відправника для отримувача
            var unreadCount = await messageRepository.GetUnreadMessagesCountForUser(recipient.UserName, sender.UserName);

            // Надсилаємо сповіщення ТІЛЬКИ отримувачу через його підключення до PresenceHub
            await presenceHubContext.Clients.Clients(recipientConnections).SendAsync("NewMessageReceived", new 
            {
                senderUsername = sender.UserName,
                unreadCount = unreadCount,
                lastMessageSent = message.MessageSent
            });
        }
    }

    private async Task<bool> AddToGroup(string groupName)
    {
        var currentUserEmail = Context.User.GetEmail();
        var sender = await mediator.Send(new GetByEmailUserQuery(currentUserEmail));

        var username = sender.UserName ?? throw new Exception("Cannot get the user");

        var group = await messageRepository.GetMessageGroup(groupName);
        var connection = new Connection { ConnectionId = Context.ConnectionId, Username = username };

        if (group == null)
        {
            group = new Group { Name = groupName };
            messageRepository.AddGroup(group);
        }
        
        group.Collections.Add(connection);
        return await messageRepository.SaveAllAsync();
    }

    private async Task RemoveFromMessageGroup()
    {
        var connection = await messageRepository.GetConnection(Context.ConnectionId);
        if (connection != null)
        {
            messageRepository.RemoveConnection(connection);
            await messageRepository.SaveAllAsync();
        }
    }


    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await RemoveFromMessageGroup();
        if (Context.Items["group"] is string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        await base.OnDisconnectedAsync(exception);
    }

    private string GetGroupName(string caller, string? other)
    {
        var stringCompare = string.CompareOrdinal(caller, other) < 0;
        return stringCompare ? $"{caller}-{other}" : $"{other}-{caller}";
    }
    
    public async Task AcknowledgeMessagesRead(List<string> messageIds)
    {
        if (Context.User == null || !messageIds.Any()) return;

        // Оновлюємо всі повідомлення в базі даних за отриманими ID
        await messageRepository.MarkMessagesAsReadByIds(messageIds);
        await messageRepository.SaveAllAsync();

        // Отримуємо групу, щоб знайти іншого учасника
        if (Context.Items["group"] is string groupName)
        {
            // ✅ КЛЮЧОВЕ РІШЕННЯ:
            // Надсилаємо подію "MessagesWereReadByPeer" (Повідомлення прочитані співрозмовником)
            // тільки ІНШИМ учасникам групи. Той, хто прочитав, і так оновить свій UI.
            await Clients.OthersInGroup(groupName).SendAsync("MessagesWereReadByPeer", messageIds);
        }
    }
}
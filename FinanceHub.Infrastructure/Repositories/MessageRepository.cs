using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class MessageRepository(FinHubDbContext context, IMapper mapper)
    : GenericRepository<Message>(context), IMessageRepository
{
    
    public async Task<int> GetUnreadMessagesCountForUser(string recipientUsername, string senderUsername)
    {
        // Запитуємо з таблиці повідомлень
        var unreadCount = await _dbSet
            .Where(m => 
                m.RecipientUserName == recipientUsername && // 1. Повідомлення адресоване цьому користувачу
                m.SenderUserName == senderUsername &&    // 2. Повідомлення надійшло від конкретного відправника
                m.DateRead == null)                      // 3. Повідомлення не прочитане
            .CountAsync(); // Асинхронно рахуємо кількість записів, що відповідають умові

        return unreadCount;
    }
    
    public async Task<int> GetUnreadMessagesCountAsync(string username)
    {
        return await _dbSet
            .Where(m => m.RecipientUserName == username && m.DateRead == null && !m.RecipientDeleted)
            .CountAsync();
    }

    public async Task MarkMessagesAsReadByIds(IEnumerable<string> messageIds)
    {
        var idsToUpdate = messageIds.Select(id => Guid.Parse(id)).ToList();

        var messages = await _dbSet
            .Where(m => idsToUpdate.Contains(m.Id) && m.DateRead == null)
            .ToListAsync();

        if (messages.Any())
        {
            foreach (var message in messages)
            {
                message.DateRead = DateTime.UtcNow;
            }
        }
        // Збереження буде викликано в хабі
    }

    public async Task<IEnumerable<ChatUserDto>> GetLatestMessagesPerChatUserAsync(string currentUsername, string currentEmail)
    {
        var messages = _dbSet
            .Include(m => m.Sender)
            .Include(m => m.Recipient)
            .Where(m => m.SenderUserName == currentUsername || m.RecipientUserName == currentUsername);

        var grouped = messages
            .GroupBy(m => m.SenderUserName == currentUsername ? m.RecipientUserName : m.SenderUserName)
            .Select(g => new
            {
                ChatUser = g.Key,
                LastMessage = g.OrderByDescending(m => m.MessageSent).FirstOrDefault(),
                UnreadCount = g.Count(m => m.RecipientUserName == currentUsername && m.DateRead == null)
            });

        var result = await grouped.ToListAsync();

        // Мапінг вручну або через AutoMapper з передачою додаткових параметрів
        var chatUserDtos = result.Select(r =>
        {
            var dto = mapper.Map<Message, ChatUserDto>(r.LastMessage, opts =>
            {
                opts.Items["currentUsername"] = currentUsername;
                opts.Items["currentEmail"] = currentEmail;
            });

            dto.UnreadCount = r.UnreadCount;

            return dto;
        });

        return chatUserDtos;
    }

    public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
    {
        var query = _dbSet.OrderByDescending(x => x.MessageSent).AsQueryable();

        query = messageParams.Container switch
        {
            "Inbox" => query.Where(x => x.RecipientUserName == messageParams.Username && x.RecipientDeleted == false),
            "Outbox" => query.Where(x => x.SenderUserName == messageParams.Username && x.SenderDeleted == false),
            _ => query.Where(x =>
                x.RecipientUserName == messageParams.Username && x.DateRead == null && x.RecipientDeleted == false)
        };

        var messages = query.ProjectTo<MessageDto>(mapper.ConfigurationProvider);

        return await PagedList<MessageDto>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
    }

    public async Task<PagedList<MessageDto>> GetMessageThread(string currentUsername, string recipientUsername,
        MessageThreadParams messageThreadParams)
    {
        var recipientExists = await context.Users.AnyAsync(u => u.UserName == recipientUsername);
        if (!recipientExists)
        {
            // повертаємо порожній список або кидаємо 404
            return PagedList<MessageDto>.CreateEmpty();
        }

        var query = _dbSet
            .Include(x => x.Sender)
            .Include(x => x.Recipient)
            .Where(x =>
                (x.RecipientUserName == currentUsername && !x.RecipientDeleted &&
                 x.SenderUserName == recipientUsername) ||
                (x.SenderUserName == currentUsername && !x.SenderDeleted && x.RecipientUserName == recipientUsername))
            .OrderByDescending(x => x.MessageSent)
            .AsQueryable();

        // Mark unread messages as read
        //   var unreadMessages = await query
        //     .Where(x => x.DateRead == null && x.RecipientUserName == currentUsername)
        //     .ToListAsync();
        //
        // if (unreadMessages.Any())
        // {
        //     unreadMessages.ForEach(x => x.DateRead = DateTime.UtcNow);
        //     await context.SaveChangesAsync();
        // }

        var projected = query.ProjectTo<MessageDto>(mapper.ConfigurationProvider);

        return await PagedList<MessageDto>.CreateAsync(projected, messageThreadParams.PageNumber,
            messageThreadParams.PageSize);
    }

    public void AddGroup(Group group)
    {
        context.Groups.Add(group);
    }

    public void RemoveConnection(Connection connection)
    {
        context.Connections.Remove(connection);
    }

    public async Task<Connection?> GetConnection(string connectionId)
    {
        return await context.Connections.FindAsync(connectionId);
    }

    public async Task<Group?> GetMessageGroup(string groupName)
    {
        return await context.Groups.Include(x => x.Collections).FirstOrDefaultAsync(x => x.Name == groupName);
    }

    // public async Task MarkMessagesAsRead(string currentUsername, string senderUsername)
    // {
    //     var unreadMessages = await _dbSet
    //         .Where(x =>
    //             x.DateRead == null &&
    //             x.RecipientUserName == currentUsername &&
    //             x.SenderUserName == senderUsername)
    //         .ToListAsync();
    //
    //     if (unreadMessages.Any())
    //     {
    //         unreadMessages.ForEach(x => x.DateRead = DateTime.UtcNow);
    //         await context.SaveChangesAsync();
    //     }
    // }

    // Сигнатура методу тепер повертає Task<IEnumerable<Message>>
    public async Task<IEnumerable<Message>> MarkMessagesAsRead(string currentUsername, string senderUsername)
    {
        var unreadMessages = await _dbSet
            .Where(x =>
                x.DateRead == null &&
                x.RecipientUserName == currentUsername &&
                x.SenderUserName == senderUsername)
            .ToListAsync();

        if (unreadMessages.Any())
        {
            // Логіка оновлення дати залишається такою ж
            unreadMessages.ForEach(x => x.DateRead = DateTime.UtcNow);

            // ❌ Прибираємо збереження звідси. Хаб зробить це сам.
            // await context.SaveChangesAsync(); 
        }

        // ✅ Повертаємо список повідомлень, які були оновлені.
        // Якщо нічого не було знайдено, повернеться пустий список.
        return unreadMessages;
    }
}
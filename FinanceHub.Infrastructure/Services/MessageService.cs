using AutoMapper;
using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Features.MessageFeatures.Commands.CreateMessageCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class MessageService(IMediator mediator, IMapper mapper) : IMessageService
{
    public async Task<MessageDto> CreateMessage(CreateMessageDto createMessageDto)
    {
        var sender = await mediator.Send(new GetByUsernameUserQuery(createMessageDto.SenderUsername));
        var recipient = await mediator.Send(new GetByUsernameUserQuery(createMessageDto.RecipientUsername));
        
        if(sender == null || recipient == null) throw new Exception("Cannot sent message at this time");

        var message = new Message
        {
            Sender = sender,
            Recipient = recipient,
            SenderUserName = sender.Username,
            RecipientUserName = recipient.Username,
            Content = createMessageDto.Content,
            MessageSent = DateTime.UtcNow
        };

        await mediator.Send(new CreateMessageCommand(message));
        
        return mapper.Map<MessageDto>(message);
    }
}
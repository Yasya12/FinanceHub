using AutoMapper;
using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Features.MessageFeatures.Commands.CreateMessageCommand;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceHub.Infrastructure.Services;

public class MessageService(IMediator mediator, IMapper mapper) : IMessageService
{
    public async Task<MessageDto> CreateMessage(CreateMessageDto createMessageDto, string senderEmail)
    {
        var sender = await mediator.Send(new GetByEmailUserQuery(senderEmail));
        var recipient = await mediator.Send(new GetByUsernameUserQuery(createMessageDto.RecipientUsername));
        
        if(sender == null || recipient == null || sender.UserName == null || recipient.UserName == null) throw new Exception("Cannot sent message at this time");

        var message = new Message
        {
            Sender = sender,
            Recipient = recipient,
            SenderUserName = sender.UserName,
            RecipientUserName = recipient.UserName,
            Content = createMessageDto.Content,
            MessageSent = DateTime.UtcNow
        };

        await mediator.Send(new CreateMessageCommand(message));
        
        return mapper.Map<MessageDto>(message);
    }
}
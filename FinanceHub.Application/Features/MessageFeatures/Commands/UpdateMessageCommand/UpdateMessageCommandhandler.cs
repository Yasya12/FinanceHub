using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Commands.UpdateMessageCommand;

public class UpdateMessageCommandhandler(IMessageRepository messageRepository)
    : IRequestHandler<UpdateMessageCommand, Message>
{
    private readonly IMessageRepository _messageRepository = messageRepository;

    public async Task<Message> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        await _messageRepository.UpdateAsync(request.Message);
        return request.Message;
    }
}
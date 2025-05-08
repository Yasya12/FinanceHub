using FinanceGub.Application.Interfaces.Repositories;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Commands.DeleteMessageCommand;

public class DeleteMessageCommandHandler(IMessageRepository messageRepository)
    : IRequestHandler<DeleteMessageCommand, string>
{
    private readonly IMessageRepository _messageRepository = messageRepository;

    public async Task<string> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        return await _messageRepository.DeleteAsync(request.Id);
    }
}
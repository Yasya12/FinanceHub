using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Queries.GetMessageById;

public class GetMessageByIdHandler(IMessageRepository messageRepository) : IRequestHandler<GetMessageById, Message>
{
    public async Task<Message> Handle(GetMessageById request, CancellationToken cancellationToken)
    {
        return await messageRepository.GetByIdAsync(request.Id);
    }
}
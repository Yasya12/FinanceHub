using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Repositories;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Queries.GetMessagesForUser;

public class GetMessagesForUserHandler: IRequestHandler<GetMessagesForUser, PagedList<MessageDto>>
{
    private readonly IMessageRepository _messageRepository;

    public GetMessagesForUserHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<PagedList<MessageDto>> Handle(GetMessagesForUser request, CancellationToken cancellationToken)
    {
        return await _messageRepository.GetMessagesForUser(request.MessageParams);
    }
}
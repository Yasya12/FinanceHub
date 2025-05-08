using FinanceGub.Application.DTOs.Message;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Repositories;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Queries.GetMessageThread;

public class GetMessageThreadHandler: IRequestHandler<GetMessageThread, PagedList<MessageDto>>
{
    private readonly IMessageRepository _messageRepository;

    public GetMessageThreadHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    
    public async Task<PagedList<MessageDto>> Handle(GetMessageThread request, CancellationToken cancellationToken)
    {
        return await _messageRepository.GetMessageThread(request.CurrentUsername, request.RecipientUsername, request.MessageThreadParams);
    }
}
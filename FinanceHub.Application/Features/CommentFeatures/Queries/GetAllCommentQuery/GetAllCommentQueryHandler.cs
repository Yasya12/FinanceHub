using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Queries.GetAllCommentQuery;

public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, IEnumerable<Comment>>
{
    private readonly ICommentRepository _commentRepository;

    public GetAllCommentQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<IEnumerable<Comment>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
    {
        return await _commentRepository.GetAllAsync(request.IncludeProperties);
    }
}
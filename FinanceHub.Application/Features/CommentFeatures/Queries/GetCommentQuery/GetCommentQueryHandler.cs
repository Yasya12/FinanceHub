using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.CommentFeatures.Queries.GetCommentQuery;

public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, Comment>
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public Task<Comment> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        return _commentRepository.GetByIdAsync(request.Id, request.IncludeProperties);
    }
}
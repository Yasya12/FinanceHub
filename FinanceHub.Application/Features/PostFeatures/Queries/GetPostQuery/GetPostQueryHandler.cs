using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Queries.GetPostQuery;

public class GetPostQueryHandler : IRequestHandler<GetPostQuery, Post>
{
    private readonly IPostRepository _postRepository;

    public GetPostQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    public async Task<Post> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetByIdAsync(request.Id, request.IncludeProperties);
    }
}
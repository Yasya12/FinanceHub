using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Queries.GetAllPostQuery;

public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, IEnumerable<Post>>
{
    private readonly IPostRepository _postRepository;

    public GetAllPostQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<Post>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {
        return await _postRepository.GetAllAsync(request.IncludeProperties);
    }
}
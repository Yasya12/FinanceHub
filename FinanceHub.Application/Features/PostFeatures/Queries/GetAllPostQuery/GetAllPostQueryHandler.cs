using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.PostFeatures.Queries.GetAllPostQuery;

public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, IQueryable<Post>>
{
    private readonly IPostRepository _postRepository;

    public GetAllPostQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public Task<IQueryable<Post>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {
        var query =  _postRepository.GetAllAsQueryable(request.IncludeProperties);
        return Task.FromResult(query);
    }
}
using FinanceGub.Application.Interfaces.Repositories;
using MediatR;

namespace FinanceGub.Application.Features.LikeFeatures.Queries.GetLikesCountQuery;

public class GetLikesCountQueryHandler : IRequestHandler<GetLikesCountQuery, int>
{
    private readonly ILikeRepository _likeRepository;

    public GetLikesCountQueryHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<int> Handle(GetLikesCountQuery request, CancellationToken cancellationToken)
    {
        return await _likeRepository.GetLikesCountAsync(request.PostId);
    }
}
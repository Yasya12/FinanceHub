using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.LikeFeatures.Queries.GetSingleLikeQuery;

public class GetSingleLikeQueryHandler: IRequestHandler<GetSingleLikeQuery, Like>
{
    private readonly ILikeRepository _likeRepository;

    public GetSingleLikeQueryHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<Like> Handle(GetSingleLikeQuery request, CancellationToken cancellationToken)
    {
        return await _likeRepository.GetLikeByPostAndUserAsync(request.PostId, request.UserId);
    }
}
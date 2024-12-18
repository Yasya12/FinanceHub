using MediatR;

namespace FinanceGub.Application.Features.LikeFeatures.Queries.GetLikesCountQuery;

public record GetLikesCountQuery(Guid PostId): IRequest<int>;
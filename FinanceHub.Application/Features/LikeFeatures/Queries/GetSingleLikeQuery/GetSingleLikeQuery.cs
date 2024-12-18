using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.LikeFeatures.Queries.GetSingleLikeQuery;

public record GetSingleLikeQuery(Guid PostId, Guid UserId) : IRequest<Like>;
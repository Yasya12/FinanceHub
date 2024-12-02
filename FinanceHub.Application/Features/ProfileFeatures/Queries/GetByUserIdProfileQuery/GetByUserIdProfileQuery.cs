using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Queries.GetByUserIdProfileQuery;

public record GetByUserIdProfileQuery(Guid UserId) : IRequest<Profile>;
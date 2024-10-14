using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Queries.GetAllProfileQuery;

public record GetAllProfileQuery(string? IncludeProperties = null) : IRequest<IEnumerable<Profile>>;
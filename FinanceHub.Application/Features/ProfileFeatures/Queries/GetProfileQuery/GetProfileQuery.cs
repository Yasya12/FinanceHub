using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Queries.GetProfileQuery;

public record GetProfileQuery(Guid Id, string? IncludeProperties = null) : IRequest<Profile>;
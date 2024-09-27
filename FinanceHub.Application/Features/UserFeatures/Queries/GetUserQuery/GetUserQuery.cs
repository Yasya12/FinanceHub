using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetUserQuery;

public record GetUserQuery (Guid Id, string? IncludeProperties = null) : IRequest<User> { } 
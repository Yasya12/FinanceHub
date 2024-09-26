using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries;

public record GetUserQuery(string? IncludeProperties = null) : IRequest<IEnumerable<FinanceHub.Core.Entities.User>> { }
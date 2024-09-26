using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetAllUserQuery;

public record GetAllUserQuery(string? IncludeProperties = null) : IRequest<IEnumerable<FinanceHub.Core.Entities.User>> { }
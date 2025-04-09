using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;

public record GetByUsernameUserQuery(string Username) : IRequest<User>;
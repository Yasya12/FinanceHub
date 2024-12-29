using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetUserByCredentialsQuery;

public record GetUserByCredentialsQuery(string Email, string Password): IRequest<User>;
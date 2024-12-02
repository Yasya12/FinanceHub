using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;

public record GetByEmailUserQuery(string Email) : IRequest<User>;
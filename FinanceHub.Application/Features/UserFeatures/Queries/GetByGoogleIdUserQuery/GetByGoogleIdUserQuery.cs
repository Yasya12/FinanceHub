using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Queries.GetByGoogleIdUserQuery;

public record GetByGoogleIdUserQuery(string GoogleId) : IRequest<User>;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.UpdateUserCommand;

public record UpdateUserCommand(User User) : IRequest<User> { }
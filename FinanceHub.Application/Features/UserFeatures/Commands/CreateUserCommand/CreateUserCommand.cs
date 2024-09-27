using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.CreateUserCommand;

public record CreateUserCommand (User user) : IRequest<User> { }
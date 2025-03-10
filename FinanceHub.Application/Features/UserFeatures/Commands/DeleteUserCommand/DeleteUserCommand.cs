using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.DeleteUserCommand;

public record DeleteUserCommand (Guid Id) : IRequest<string> { }
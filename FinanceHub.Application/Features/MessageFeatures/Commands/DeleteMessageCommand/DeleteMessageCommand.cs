using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Commands.DeleteMessageCommand;

public record DeleteMessageCommand(Guid Id) : IRequest<string>;
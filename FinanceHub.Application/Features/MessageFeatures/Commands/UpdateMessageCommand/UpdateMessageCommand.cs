using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Commands.UpdateMessageCommand;

public record UpdateMessageCommand(Message Message) : IRequest<Message>;
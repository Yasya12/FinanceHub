using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.MessageFeatures.Commands.CreateMessageCommand;

public record CreateMessageCommand(Message Message) : IRequest<Message>;
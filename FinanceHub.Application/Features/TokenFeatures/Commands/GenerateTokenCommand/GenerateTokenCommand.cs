using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.TokenFeatures.Commands.GenerateTokenCommand;

public record GenerateTokenCommand(User User) : IRequest<string>;
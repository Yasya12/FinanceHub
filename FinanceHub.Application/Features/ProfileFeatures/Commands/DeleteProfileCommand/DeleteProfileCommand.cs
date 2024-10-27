using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Commands.DeleteProfileCommand;

public record DeleteProfileCommand(Guid Id) : IRequest<string>;
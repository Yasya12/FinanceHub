using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Commands.UpdateProfileCommand;

public record UpdateProfileCommand(Profile Profile) : IRequest<Profile>;
using FinanceHub.Core.Entities;
using MediatR;

namespace FinanceGub.Application.Features.ProfileFeatures.Commands.CreateProfileCommand;

public record CreateProfileCommand(Profile Profile) : IRequest<Profile>;
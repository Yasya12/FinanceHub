using FinanceHub.Core.Entities;
using Google.Apis.Auth;
using MediatR;

namespace FinanceGub.Application.Features.UserFeatures.Commands.CreateUserFromGoogleCommand;

public record CreateUserFromGoogleCommand(GoogleJsonWebSignature.Payload Payload): IRequest<User>;
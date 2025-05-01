using MediatR;
using Microsoft.AspNetCore.Http;

namespace FinanceGub.Application.Features.PhotoFeatures.Commands.CreateUserPhotoCommand;

public record CreateUserPhotoCommand(IFormFile File) : IRequest<string>;
using MediatR;

namespace FinanceGub.Application.Features.PhotoFeatures.Commands.DeletePhotoCommand;

public record DeletePhotoCommand(string ImageUrl) : IRequest<Unit>;
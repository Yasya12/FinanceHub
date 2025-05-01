using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;

namespace FinanceGub.Application.Features.PhotoFeatures.Commands.DeletePhotoCommand;

public class DeletePhotoCommandHandler(IAzureBlobStorageService azureBlobStorageService)
    : IRequestHandler<DeletePhotoCommand, Unit>
{
    public async Task<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
    {
        await azureBlobStorageService.DeletePhotoAsync(request.ImageUrl);
        return Unit.Value;
    }
}
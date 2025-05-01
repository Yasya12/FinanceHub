using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;

namespace FinanceGub.Application.Features.PhotoFeatures.Commands.CreateUserPhotoCommand;

public class CreateUserPhotoCommandHandler(IAzureBlobStorageService azureBlobStorageService)
    : IRequestHandler<CreateUserPhotoCommand, string>
{

    public async Task<string> Handle(CreateUserPhotoCommand request, CancellationToken cancellationToken)
    {
        return await azureBlobStorageService.AddUserPhotoAsync(request.File);
    }
}
using Microsoft.AspNetCore.Http;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IAzureBlobStorageService
{
    Task<string> UploadProfilePictureAsync(IFormFile file);
    Task<string> UploadPostImageAsync(IFormFile file);
    Task DeleteBlobAsync(string imageUrl);
}
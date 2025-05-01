using Microsoft.AspNetCore.Http;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IAzureBlobStorageService
{
    Task<string> AddUserPhotoAsync(IFormFile file);
    Task<string> AddPostPhotoAsync(IFormFile file);
    Task DeletePhotoAsync(string imageUrl);
}
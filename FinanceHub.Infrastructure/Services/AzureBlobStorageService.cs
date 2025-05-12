using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FinanceGub.Application.Interfaces.Serviсes;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace FinanceHub.Infrastructure.Services;

public class AzureBlobStorageService(string connectionString, string containerName) : IAzureBlobStorageService
{
    public async Task<string> AddUserPhotoAsync(IFormFile file)
    {
        // Створюємо екземпляр BlobServiceClient
        var blobServiceClient = new BlobServiceClient(connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        
        // Створюємо контейнер, якщо він не існує
        await blobContainerClient.CreateIfNotExistsAsync();

        // Генеруємо унікальне ім'я для файлу
        var fileName = "userProfile/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        // Завантажуємо файл в Blob Storage
        using (var stream = file.OpenReadStream())
        {
            using var image = await Image.LoadAsync(stream);

            // 🖼️ Ресайз до макс. 300px по ширині або висоті, зберігаючи пропорції
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Mode = ResizeMode.Max,
                Size = new Size(300, 300)
            }));

            // Зберігаємо у MemoryStream перед завантаженням
            using var outputStream = new MemoryStream();
            await image.SaveAsJpegAsync(outputStream, new JpegEncoder { Quality = 85 });
            outputStream.Position = 0;
            
            await blobClient.UploadAsync(outputStream, new BlobHttpHeaders { ContentType = file.ContentType });
        }

        // Повертаємо URL завантаженого зображення
        return blobClient.Uri.ToString();
    }
    
    public async Task<string> AddPostPhotoAsync(IFormFile file)
    {
        var blobServiceClient = new BlobServiceClient(connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
    
        await blobContainerClient.CreateIfNotExistsAsync(); // Create container if not exists

        var fileName = "posts/" + Guid.NewGuid() + Path.GetExtension(file.FileName); // Store in "posts/" folder
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
        }

        return blobClient.Uri.ToString(); // Return image URL 
    }
    
    public async Task<string> AddMainHubPhotoAsync(IFormFile file)
    {
        var blobServiceClient = new BlobServiceClient(connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
    
        await blobContainerClient.CreateIfNotExistsAsync(); // Create container if not exists

        var fileName = "hubs/mainPhotos/" + Guid.NewGuid() + Path.GetExtension(file.FileName); // Store in "posts/" folder
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
        }

        return blobClient.Uri.ToString(); // Return image URL 
    }
    
    public async Task<string> AddBackHubPhotoAsync(IFormFile file)
    {
        var blobServiceClient = new BlobServiceClient(connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
    
        await blobContainerClient.CreateIfNotExistsAsync(); // Create container if not exists

        var fileName = "hubs/backPhotos/" + Guid.NewGuid() + Path.GetExtension(file.FileName); // Store in "posts/" folder
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
        }

        return blobClient.Uri.ToString(); // Return image URL 
    }

    public async Task DeletePhotoAsync(string imageUrl)
    {
        var blobServiceClient = new BlobServiceClient(connectionString);
        // Отримайте контейнер, в якому зберігаються зображення
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);

        // Отримайте ім'я блоба з URL
        var blobName = GetBlobNameFromUrl(imageUrl);

        // Отримайте блоб-клієнт
        var blobClient = blobContainerClient.GetBlobClient(blobName);

        // Видалення блоба
        await blobClient.DeleteIfExistsAsync();
    }
    private string GetBlobNameFromUrl(string imageUrl)
    {
        var uri = new Uri(imageUrl);
        var segments = uri.Segments.Skip(2); // Skip `/` and `container/`
        var blobName = string.Join("", segments);
        return blobName;
    }

}
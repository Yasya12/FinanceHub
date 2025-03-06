using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FinanceGub.Application.Interfaces.Serviсes;
using Microsoft.AspNetCore.Http;

namespace FinanceHub.Infrastructure.Services;

public class AzureBlobStorageService: IAzureBlobStorageService
{
    private readonly string _connectionString;
    private readonly string _containerName;

    public AzureBlobStorageService(string connectionString, string containerName)
    {
        _connectionString = connectionString;
        _containerName = containerName;
    }

    public async Task<string> UploadProfilePictureAsync(IFormFile file)
    {
        // Створюємо екземпляр BlobServiceClient
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);
        
        // Створюємо контейнер, якщо він не існує
        await blobContainerClient.CreateIfNotExistsAsync();

        // Генеруємо унікальне ім'я для файлу
        var fileName = "profile/" + Guid.NewGuid() + Path.GetExtension(file.FileName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        // Завантажуємо файл в Blob Storage
        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
        }

        // Повертаємо URL завантаженого зображення
        return blobClient.Uri.ToString();
    }
    
    public async Task<string> UploadPostImageAsync(IFormFile file)
    {
        var blobServiceClient = new BlobServiceClient(_connectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);
    
        await blobContainerClient.CreateIfNotExistsAsync(); // Create container if not exists

        var fileName = "posts/" + Guid.NewGuid() + Path.GetExtension(file.FileName); // Store in "posts/" folder
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        using (var stream = file.OpenReadStream())
        {
            await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
        }

        return blobClient.Uri.ToString(); // Return image URL
    }

    public async Task DeleteBlobAsync(string imageUrl)
    {
        var blobServiceClient = new BlobServiceClient(_connectionString);
        // Отримайте контейнер, в якому зберігаються зображення
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);

        // Отримайте ім'я блоба з URL
        var blobName = GetBlobNameFromUrl(imageUrl);

        // Отримайте блоб-клієнт
        var blobClient = blobContainerClient.GetBlobClient(blobName);

        // Видалення блоба
        await blobClient.DeleteIfExistsAsync();
    }
    private string GetBlobNameFromUrl(string imageUrl)
    {
        // Витягніть ім'я блоба з URL
        var uri = new Uri(imageUrl);
        return uri.Segments.Last(); // Витягує останній сегмент URL як ім'я блоба
    }
}
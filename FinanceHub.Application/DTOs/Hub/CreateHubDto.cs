using Microsoft.AspNetCore.Http;

namespace FinanceGub.Application.DTOs.Hub;

public class CreateHubDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile? MainPhoto { get; set; }  // For the main photo
    public IFormFile? BackgroundPhoto { get; set; }  // For the background photo
}

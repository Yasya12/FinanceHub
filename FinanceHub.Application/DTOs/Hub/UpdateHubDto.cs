using Microsoft.AspNetCore.Http;

namespace FinanceGub.Application.DTOs.Hub;

public class UpdateHubDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? MainPhoto { get; set; }
    public IFormFile? BackgroundPhoto { get; set; }
}

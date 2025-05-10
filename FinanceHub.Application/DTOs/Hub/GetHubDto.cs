using FinanceGub.Application.DTOs.Post;

namespace FinanceGub.Application.DTOs.Hub;

public class GetHubDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? MainPhotoUrl { get; set; }
    public string? BackgroundPhotoUrl { get; set; }
    public string PostPermission { get; set; }
    public List<GetPostDto> Posts { get; set; }
}
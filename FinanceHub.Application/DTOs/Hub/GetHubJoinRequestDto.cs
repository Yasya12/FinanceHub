namespace FinanceGub.Application.DTOs.Hub;

public class GetHubJoinRequestDto
{
    public Guid Id { get; set; }
    public string HabName { get; set; }

    public string SenderUsername { get; set; }
    public string Status { get; set; }

    public string Content { get; set; }
    public string? Description { get; set; }

    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
}
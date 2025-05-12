namespace FinanceGub.Application.DTOs.Hub;

public class CreateHubJoinRequestDto
{
    public Guid HubId { get; set; }
        
    public string Content { get; set; }
    public string Description { get; set; }
}
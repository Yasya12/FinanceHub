namespace FinanceHub.Core.Entities;

public class HubMember : Base
{
    // FK to Hub
    public Guid HubId { get; set; }
    public Hub Hub { get; set; }

    // FK to User
    public Guid UserId { get; set; }
    public User User { get; set; }

    // Hub-specific role
    public string Role { get; set; } = "Pending"; // Admin, Moderator, Member, Pending
    
    public string? Description { get; set; }

    public bool IsApproved { get; set; } = false;

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}
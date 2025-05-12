namespace FinanceHub.Core.Entities;

public class Notification : Base
{
    public Guid UserId { get; set; } // Користувач, який отримує нотифікацію
    public User User { get; set; }
    public Guid TriggeredBy { get; set; } // Користувач, який викликав нотифікацію
    public User TriggeredByUser { get; set; }
    public string Type { get; set; } // "like", "follow", "joinRequest"
    public string Content { get; set; }
    public Guid? PostId { get; set; }
    public Guid? HubId { get; set; }
    public Guid? RequestId { get; set; }
    public HubJoinRequest Request { get; set; }
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
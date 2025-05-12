namespace FinanceGub.Application.DTOs.Notification;

public class GetNotificationDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string TriggeredUserPhotoUrl { get; set; }
    public Guid TriggeredBy { get; set; }  // Користувач, який викликав нотифікацію
    public string Type { get; set; }  // "like", "follow", "joinRequest"
    public string Content { get; set; }
    public Guid? PostId { get; set; }
    public Guid? HubId { get; set; }
    public Guid? RequestId { get; set; }
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
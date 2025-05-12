namespace FinanceGub.Application.DTOs.Notification;

public class CreateNotificationDto
{
    public Guid UserId { get; set; }
    public Guid TriggeredBy { get; set; }
    public string Type { get; set; }
    public string Content { get; set; }
    public Guid? PostId { get; set; }
    public Guid? HubId { get; set; }
    public Guid? RequestId { get; set; }
}
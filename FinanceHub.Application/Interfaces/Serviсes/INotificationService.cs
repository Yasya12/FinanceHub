using FinanceGub.Application.DTOs.Notification;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface INotificationService
{
    Task<IEnumerable<GetNotificationDto>> GetAllNotificationsForUser(Guid id);
    Task<IEnumerable<GetNotificationDto>> GetLikeNotificationsForUser(Guid id);
    Task<IEnumerable<GetNotificationDto>> GetRequestNotificationsForUser(Guid id);
    Task<IEnumerable<GetNotificationDto>> GetFollowNotificationsForUser(Guid id);
    Task MarkNotificationAsRead(Guid id);
    Task CreateNotification(CreateNotificationDto notificationDto);
    Task<string> DeleteNotificationAsync(Guid id);
    Task RemoveNotificationAsync(CreateNotificationDto notificationDto);
}
using System.Collections;
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface INotificationRepository: IGenericRepository<Notification>
{
    Task<IEnumerable<Notification>> GetAllNotificationsForUser(Guid userId);
    Task<IEnumerable<Notification>> GetLikeNotificationsForUser(Guid userId);
    Task<IEnumerable<Notification>> GetRequestNotificationsForUser(Guid userId);
    Task<IEnumerable<Notification>> GetFollowNotificationsForUser(Guid userId);
    Task RemoveNotificationAsync(Guid userId, Guid triggeredBy, string type, Guid postId);
}
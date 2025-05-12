using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class NotificationRepository(FinHubDbContext context)
    : GenericRepository<Notification>(context), INotificationRepository
{
    public async Task<IEnumerable<Notification>> GetAllNotificationsForUser(Guid userId)
    {
        return await _dbSet
            .Include(n => n.TriggeredByUser)
            .Include(n => n.Request)
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Notification>> GetLikeNotificationsForUser(Guid userId)
    {
        return await _dbSet
            .Include(n => n.TriggeredByUser)
            .Include(n => n.Request)
            .Where(n => n.UserId == userId && n.Type == "like")
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Notification>> GetRequestNotificationsForUser(Guid userId)
    {
        return await _dbSet
            .Include(n => n.TriggeredByUser)
            .Include(n => n.Request)
            .Where(n => n.UserId == userId && n.Type == "request")
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();
    }

    public async Task RemoveNotificationAsync(Guid userId, Guid triggeredBy, string type, Guid postId)
    {
        var notification = await _dbSet
            .FirstOrDefaultAsync(n =>
                n.UserId == userId &&
                n.TriggeredBy == triggeredBy &&
                n.Type == type &&
                n.PostId == postId);

        if (notification != null)
        {
            await DeleteAsync(notification.Id);
        }
    }
}
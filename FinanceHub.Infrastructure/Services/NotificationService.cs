using AutoMapper;
using FinanceGub.Application.DTOs.Notification;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;

namespace FinanceHub.Infrastructure.Services;

public class NotificationService(INotificationRepository notificationRepository,  IMapper mapper) : INotificationService 
{
    
    public async Task<IEnumerable<GetNotificationDto>> GetAllNotificationsForUser(Guid id)
    {
       var noti = await notificationRepository.GetAllNotificationsForUser(id);
       var notificationDto = mapper.Map<IEnumerable<GetNotificationDto>>(noti);
       return notificationDto;
    }
    
    public async Task<IEnumerable<GetNotificationDto>> GetLikeNotificationsForUser(Guid id)
    {
        var noti = await notificationRepository.GetLikeNotificationsForUser(id);
        var notificationDto = mapper.Map<IEnumerable<GetNotificationDto>>(noti);
        return notificationDto; 
    }
    
    public async Task<IEnumerable<GetNotificationDto>> GetRequestNotificationsForUser(Guid id)
    {
        var noti = await notificationRepository.GetRequestNotificationsForUser(id);
        var notificationDto = mapper.Map<IEnumerable<GetNotificationDto>>(noti);
        return notificationDto;
    }
    
    public async Task MarkNotificationAsRead(Guid id)
    {
        var notification = await notificationRepository.GetByIdAsync(id);
        if (notification == null)
        {
            throw new KeyNotFoundException("Notification not found.");
        }

        notification.IsRead = true;
        await notificationRepository.UpdateAsync(notification);
    }
    
    public async Task CreateNotification(CreateNotificationDto notificationDto)
    {
        var notification = mapper.Map<Notification>(notificationDto);
        notification.CreatedAt = DateTime.UtcNow;
        notification.IsRead = false;

        await notificationRepository.AddAsync(notification);
    }
    
    public async Task<string> DeleteNotificationAsync(Guid id)
    {
        var noti = await notificationRepository.GetByIdAsync(id);
        if (noti == null)
        {
            throw new Exception("Notification not found.");
        }
        
        return await notificationRepository.DeleteAsync(id);
    }
    
    public async Task RemoveNotificationAsync(CreateNotificationDto notificationDto)
    {
        if (notificationDto.PostId != null)
        {
            await notificationRepository.RemoveNotificationAsync(notificationDto.UserId, notificationDto.TriggeredBy,
                notificationDto.Type, notificationDto.PostId.Value);
        }
        
    }

}
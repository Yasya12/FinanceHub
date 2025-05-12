using AutoMapper;
using FinanceGub.Application.DTOs.Notification;
using FinanceHub.Core.Entities;

namespace FinanceHub.Infrastructure.Mapping;

public class NotificationProfile : Profile
{
    public NotificationProfile()
    {
        CreateMap<CreateNotificationDto, Notification>();
        
        CreateMap<Notification, GetNotificationDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.TriggeredByUser.UserName))
            .ForMember(dest => dest.TriggeredUserPhotoUrl, opt => opt.MapFrom(src => src.TriggeredByUser.ProfilePictureUrl)) 
            .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src => src.Request.Status)) 
            .ForMember(dest => dest.TriggeredBy, opt => opt.MapFrom(src => src.TriggeredBy)) 
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.IsRead))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
    }
}
using AutoMapper;
using FinanceGub.Application.DTOs.Hub;
using FinanceHub.Core.Entities;

namespace FinanceHub.Infrastructure.Mapping;

public class HubJoinRequestMappingProfile : Profile
{
    public HubJoinRequestMappingProfile()
    {
        CreateMap<HubJoinRequest, GetHubJoinRequestDto>()
            .ForMember(dest => dest.HabName, opt => opt.MapFrom(src => src.Hub != null ? src.Hub.Name : "Unknown Hub"))
            .ForMember(dest => dest.SenderUsername,
                opt => opt.MapFrom(src => src.User != null ? src.User.UserName : "Unknown User"))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.RequestedAt, opt => opt.MapFrom(src => src.RequestedAt));
    }
}
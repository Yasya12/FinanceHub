using AutoMapper;
using FinanceGub.Application.DTOs.Hub;
using FinanceHub.Core.Entities;

namespace FinanceHub.Infrastructure.Mapping;

public class HubMappingProfile : Profile
{
    public HubMappingProfile()
    {
        CreateMap<Hub, GetHubDto>()
            .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts));
    }
}
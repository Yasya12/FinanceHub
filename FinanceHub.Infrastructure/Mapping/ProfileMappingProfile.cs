using FinanceGub.Application.DTOs.Profile;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class ProfileMappingProfile : Profile
{
    public ProfileMappingProfile()
    {
        CreateMap<CreateProfileDto, FinanceHub.Core.Entities.Profile>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)) 
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)) 
            .ForMember(dest => dest.User, opt => opt.Ignore()) 
            .ReverseMap();
    }
}
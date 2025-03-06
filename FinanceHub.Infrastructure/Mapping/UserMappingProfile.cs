using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.DTOs.User;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, GetUserDto>()
            .ForMember(dest => dest.ProfilePictureUrl, 
                opt => opt.MapFrom(src => src.Profile.ProfilePictureUrl));
        
        CreateMap<SignupDto, CreateUserDto>()
            .ForMember(dest => dest.Country, opt => opt.Ignore()) 
            .ForMember(dest => dest.DateOfBirth, opt => opt.Ignore()); 
    }
}
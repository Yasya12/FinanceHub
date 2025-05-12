using FinanceGub.Application.DTOs.Authentication;
using FinanceGub.Application.DTOs.User;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Identity;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, GetUserDto>()
            .ForMember(dest => dest.ProfilePictureUrl,
                opt => opt.MapFrom(src => src.ProfilePictureUrl));

        CreateMap<SignupDto, CreateUserDto>()
            .ForMember(dest => dest.Country, opt => opt.Ignore())
            .ForMember(dest => dest.DateOfBirth, opt => opt.Ignore());

        CreateMap<UpdateUserDto, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.PasswordHash, opt =>
            {
                opt.PreCondition(src => !string.IsNullOrEmpty(src.Password));
                opt.MapFrom(src => PasswordHasher.HashPassword(src.Password));
            })
            //.ForMember(dest => dest.Role, opt => opt.MapFrom(_ => IdentityData.UserUserClaimName))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
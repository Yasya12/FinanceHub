using AutoMapper;
using FinanceGub.Application.DTOs.Following;
using FinanceHub.Core.Entities;

namespace FinanceHub.Infrastructure.Mapping;

public class FollowingProfile : Profile
{
    public FollowingProfile()
    {
        CreateMap<CreateFollowingDto, Following>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<Following, GetFollowingUserDto>()
            .ForMember(dest => dest.FollowingId,
                opt => opt.MapFrom(src =>
                    src.FollowingUserId.HasValue ? src.FollowingUserId.Value : src.FollowingHubId))
            .ForMember(dest => dest.ProfilePhoroUrl,
                opt => opt.MapFrom(src => src.FollowingUserId.HasValue
                    ? src.FollowingUser.ProfilePictureUrl
                    : src.FollowingHub.MainPhotoUrl))
            .ForMember(dest => dest.Username,
                opt => opt.MapFrom(src => src.FollowingUserId.HasValue
                    ? src.FollowingUser.UserName
                    : src.FollowingHub.Name))
            .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.FollowingUserId.HasValue
                    ? src.FollowingUser.Email
                    : src.FollowingHub.Posts.Count.ToString()))
            .ForMember(dest => dest.Bio,
                opt => opt.MapFrom(src => src.FollowingUserId.HasValue
                    ? src.FollowingUser.Bio
                    : src.FollowingHub.Description))
            .ForMember(dest => dest.IsUser,
                opt => opt.MapFrom(src => src.FollowingUserId.HasValue)); 
    }
}
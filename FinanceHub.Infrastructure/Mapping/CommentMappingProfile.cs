using FinanceGub.Application.DTOs.Comment;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class CommentMappingProfile : Profile
{
    public CommentMappingProfile()
    {
        CreateMap<Comment, GetCommentDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Username))
            .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.Author.Profile.ProfilePictureUrl))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ReverseMap();

        CreateMap<UpdateCommentDto, Comment>()
            .ForMember(dest => dest.IsModified, opt => opt.MapFrom(src => true)); 
    }
}
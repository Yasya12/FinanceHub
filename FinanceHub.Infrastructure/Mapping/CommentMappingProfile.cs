using FinanceGub.Application.DTOs.Comment;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class CommentMappingProfile : Profile
{
    public CommentMappingProfile()
    {
        CreateMap<CreateCommentDto, Comment>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow)) 
            .ForMember(dest => dest.IsModified, opt => opt.MapFrom(src => false)); 

        CreateMap<Comment, GetCommentDto>()
            .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title)) 
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Username)); 

        CreateMap<UpdateCommentDto, Comment>()
            .ForMember(dest => dest.IsModified, opt => opt.MapFrom(src => true)); 
    }
}
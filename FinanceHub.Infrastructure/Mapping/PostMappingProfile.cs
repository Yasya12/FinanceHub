using FinanceGub.Application.DTOs.Comment;
using FinanceGub.Application.DTOs.Post;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<Post, GetPostDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Author.UserName))
            .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.Author.ProfilePictureUrl))
            .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.PostCategory.Select(pc => pc.Category.Name)))
            .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count)) // Мапінг тільки текстів коментарів
            .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count)) // Лише кількість лайків
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.PostImages.Select(pi => pi.ImageUrl)))
            .ReverseMap();

        CreateMap<Post, GetSinglePostDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Author.UserName))
            .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.Author.ProfilePictureUrl))
            .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.PostCategory.Select(pc => pc.Category.Name)))
            .ForMember(dest => dest.LikesCount, opt => opt.MapFrom(src => src.Likes.Count))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.PostImages.Select(pi => pi.ImageUrl)))
            .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.Comments.Count));

        CreateMap<CreatePostDto, Post>()
            .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow)) 
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow)) 
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.PostCategory, opt => opt.MapFrom(src => src.CategoryNames.Select(name => new PostCategory
            {
                Category = new Category { Name = name }
            })));

        CreateMap<UpdatePostDto, Post>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow)) 
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.Content, opt => opt.Condition(src => src.Content != null))
            .ForMember(dest => dest.PostCategory, opt => opt.Ignore()); 
    }
}
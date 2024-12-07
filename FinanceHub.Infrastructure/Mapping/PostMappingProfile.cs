using FinanceGub.Application.DTOs.Post;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<Post, GetPostDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Author.Username))
            .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.PostCategory.Select(pc => pc.Category.Name)))
            .ReverseMap();
            
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
            .ForMember(dest => dest.Title, opt => opt.Condition(src => src.Title != null)) 
            .ForMember(dest => dest.Content, opt => opt.Condition(src => src.Content != null))
            .ForMember(dest => dest.PostCategory, opt => opt.Ignore()); 
    }
}
using FinanceGub.Application.DTOs.Category;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class CategoryMappingProfile: Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, GetCategoryDto>()
            .ForMember(dest => dest.PostNames, opt => opt.MapFrom(src => src.PostCategory.Select(pc => pc.Post.Title)));
        
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}
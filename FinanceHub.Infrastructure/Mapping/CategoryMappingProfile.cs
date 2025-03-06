using FinanceGub.Application.DTOs.Category;
using FinanceHub.Core.Entities;
using Profile = AutoMapper.Profile;

namespace FinanceHub.Infrastructure.Mapping;

public class CategoryMappingProfile: Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, GetCategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}
using FinanceGub.Application.DTOs.Category;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface ICategoryService
{
    Task<IEnumerable<GetCategoryDto>> GetAllCategoryAsync();
    Task<GetCategoryDto> GetCategoryAsync(Guid id);
    Task<CreateCategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto);
    Task<UpdateCategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto category);
    Task<string> DeleteCategoryAsync(Guid postId);
}
using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IPostCategoryRepository
{
    Task RemoveRangeAsync(IEnumerable<PostCategory> postCategories);
    Task AddRangeAsync(Post existingPost, IEnumerable<Category> categories);
}
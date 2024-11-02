using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class PostCategoryRepository : IPostCategoryRepository
{
    protected readonly DbContext _context;
    protected readonly DbSet<PostCategory> _dbSet;

    public PostCategoryRepository(FinHubDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<PostCategory>();
    }
    
    public async Task RemoveRangeAsync(IEnumerable<PostCategory> postCategories)
    {
        _dbSet.RemoveRange(postCategories);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddRangeAsync(Post existingPost, IEnumerable<Category> categories)
    {
        var postCategories = categories.Select(category => new PostCategory
        {
            PostId = existingPost.Id,
            CategoryId = category.Id,
            Category = category
        }).ToList();

        await _dbSet.AddRangeAsync(postCategories);
        await _context.SaveChangesAsync();
    }
}
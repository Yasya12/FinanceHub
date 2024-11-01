using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(FinHubDbContext context) : base(context){ }
    
    public async Task<List<Category>> GetCategoriesByNamesAsync(IEnumerable<string> categoryNames)
    {
        if (categoryNames == null || !categoryNames.Any())
        {
            return new List<Category>(); 
        }

        var categories = await _dbSet
            .Where(c => categoryNames.Contains(c.Name)) 
            .ToListAsync();

        return categories;
    }
}
using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class GenericRepository<T>: IGenericRepository<T> where T: Base
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(FinHubDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public virtual async Task<T> GetByIdAsync(Guid id, string? includeProperties = null)
    {
        var query = _context.Set<T>().AsQueryable();
        
        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(prop);
            }
        }
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
    {
        var query = _context.Set<T>().AsQueryable();

        if (!string.IsNullOrEmpty(includeProperties))
        {
            foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(prop);
            }
        }
        
        return await query.ToListAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}
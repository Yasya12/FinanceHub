namespace FinanceGub.Application.Interfaces.Repositories;

public interface IGenericRepository<T>  where T : class
{
    Task<T> GetByIdAsync(Guid id, string? includeProperties = null);
    Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
    IQueryable<T> GetAllAsQueryable(string? includeProperties = null);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task<string> DeleteAsync(Guid id);
}
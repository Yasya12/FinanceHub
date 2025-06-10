using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> SearchUsersAsync(string query, int takeCount);
    Task<User> GetByEmailAsync(string email, string? includeProperties = null);
    Task<User> GetByGoogleIdAsync(string googleId);
    Task<User> GetByUsernameAsync(string username, string? includeProperties = null);
    
    //generic
    Task<User> GetByIdAsync(Guid id, string? includeProperties = null);
    Task<IEnumerable<User>> GetAllAsync(string? includeProperties = null);
    IQueryable<User> GetAllAsQueryable(string? includeProperties = null);
    Task AddAsync(User entity);
    Task UpdateAsync(User entity);
    Task<string> DeleteAsync(Guid id);
    Task<bool> SaveAllAsync();
}
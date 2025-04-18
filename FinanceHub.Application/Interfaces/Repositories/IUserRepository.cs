using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByEmailAsync(string email, string? includeProperties = null);
    Task<User> GetByGoogleIdAsync(string googleId);
    Task<User> GetByUsernameAsync(string username, string? includeProperties = null);
}
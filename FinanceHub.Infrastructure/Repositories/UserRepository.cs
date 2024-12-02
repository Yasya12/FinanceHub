using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Core.Exceptions;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(FinHubDbContext context) : base(context){ }
    
    public async Task<User> GetByEmailAsync(string email)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
        catch (RepositoryException ex)
        {
            throw new RepositoryException("An error occurred while trying to retrieve the user by email.", ex);
        }
    }
    
    public async Task<User> GetByGoogleIdAsync(string googleId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.GoogleId == googleId);
        }
        catch (RepositoryException ex)
        {
            throw new RepositoryException("An error occurred while trying to retrieve the user by Google ID.", ex);
        }
    }
}
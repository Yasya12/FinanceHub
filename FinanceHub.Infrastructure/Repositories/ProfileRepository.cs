using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class ProfileRepository: GenericRepository<Profile>, IProfileRepository
{
    public ProfileRepository(FinHubDbContext context) : base(context) { }
    
    public async Task<Profile> GetByUserIdAsync(Guid userId)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.UserId == userId);
    }

}
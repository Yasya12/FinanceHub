using FinanceGub.Application.Interfaces.Repositories;
using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Repositories;

public class FollowingRepository(FinHubDbContext context) : GenericRepository<Following>(context), IFollowingRepository
{
    public async Task<int> GetFollowersCountAsync(Guid userId)
    {
        return await _dbSet.CountAsync(f => f.FollowingUserId == userId);
    }

    public async Task<int> GetFollowingCountAsync(Guid userId)
    {
        return await _dbSet.CountAsync(f => f.FollowerId == userId);
    }
    
    public async Task<bool> IsFollowingAsunc(Guid followerId, Guid followingId,  string type)
    {
        if (type.ToLower() == "user")
        {
            return await _dbSet
                .AnyAsync(f => f.FollowerId == followerId && f.FollowingUserId == followingId);
        }
        else if (type.ToLower() == "hub")
        {
            return await _dbSet
                .AnyAsync(f => f.FollowerId == followerId && f.FollowingHubId == followingId);
        }

        throw new ArgumentException("Invalid follow type. Expected 'user' or 'hub'.");
    }

    public async Task RemoveAsync(Guid followerId, Guid followingId)
    {
        var following =
            await _dbSet.FirstOrDefaultAsync(f =>
                f.FollowerId == followerId && (f.FollowingUserId == followingId || f.FollowingHubId == followingId));
        if (following != null)
        {
            _dbSet.Remove(following);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Following>> GetFollowingsByUserIdAsync(Guid userId)
    {
        return await _dbSet
            .Include(u => u.FollowingUser)
            .Include(u => u.FollowingHub)
            .Where(f => f.FollowerId == userId)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Following>> GetFollowersByUserIdAsync(Guid userId)
    {
        var followers = await _dbSet
            .Include(u => u.FollowergUser)
            .Include(u => u.FollowingHub)
            .Where(f => f.FollowingUserId == userId)
            .ToListAsync();

        return followers;
    }

    public async Task<List<(Guid? UserId, Guid? HubId)>> GetFollowingIdsAsync(Guid userId)
    {
        return await _dbSet
            .Where(f => f.FollowerId == userId)
            .Select(f => new ValueTuple<Guid?, Guid?>(f.FollowingUserId, f.FollowingHubId))
            .ToListAsync();
    }
}
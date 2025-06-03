using FinanceHub.Core.Entities;

namespace FinanceGub.Application.Interfaces.Repositories;

public interface IFollowingRepository : IGenericRepository<Following>
{
    Task<int> GetFollowersCountAsync(Guid userId);
    Task<int> GetFollowingCountAsync(Guid userId);
    Task<bool> IsFollowingAsunc(Guid followerId, Guid followingId, string type);
    Task RemoveAsync(Guid followerId, Guid followingId);
    Task<IEnumerable<Following>> GetFollowingsByUserIdAsync(Guid userId);
    Task<IEnumerable<Following>> GetFollowersByUserIdAsync(Guid userId);
    Task<List<(Guid? UserId, Guid? HubId)>> GetFollowingIdsAsync(Guid userId);
}
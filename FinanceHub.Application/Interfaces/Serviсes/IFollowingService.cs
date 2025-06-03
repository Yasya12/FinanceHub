using FinanceGub.Application.DTOs.Following;

namespace FinanceGub.Application.Interfaces.Serviсes;

public interface IFollowingService
{
    Task<IEnumerable<GetFollowingUserDto>> GetFollowingsForSpecificUser(Guid userId, Guid currentUserId);
    Task<IEnumerable<GetFollowingUserDto>> GetFollowersForSpecificUser(Guid userId, Guid currentUserId);
    Task<bool> IsFollowing(Guid followerId, Guid followingId, string type);
    Task<IEnumerable<GetFollowingUserDto>> GetFollowingsForUser(Guid userId);
    Task FollowHubAsync(Guid followerId, Guid followingHubId);
    Task FollowUserAsync(Guid followerId, Guid followingId);

    Task UnfollowAsync(Guid followerId, Guid followingId);
    Task CreateNotiFollowHub(Guid hubId, Guid triggeredUserId, string triggeredUserUsername);

}
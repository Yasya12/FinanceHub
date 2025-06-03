using AutoMapper;
using FinanceGub.Application.DTOs.Following;
using FinanceGub.Application.DTOs.Notification;
using FinanceGub.Application.Interfaces.Repositories;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;

namespace FinanceHub.Infrastructure.Services;

public class FollowingService(
    IFollowingRepository followingRepository,
    IMapper mapper,
    IHubRepository hubRepository,
    INotificationService notificationService) : IFollowingService
{
    public async Task FollowUserAsync(Guid followerId, Guid followingId)
    {
        var following = new Following()
        {
            FollowerId = followerId,
            FollowingUserId = followingId,
            CreatedAt = DateTime.UtcNow
        };
        await followingRepository.AddAsync(following);
    }

    public async Task FollowHubAsync(Guid followerId, Guid followingHubId)
    {
        var following = new Following()
        {
            FollowerId = followerId,
            FollowingHubId = followingHubId,
            CreatedAt = DateTime.UtcNow
        };
        await followingRepository.AddAsync(following);
    }

    public async Task<bool> IsFollowing(Guid followerId, Guid followingId, string type)
    {
        if (followingId == null || String.IsNullOrEmpty(type))
        {
            throw new Exception("Cannot do it now.Try later.");
        }

        return await followingRepository.IsFollowingAsunc(followerId, followingId, type);
    }

    public async Task UnfollowAsync(Guid followerId, Guid followingId)
    {
        await followingRepository.RemoveAsync(followerId, followingId);
    }

    public async Task<IEnumerable<GetFollowingUserDto>> GetFollowingsForUser(Guid userId)
    {
        var followings = await followingRepository.GetFollowingsByUserIdAsync(userId);
        return mapper.Map<IEnumerable<GetFollowingUserDto>>(followings);
    }

    public async Task<IEnumerable<GetFollowingUserDto>> GetFollowingsForSpecificUser(Guid userId, Guid currentUserId)
    {
        var followings = await followingRepository.GetFollowingsByUserIdAsync(userId);

        var currentUserFollowings = await followingRepository.GetFollowingsByUserIdAsync(currentUserId);
        var followedUserIds = currentUserFollowings
            .Select(f => f.FollowingUserId ?? f.FollowingHubId)
            .Where(id => id.HasValue)
            .Select(id => id.Value)
            .ToHashSet();

        var result = mapper.Map<IEnumerable<GetFollowingUserDto>>(followings);

        foreach (var dto in result)
        {
            dto.IsFollowedByCurrentUser = followedUserIds.Contains(dto.FollowingId);
        }

        return result;
    }


    public async Task<IEnumerable<GetFollowingUserDto>> GetFollowersForSpecificUser(Guid userId, Guid currentUserId)
    {
        // 1. Всі фоловери (тобто ті, хто підписані на userId)
        var followers = await followingRepository.GetFollowersByUserIdAsync(userId);

        // 2. Поточний користувач — на кого підписаний
        var currentUserFollowings = await followingRepository.GetFollowingsByUserIdAsync(currentUserId);
        var followedUserIds = currentUserFollowings
            .Select(f => f.FollowingUserId ?? f.FollowingHubId)
            .Where(id => id.HasValue)
            .Select(id => id.Value)
            .ToHashSet();

        // 3. Ручне мапінгування
        var result = followers.Select(f =>
        {
            var user = f.FollowergUser;

            return new GetFollowingUserDto
            {
                FollowingId = user.Id,
                ProfilePhoroUrl = user.ProfilePictureUrl,
                Username = user.UserName,
                Email = user.Email,
                Bio = user.Bio,
                IsFollowedByCurrentUser = followedUserIds.Contains(user.Id),
                IsUser = true
            };
        });

        return result;
    }

    public async Task CreateNotiFollowHub(Guid hubId, Guid triggeredUserId, string triggeredUserUsername)
    {
        var hubAdmin =
            await hubRepository.GetByHubIdAdminAsync(hubId);
        var hub = await hubRepository.GetByIdAsync(hubId);
        var content = $"{triggeredUserUsername} started to follow your hub {hub.Name}";

        var notificationDto = new CreateNotificationDto
        {
            UserId = hubAdmin.UserId,
            TriggeredBy = triggeredUserId,
            Type = "follow",
            Content = content
        };

        await notificationService.CreateNotification(notificationDto);
    }
}
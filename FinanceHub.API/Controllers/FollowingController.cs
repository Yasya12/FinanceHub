using FinanceGub.Application.DTOs.Following;
using FinanceGub.Application.DTOs.Notification;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByUsernameUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FollowingController(
    IFollowingService followingService,
    IMediator mediator,
    INotificationService notificationService) : ControllerBase
{
    // Reusable method to get the current user
    private async Task<User> GetCurrentUserAsync()
    {
        var email = User.GetEmail();
        return await mediator.Send(new GetByEmailUserQuery(email));
    }

    // Reusable method to check the validity of the ID
    private IActionResult ValidateGuid(Guid id)
    {
        return id == Guid.Empty ? BadRequest("Invalid ID.") : null;
    }

    [HttpGet("followings")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetFollowingUserDto>>> GetFollowings()
    {
        var currentUser = await GetCurrentUserAsync();
        if (currentUser == null)
            return Unauthorized();

        var followings = await followingService.GetFollowingsForUser(currentUser.Id);
        return Ok(followings);
    }

    [HttpGet("followings-for-specific-user/{username}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetFollowingUserDto>>> GetFollowingsForSpecificUser(string username)
    {
        var currentUser = await GetCurrentUserAsync();
        if (currentUser == null)
            return Unauthorized();
        
        var user = await mediator.Send(new GetByUsernameUserQuery(username));
        if (user == null) return BadRequest("User not found");

        var followings = await followingService.GetFollowingsForSpecificUser(user.Id, currentUser.Id);
        return Ok(followings);
    }

    [HttpGet("followers-for-specific-user/{username}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetFollowingUserDto>>> GetFollowersForSpecificUser(string username)
    {
        var currentUser = await GetCurrentUserAsync();
        if (currentUser == null)
            return Unauthorized();

        var user = await mediator.Send(new GetByUsernameUserQuery(username));
        if (user == null) return BadRequest("User not found");

        var followers = await followingService.GetFollowersForSpecificUser(user.Id, currentUser.Id);
        return Ok(followers);
    }

    [HttpGet("is-following")]
    [Authorize]
    public async Task<bool> IsFollowing(Guid id, string type = "user")
    {
        var currentUser = await GetCurrentUserAsync();
        if (currentUser == null)
            throw new UnauthorizedAccessException("User not found or not authorized.");

        var isFollowing = await followingService.IsFollowing(currentUser.Id, id, type);
        return isFollowing;
    }

    [HttpPost("follow-user")]
    [Authorize]
    public async Task<IActionResult> FollowUserAsync([FromQuery] Guid followingId)
    {
        var validation = ValidateGuid(followingId);
        if (validation != null) return validation;

        var currentUser = await GetCurrentUserAsync();
        if (currentUser == null)
            return Unauthorized();

        await followingService.FollowUserAsync(currentUser.Id, followingId);

        // Створення нотифікації про following
        var content = $"{currentUser.UserName} started to follow you";

        var notificationDto = new CreateNotificationDto
        {
            UserId = followingId,
            TriggeredBy = currentUser.Id,
            Type = "follow",
            Content = content
        };

        await notificationService.CreateNotification(notificationDto);

        return Ok(new { Message = "Followed successfully" });
    }

    // [HttpPost("follow-user-by-email")]
    // [Authorize]
    // public async Task<IActionResult> FollowUserByEmailAsync([FromQuery] string followingEmail)
    // {
    //     var user = await mediator.Send(new GetByEmailUserQuery(followingEmail));
    //     if (user == null) return BadRequest("User not found");
    //
    //     return await FollowUserAsync(user.Id);
    // }

    [HttpPost("follow-hub")]
    [Authorize]
    public async Task<IActionResult> FollowHubAsync([FromQuery] Guid followingHubId)
    {
        var validation = ValidateGuid(followingHubId);
        if (validation != null) return validation;

        var currentUser = await GetCurrentUserAsync();
        if (currentUser == null)
            return Unauthorized();

        await followingService.FollowHubAsync(currentUser.Id, followingHubId);

        await followingService.CreateNotiFollowHub(followingHubId, currentUser.Id, currentUser.UserName);

        return Ok(new { Message = "Followed successfully" });
    }
    
    // [HttpPost("follow-hub-by-email")]
    // [Authorize]
    // public async Task<IActionResult> FollowHubByEmailAsync([FromQuery] string followingEmail)
    // {
    //     var user = await mediator.Send(new GetByEmailUserQuery(followingEmail));
    //     if (user == null) return BadRequest("User not found");
    //
    //     return await FollowUserAsync(user.Id);
    // }

    [HttpDelete("unfollow")]
    [Authorize]
    public async Task<IActionResult> UnfollowAsync([FromQuery] Guid followingId)
    {
        var validation = ValidateGuid(followingId);
        if (validation != null) return validation;

        var currentUser = await GetCurrentUserAsync();
        if (currentUser == null)
            return Unauthorized();

        await followingService.UnfollowAsync(currentUser.Id, followingId);

        // Створення нотифікації про following
        var content = $"{currentUser.UserName} started to follow you";

        var notificationDto = new CreateNotificationDto
        {
            UserId = followingId,
            TriggeredBy = currentUser.Id,
            Type = "follow",
            Content = content
        };

        await notificationService.RemoveNotificationAsync(notificationDto);
        return Ok(new { Message = "Unfollowed successfully" });
    }
}
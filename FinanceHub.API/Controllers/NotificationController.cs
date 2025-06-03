using FinanceGub.Application.DTOs.Notification;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Core.Entities;
using FinanceHub.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController(INotificationService notificationService, IMediator mediator) : Controller
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetNotificationDto>>> GetNotificationsForUser()
    {
        var email = User.GetEmail();
        var currentUser = await mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            return Unauthorized();

        var notifications = await notificationService.GetAllNotificationsForUser(currentUser.Id);
        return Ok(notifications);
    }

    [HttpGet("likes-noti")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetNotificationDto>>> GetLikeNotificationsForUser()
    {
        var email = User.GetEmail();
        var currentUser = await mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            return Unauthorized();

        var notifications = await notificationService.GetLikeNotificationsForUser(currentUser.Id);
        return Ok(notifications);
    }

    [HttpGet("request-noti")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetNotificationDto>>> GetRequestNotificationsForUser()
    {
        var email = User.GetEmail();
        var currentUser = await mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            return Unauthorized();

        var notifications = await notificationService.GetRequestNotificationsForUser(currentUser.Id);
        return Ok(notifications);
    }
    
    [HttpGet("follow-noti")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<GetNotificationDto>>> GetFollowNotificationsForUser()
    {
        var email = User.GetEmail();
        var currentUser = await mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            return Unauthorized();

        var notifications = await notificationService.GetFollowNotificationsForUser(currentUser.Id);
        return Ok(notifications);
    }

    [HttpPut("{id}/mark-read")]
    [Authorize]
    public async Task<IActionResult> MarkNotificationAsRead(Guid id)
    {
        await notificationService.MarkNotificationAsRead(id);
        return Ok();
    }

    // [HttpPost]
    // [Authorize]
    // public async Task<IActionResult> CreateNotification([FromBody] CreateNotificationDto notificationDto)
    // {
    //     await notificationService.CreateNotification(notificationDto);
    //     return Ok();
    // }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteNotification(Guid id)
    {
        await notificationService.DeleteNotificationAsync(id);
        return NoContent();
    }
}
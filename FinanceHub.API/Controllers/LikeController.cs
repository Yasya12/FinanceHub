using System.Security.Claims;
using FinanceGub.Application.Features.UserFeatures.Queries.GetByEmailUserQuery;
using FinanceGub.Application.Interfaces.Serviсes;
using FinanceHub.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikeController(ILikeService likeService, IMediator mediator) : ControllerBase
{
    [HttpPost("toggle-like/{postId}")]
    [Authorize]
    public async Task<IActionResult> ToggleLike(Guid postId)
    {
        var email = User.GetEmail();
        var currentUser = await mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            return Unauthorized();

        var likeAdded = await likeService.ToggleLikeAsync(postId, currentUser.Id, currentUser.UserName);
        return Ok(new { success = likeAdded });
    }
    
    [HttpGet("is-liked/{postId}")]
    [Authorize]
    public async Task<IActionResult> IsPostLiked(Guid postId)
    {
        var email = User.GetEmail();
        var currentUser = await mediator.Send(new GetByEmailUserQuery(email));
        if (currentUser == null)
            return Unauthorized();

        var isLiked = await likeService.IsPostLikedAsync(postId, currentUser.Id);
        
        return Ok(new { isLiked });
    }

}

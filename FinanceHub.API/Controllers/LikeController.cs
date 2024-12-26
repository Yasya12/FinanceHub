using System.Security.Claims;
using FinanceGub.Application.Interfaces.Serviсes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly ILikeService _likeService;

    public LikeController(ILikeService likeService)
    {
        _likeService = likeService;
    }

    [HttpPost("toggle-like/{postId}")]
    [Authorize]
    public async Task<IActionResult> ToggleLike(Guid postId)
    {
        var token = Request.Headers["Authorization"].FirstOrDefault();

        // Отримуємо userId з JWT токена
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userId, out var parsedUserId))
        {
            return Unauthorized("User is not authenticated");
        }

        var likeAdded = await _likeService.ToggleLikeAsync(postId, parsedUserId);
        return Ok(new { success = likeAdded });
    }
    
    [HttpGet("is-liked/{postId}")]
    [Authorize]
    public async Task<IActionResult> IsPostLiked(Guid postId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(userId, out var parsedUserId))
        {
            return Unauthorized("User is not authenticated");
        }

        var isLiked = await _likeService.IsPostLikedAsync(postId, parsedUserId);
        
        return Ok(new { isLiked });
    }

}

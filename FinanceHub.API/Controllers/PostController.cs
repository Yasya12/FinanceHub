using System.Security.Claims;
using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.Extensions;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController(IMediator mediator, ILogger<BaseController> logger, IPostService postService)
    : BaseController(mediator, logger)
{
    [HttpGet]
    public async Task<ActionResult<PagedList<GetPostDto>>> GetAllPost([FromQuery] PostParams postParams)
    {
        var paginatedPosts = await postService.GetPostsPaginatedAsync(postParams);
        
        Response.AddPaginationHeader(paginatedPosts);
        
        return Ok(paginatedPosts); 
    }
    
    [HttpGet("hub-posts")]
    public async Task<ActionResult<PagedList<GetPostDto>>> GetAllHubPost([FromQuery] PostParams postParams, [FromQuery] Guid hubId)
    {
        var paginatedPosts = await postService.GetHubPostsPaginatedAsync(postParams, hubId);
        
        Response.AddPaginationHeader(paginatedPosts);
        
        return Ok(paginatedPosts); 
    }
    
    [Authorize]
    [HttpGet("hub-posts-with-likes")]
    public async Task<ActionResult<PagedList<GetPostDto>>> GetHubPostsWithLikes([FromQuery] PostParams postParams, [FromQuery] Guid hubId)
    {
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (currentUserId == null) return BadRequest("No User Id found in token");
        
        Guid userId = Guid.Parse(currentUserId);
        
        var paginatedPosts = await postService.GetHubPostsWithLikesAsync(postParams, userId, hubId);
        
        Response.AddPaginationHeader(paginatedPosts);
        
        return Ok(paginatedPosts); 
    }
    
    [Authorize]
    [HttpGet("with-likes")]
    public async Task<ActionResult<PagedList<GetPostDto>>> GetPostsWithLikes([FromQuery] PostParams postParams)
    {
        var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (currentUserId == null) return BadRequest("No User Id found in token");
        
        Guid userId = Guid.Parse(currentUserId);
        
        var paginatedPosts = await postService.GetPostsWithLikesAsync(postParams, userId);
        
        Response.AddPaginationHeader(paginatedPosts);
        
        return Ok(paginatedPosts); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetSinglePostDto>> GetPost(Guid id)
    { 
        var postDtos = await postService.GetPostAsync(id);
        return Ok(postDtos); 
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromForm] CreatePostDto postDto)
    {
        var post = await postService.CreatePostAsync(postDto);
        return Created(string.Empty, post);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var updatePost = await postService.UpdatePostAsync(id, updatePostDto);
        return Ok(updatePost);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var message = await postService.DeletePostAsync(id);
        return Content(message); 
    }
  
}
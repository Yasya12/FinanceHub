using FinanceGub.Application.DTOs.Post;
using FinanceGub.Application.Extensions;
using FinanceGub.Application.Helpers;
using FinanceGub.Application.Interfaces.Serviсes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : BaseController
{
    private readonly IPostService _postService;
    
    public PostController(IMediator mediator, ILogger<BaseController> logger, IPostService postService): base(mediator, logger)
    {
        _postService = postService;
    }
    
    [HttpGet]
    public async Task<ActionResult<PagedList<GetPostDto>>> GetAllPost([FromQuery] PostParams postParams)
    {
        var paginatedPosts = await _postService.GetPostsPaginatedAsync(postParams);
        
        Response.AddPaginationHeader(paginatedPosts);
        
        return Ok(paginatedPosts); 
    }
    
    [HttpGet("with-likes")]
    public async Task<ActionResult<PagedList<GetPostDto>>> GetPostsWithLikes([FromQuery] PostParams postParams, Guid userId)
    {
        var paginatedPosts = await _postService.GetPostsWithLikesAsync(postParams, userId);
        
        Response.AddPaginationHeader(paginatedPosts);
        
        return Ok(paginatedPosts); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetSinglePostDto>> GetPost(Guid id)
    { 
        var postDtos = await _postService.GetPostAsync(id);
        return Ok(postDtos); 
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromForm] CreatePostDto postDto)
    {
        var post = await _postService.CreatePostAsync(postDto);
        return Created(string.Empty, post);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePost(Guid id, UpdatePostDto updatePostDto)
    {
        var updatePost = await _postService.UpdatePostAsync(id, updatePostDto);
        return Ok(updatePost);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var message = await _postService.DeletePostAsync(id);
        return Content(message); 
    }
  
}
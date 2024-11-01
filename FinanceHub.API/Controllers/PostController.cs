using FinanceGub.Application.DTOs.Post;
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
    public async Task<ActionResult<IEnumerable<GetPostDto>>> GetAllPost()
    {
        var postDtos = await _postService.GetAllPostAsync();
        return Ok(postDtos); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetPostDto>> GetPost(Guid id)
    { 
        var postDtos = await _postService.GetPostAsync(id);
        return Ok(postDtos); 
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(CreatePostDto postDto)
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
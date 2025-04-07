using FinanceGub.Application.DTOs.Comment;
using FinanceGub.Application.Interfaces.Serviсes;
using Microsoft.AspNetCore.Mvc;

namespace FinanceHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpGet]
    public async Task<ActionResult<GetCommentDto>> GetAllComments(Guid postId, int pageSize = 10, string filter = "newest",
        int pageNumber = 1)
    {
        var comments = await _commentService.GetCommentsPaginatedAsync(postId, pageNumber, pageSize, filter);
        return Ok(comments); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetCommentDto>> GetComment(Guid id)
    { 
        var commentDtos = await _commentService.GetCommentAsync(id);
        return Ok(commentDtos); 
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentDto commentDto)
    {
        var comment = await _commentService.CreateCommentAsync(commentDto);
        return Created(string.Empty, comment);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateComment(Guid id, UpdateCommentDto updateCommentDto)
    {
        var updateComment = await _commentService.UpdateCommentAsync(id, updateCommentDto);
        return Ok(updateComment);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var message = await _commentService.DeleteCommentAsync(id);
        return NoContent();
    }
}
using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.Comment;

public class CreateCommentDto
{
    [Required(ErrorMessage = "PostId is required.")]
    public Guid PostId { get; set; }
    
    [Required(ErrorMessage = "AuthorId is required.")]
    public Guid AuthorId { get; set; }
    
    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; }
    
    public Guid? ParentId { get; set; }
}
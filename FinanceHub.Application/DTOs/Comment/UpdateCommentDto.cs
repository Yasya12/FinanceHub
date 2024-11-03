using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.Comment;

public class UpdateCommentDto
{
    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; }
    
    public bool IsModified { get; set; } = true;
}
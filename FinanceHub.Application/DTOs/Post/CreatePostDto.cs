using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.Post;

public class CreatePostDto
{
    [Required]
    public string Email { get; set; }

    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.Post;

public class CreatePostDto
{
    [Required(ErrorMessage = "User Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string UserEmail { get; set; }
    public IEnumerable<string>? CategoryNames { get; set; }

    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.Post;

public class UpdatePostDto
{
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }
    public IEnumerable<string>? CategoryNames { get; set; }

    [Required]
    public string Content { get; set; }
}
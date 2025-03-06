using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.Post;

public class UpdatePostDto
{
    public IEnumerable<string>? CategoryNames { get; set; }

    [Required]
    public string Content { get; set; }
}
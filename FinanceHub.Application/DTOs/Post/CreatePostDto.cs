using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FinanceGub.Application.DTOs.Post;

public class CreatePostDto
{
    [Required(ErrorMessage = "User Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string UserEmail { get; set; }
    public IEnumerable<string>? CategoryNames { get; set; }

    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; }
    public IEnumerable<IFormFile>? Images { get; set; }

}
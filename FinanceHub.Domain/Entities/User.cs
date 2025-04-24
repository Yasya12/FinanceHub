using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class User : Base
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    public required string Username { get; set; }

    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public required string Email { get; set; }

    public string? PasswordHash { get; set; }
    public string Role { get; set; } = "user";
    
    public string? GoogleId { get; set; }
    
    [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
    public string? Country { get; set; }

    [Url(ErrorMessage = "Invalid URL format for profile picture.")]
    public string? ProfilePictureUrl { get; set; }

    [StringLength(500, ErrorMessage = "Bio cannot be longer than 500 characters.")]
    public string? Bio { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime LastActive { get; set; }

    public List<Message> MessagesSent { get; set; } = [];
    public List<Message> MessagesReceived { get; set; } = [];
}
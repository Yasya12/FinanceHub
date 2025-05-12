using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FinanceHub.Core.Entities;

public class User : IdentityUser<Guid>
{
    // public string Role { get; set; } = "user";
    
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

    public ICollection<AppUserRole> UserRoles { get; set; } = [];
    
    public ICollection<HubMember> HubMemberships { get; set; } = [];
}
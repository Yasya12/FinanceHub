using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceHub.Core.Entities;

public class User : Base
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    public string Username { get; set; }
    
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public required string Email { get; set; }
    
    //[Required]
    //becayse with google there are no passsword, but i have dto for creating + front and it will chech for password without google
    public string? PasswordHash { get; set; }
    public string Role { get; set; }
    
    public string? GoogleId { get; set; }
    [JsonIgnore]
    public virtual Profile? Profile { get; set; }
    //public virtual ICollection<Post> Posts { get; set; }

    public List<Message> MessagesSent { get; set; } = [];
    public List<Message> MessagesReceived { get; set; } = [];

}
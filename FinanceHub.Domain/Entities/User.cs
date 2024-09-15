using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(20, MinimumLength = 3)]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    public string Username { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }
    //public virtual Profile Profile { get; set; }
    //public virtual ICollection<Post> Posts { get; set; }

}
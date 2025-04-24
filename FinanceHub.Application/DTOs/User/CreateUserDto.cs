using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.User;

public class CreateUserDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    // [Required]
    // [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
    // [MaxLength(100, ErrorMessage = "Password must be at most 100 characters long.")]
    // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
    //     ErrorMessage =
    //         "Password must have at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3)]
    [RegularExpression(@"^[a-zA-Z0-9_]+$",
        ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    public string Username { get; set; }

    [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
    public string? Country { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? DateOfBirth { get; set; }
    
    public string? Bio { get; set; }
}
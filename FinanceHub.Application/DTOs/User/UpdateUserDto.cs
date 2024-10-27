using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.User;

public class UpdateUserDto
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    [Required]
    [StringLength(20, MinimumLength = 3)]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Country is required.")]
    [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
    public string Country { get; set; }
    
    [Required(ErrorMessage = "Date of Birth is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime DateOfBirth { get; set; }
}
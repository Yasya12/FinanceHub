using System.ComponentModel.DataAnnotations;

namespace FinanceGub.Application.DTOs.Profile;

public class UpdateProfileDto
{
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Country is required.")]
    [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
    public string Country { get; set; }

    [Url(ErrorMessage = "Invalid URL format for profile picture.")]
    public string? ProfilePictureUrl { get; set; }

    [StringLength(500, ErrorMessage = "Bio cannot be longer than 500 characters.")]
    public string? Bio { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime DateOfBirth { get; set; }
}
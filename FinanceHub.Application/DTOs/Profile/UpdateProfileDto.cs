using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FinanceGub.Application.DTOs.Profile;

public class UpdateProfileDto
{
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string? PhoneNumber { get; set; }

    [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
    public string? Country { get; set; }

    public IFormFile? ProfilePictureUrl { get; set; }

    [StringLength(500, ErrorMessage = "Bio cannot be longer than 500 characters.")]
    public string? Bio { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? DateOfBirth { get; set; }
}
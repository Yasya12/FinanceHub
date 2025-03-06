using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class Profile : Base
{
    [Required(ErrorMessage = "User ID is required.")]
    public Guid UserId { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string? PhoneNumber { get; set; }

    [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
    public string? Country { get; set; }

    [Url(ErrorMessage = "Invalid URL format for profile picture.")]
    public string? ProfilePictureUrl { get; set; }

    [StringLength(500, ErrorMessage = "Bio cannot be longer than 500 characters.")]
    public string? Bio { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
    public DateTime? DateOfBirth { get; set; }

    public virtual User User { get; set; }
    //public virtual ICollection<Interest> Interests { get; set; }
}
namespace FinanceGub.Application.DTOs.Profile;

public class GetProfileDto
{
    public string UserName { get; set; }
    public string Email { get; set; }

    public string Country { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? Bio { get; set; }

    public DateTime DateOfBirth { get; set; }
}
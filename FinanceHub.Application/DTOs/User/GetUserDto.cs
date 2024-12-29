namespace FinanceGub.Application.DTOs.User;

public class GetUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public string? ProfilePictureUrl { get; set; }
}
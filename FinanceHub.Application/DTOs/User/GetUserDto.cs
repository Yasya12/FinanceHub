namespace FinanceGub.Application.DTOs.User;

public class GetUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public string? ProfilePictureUrl { get; set; }
    
    public string? Country { get; set; }

    public string? Bio { get; set; }
    public int FollowingCount { get; set; } = 0;
    public int FolowersCount { get; set; } = 0;
    public int PostsCount { get; set; } = 0;

    public DateTime CreatedAt { get; set; }
    public DateTime LastActive { get; set; }
}
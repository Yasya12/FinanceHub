namespace FinanceGub.Application.DTOs.Following;

public class GetFollowingUserDto
{
    public Guid FollowingId { get; set; }
    public string ProfilePhoroUrl { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public bool IsFollowedByCurrentUser { get; set; }
    public bool IsUser { get; set; }
    
}
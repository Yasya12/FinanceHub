namespace FinanceGub.Application.DTOs.Post;

public class GetPostDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public IEnumerable<string> CategoryNames { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }   
    public int CommentsCount { get; set; } 
    public int LikesCount { get; set; }
    
    public bool IsLiked { get; set; }
    public string HubName { get; set; }
    
    public IEnumerable<string?> Images { get; set; } 
}
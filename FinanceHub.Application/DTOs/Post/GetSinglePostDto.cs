using FinanceGub.Application.DTOs.Comment;

namespace FinanceGub.Application.DTOs.Post;

public class GetSinglePostDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public IEnumerable<string> CategoryNames { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }   
    public IEnumerable<GetCommentDto> Comments { get; set; }
    public int LikesCount { get; set; }
    public List<string> Images { get; set; } 
}
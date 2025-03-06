namespace FinanceGub.Application.DTOs.Comment;

public class GetCommentDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public string AuthorName { get; set; }
    public string ProfilePictureUrl { get; set; }
    
    public Guid? ParentId { get; set; }
}
namespace FinanceGub.Application.DTOs.Post;

public class GetPostDto
{
    public string UserName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}
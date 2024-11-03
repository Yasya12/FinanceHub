namespace FinanceHub.Core.Entities;

public class Comment : Base
{
    public Guid PostId { get; set; }
    public Guid AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsModified { get; set; }
    public virtual Post Post { get; set; }
    public virtual User Author { get; set; }

}
using System.Text.Json.Serialization;

namespace FinanceHub.Core.Entities;

public class Comment : Base
{
    public Guid PostId { get; set; }
    public Guid AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsModified { get; set; }
    
    public Guid? ParentCommentId { get; set; }
    
    [JsonIgnore]
    public virtual Comment ParentComment { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Comment> Replies { get; set; }

    [JsonIgnore]
    public virtual Post Post { get; set; }
    
    [JsonIgnore]
    public virtual User Author { get; set; }

    public Comment()
    {
        Replies = new List<Comment>();
    }
}
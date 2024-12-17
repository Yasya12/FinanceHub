using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class Post : Base
{
    [Required]
    public Guid AuthorId { get; set; }

    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }

    [Required]
    public virtual User Author { get; set; }
    public virtual ICollection<PostCategory> PostCategory { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
}
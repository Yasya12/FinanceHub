using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class Category : Base
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string Name { get; set; }

    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
    public string Description { get; set; }

    public virtual ICollection<PostCategory> PostCategory  { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinanceHub.Core.Entities;

public class Like : Base
{
    [Required(ErrorMessage = "UserId is required.")]
    public Guid UserId { get; set; } 
    
    [Required(ErrorMessage = "PostId is required.")]
    public Guid PostId { get; set; }  
    [JsonIgnore]
    public virtual User User { get; set; }
    [JsonIgnore]
    public virtual Post Post { get; set; }
}
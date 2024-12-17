using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class Message : Base
{
    [Required]
    public Guid ChatId { get; set; }
        
    [Required]
    public Guid SenderId { get; set; }
        
    [Required]
    public string Content { get; set; }
        
    [Required]
    public DateTime SentAt { get; set; }

    public virtual Chat Chat { get; set; }
    public virtual User Sender { get; set; }
}
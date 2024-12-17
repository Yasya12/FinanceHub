using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class ChatParticipant : Base
{
    [Required]
    public Guid ChatId { get; set; }
        
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public DateTime JoinedAt { get; set; }

    public virtual Chat Chat { get; set; }
    public virtual User User { get; set; }
}
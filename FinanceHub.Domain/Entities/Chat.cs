using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class Chat : Base
{
    [Required]
    public DateTime CreatedAt { get; set; }
        
    public virtual ICollection<ChatParticipant> Participants { get; set; } = new List<ChatParticipant>();
    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
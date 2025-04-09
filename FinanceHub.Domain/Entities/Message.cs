using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class Message : Base
{
    public required string SenderUserName { get; set; }
    public required string RecipientUserName { get; set; }
    public required string Content { get; set; }
    public DateTime? DateRead { get; set; }
    public DateTime MessageSent { get; set; } = DateTime.Now;
    public bool SenderDeleted { get; set; }
    public bool RecipientDeleted { get; set; }

    //navigation properties 
    public Guid SenderId { get; set; }
    public User Sender { get; set; } = null!;
    public Guid RecipientId { get; set; }
    public User Recipient { get; set; } = null!;
}
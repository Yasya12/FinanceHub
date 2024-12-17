using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class Subscription : Base
{
    [Required]
    public Guid SubscriberId { get; set; } 

    [Required]
    public Guid SubscribedToId { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public virtual User Subscriber { get; set; }
    public virtual User SubscribedTo { get; set; }
}
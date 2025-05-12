namespace FinanceHub.Core.Entities
{
    public class HubJoinRequest : Base
    {
        // FK to Hub
        public Guid HubId { get; set; }
        public Hub Hub { get; set; }

        // FK to User
        public Guid UserId { get; set; }
        public User User { get; set; }

        // Status: Pending, Approved, Denied
        public string Status { get; set; } = "Pending";  // Default status is "Pending"
        
        public string Content { get; set; }
        public string? Description { get; set; }

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    }
}

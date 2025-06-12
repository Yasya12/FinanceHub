namespace FinanceHub.Core.Entities;

public class Following : Base
{
    public Guid FollowerId { get; set; }    // Той, хто підписується
    public User FollowergUser { get; set; }  
    public Guid? FollowingUserId { get; set; }   // Той, на кого підписуються user
    public User FollowingUser { get; set; }  
    
    public Guid? FollowingHubId { get; set; }   // Той, на кого підписуються hub
    public Hub FollowingHub { get; set; }  
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

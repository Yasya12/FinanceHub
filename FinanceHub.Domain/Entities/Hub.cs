namespace FinanceHub.Core.Entities;

public class Hub : Base
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? MainPhotoUrl { get; set; }
    public string? BackgroundPhotoUrl { get; set; }

    // Permission: “public”, “members”, “moderated”—for future use
    public string PostPermission { get; set; } = "public";

    public ICollection<Post> Posts { get; set; }
    public ICollection<HubMember> Members { get; set; } = [];
}

using System.Text.Json.Serialization;

namespace FinanceHub.Core.Entities;

public class PostImage: Base
{
    public Guid PostId { get; set; }
    public string? ImageUrl { get; set; }
    [JsonIgnore]
    public virtual Post Post { get; set; }
}
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FinanceHub.Core.Entities;

public class Group
{
    [Key]
    public required string Name { get; set; }

    public ICollection<Connection> Collections { get; set; } = [];
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceHub.Core.Entities;

public class Base
{
    [Key]
    public Guid Id { get; set; }
}

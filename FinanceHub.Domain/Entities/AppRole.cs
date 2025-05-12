using Microsoft.AspNetCore.Identity;

namespace FinanceHub.Core.Entities;

public class AppRole : IdentityRole<Guid>
{
    public ICollection<AppUserRole> UserRoles { get; set; } = [];
}
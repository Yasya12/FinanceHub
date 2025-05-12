using Microsoft.AspNetCore.Identity;

namespace FinanceHub.Core.Entities;

public class AppUserRole : IdentityUserRole<Guid>
{
    public User User { get; set; } = null!;
    public AppRole Role { get; set; } = null!;
}
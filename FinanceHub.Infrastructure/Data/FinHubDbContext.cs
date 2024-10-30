using FinanceHub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Data;

public class FinHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Post> Posts { get; set; }
    public FinHubDbContext(DbContextOptions<FinHubDbContext> options):base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue(FinanceGub.Application.Identity.IdentityData.UserUserClaimName); 

        modelBuilder.Seed();
    }
}
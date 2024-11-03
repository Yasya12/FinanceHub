using FinanceHub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Data;

public class FinHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public FinHubDbContext(DbContextOptions<FinHubDbContext> options):base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasDefaultValue(FinanceGub.Application.Identity.IdentityData.UserUserClaimName); 
        
        modelBuilder.Entity<PostCategory>()
            .HasKey(pc => new { pc.PostId, pc.CategoryId });

        modelBuilder.Entity<PostCategory>()
            .HasOne(pc => pc.Post)
            .WithMany(p => p.PostCategory)
            .HasForeignKey(pc => pc.PostId);

        modelBuilder.Entity<PostCategory>()
            .HasOne(pc => pc.Category)
            .WithMany(c => c.PostCategory)
            .HasForeignKey(pc => pc.CategoryId);
        
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany() 
            .HasForeignKey(c => c.AuthorId);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments) 
            .HasForeignKey(c => c.PostId);

        modelBuilder.Seed();
    }
}
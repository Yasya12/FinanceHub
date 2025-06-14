using FinanceHub.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace FinanceHub.Infrastructure.Data;

public class FinHubDbContext(DbContextOptions<FinHubDbContext> options)
    : IdentityDbContext<User, AppRole, Guid, IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatParticipant> ChatParticipants { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<PostImage> PostImages { get; set; }
    public DbSet<Hub> Hubs { get; set; }
    public DbSet<HubMember> HubMembers { get; set; }
    public DbSet<HubJoinRequest> HubJoinRequests { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Following> Followings { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Connection> Connections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToTable("Users");
        
        modelBuilder.Entity<Following>()
            .HasOne(f => f.FollowergUser)
            .WithMany()
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);  // Або .Cascade в залежності від логіки

        modelBuilder.Entity<Following>()
            .HasOne(f => f.FollowingUser)
            .WithMany()
            .HasForeignKey(f => f.FollowingUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Following>()
            .HasOne(f => f.FollowingHub)
            .WithMany()
            .HasForeignKey(f => f.FollowingHubId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User) // Користувач, який отримує нотифікацію
            .WithMany() // Це може бути зворотний зв'язок, якщо потрібно
            .HasForeignKey(n => n.UserId);  // Вказуємо, що для цього зв'язку зовнішній ключ — це UserId

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.TriggeredByUser)  // Користувач, який тригернув нотифікацію
            .WithMany()  // Це може бути зворотний зв'язок, якщо потрібно
            .HasForeignKey(n => n.TriggeredBy)  // Вказуємо, що для цього зв'язку зовнішній ключ — це TriggeredBy
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<HubMember>()
            .HasIndex(m => new { m.HubId, m.UserId }) // Ensure one user per hub
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        
        modelBuilder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        // modelBuilder.Entity<User>()
        //     .Property(u => u.Role)
        //     .HasDefaultValue(FinanceGub.Application.Identity.IdentityData.UserUserClaimName);

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

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PostImage>()
            .HasOne(p => p.Post)
            .WithMany(b => b.PostImages)
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(x => x.Recipient)
            .WithMany(x => x.MessagesReceived)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne(x => x.Sender)
            .WithMany(x => x.MessagesSent)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Hub>()
            .HasMany(h => h.Posts)
            .WithOne(p => p.Hub)
            .HasForeignKey(p => p.HubId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Seed();
    }
}
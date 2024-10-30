using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Define fixed Guids for users
        var user1Id = Guid.NewGuid(); 
        var user2Id = Guid.NewGuid();
        
        // Seed data for Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = user1Id,
                Username = "johndoe",
                Email = "johndoe@example.com",
                PasswordHash = PasswordHasher.HashPassword("hashedpassword"),
                Role = "User"
            },
            new User
            {
                Id = user2Id,
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = PasswordHasher.HashPassword("adminhashedpassword"),
                Role = "Admin"
            }
        );

        // Seed data for Profiles
        modelBuilder.Entity<Profile>().HasData(
            new Profile
            {
                Id = Guid.NewGuid(),
                UserId = user1Id, 
                PhoneNumber = "+1234567890",
                Country = "USA",
                CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                DateOfBirth =  DateTime.SpecifyKind(new DateTime(1990, 1, 1), DateTimeKind.Utc)
            },
            new Profile
            {
                Id = Guid.NewGuid(),
                UserId = user2Id, 
                PhoneNumber = "+9876543210",
                Country = "Canada",
                CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                DateOfBirth =  DateTime.SpecifyKind(new DateTime(2000, 10, 10), DateTimeKind.Utc)
            }
        );

        //Seed data for Post
        modelBuilder.Entity<Post>().HasData(
            new Post
            {
                Id = Guid.NewGuid(),
                AuthorId = user1Id,
                Title = "Introduction to Finance",
                Content = "This is an introductory post about finance.",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            },
            new Post
            {
                Id = Guid.NewGuid(),
                AuthorId = user2Id,
                Title = "Advanced Financial Strategies",
                Content = "Exploring advanced strategies in finance.",
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-2)
            });
    }
}
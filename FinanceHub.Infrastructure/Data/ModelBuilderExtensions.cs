using FinanceHub.Core.Entities;
using FinanceHub.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //User
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = PasswordHasher.HashPassword("hashed_password_1"),
                Role = "Admin" 
            },
            new User
            {
                Id = Guid.NewGuid(),
                Username = "user1",
                Email = "user1@example.com",
                PasswordHash = PasswordHasher.HashPassword("hashed_password_2"),
                Role = "User" 
            },
            new User
            {
                Id = Guid.NewGuid(),
                Username = "user2",
                Email = "user2@example.com",
                PasswordHash = PasswordHasher.HashPassword("hashed_password_3"),
                Role = "User" 
            }
        );
    }
}
using FinanceGub.Application.Helpers;
using FinanceHub.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceHub.Infrastructure.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Define fixed Guids for users
        var user1Id = Guid.NewGuid();
        var user2Id = Guid.NewGuid();
        var user3Id = Guid.NewGuid();
        // Define fixed Guids for posts
        var post1Id = Guid.NewGuid();
        var post2Id = Guid.NewGuid();
        // Define fixed Guids for categories
        var category1Id = Guid.NewGuid();
        var category2Id = Guid.NewGuid();
        var category3Id = Guid.NewGuid();
        // Define fixed Guids for comments
        var comment1Id = Guid.NewGuid();
        var comment2Id = Guid.NewGuid();
        var comment3Id = Guid.NewGuid();

        var roleAdminId = Guid.NewGuid();
        var roleUserId = Guid.NewGuid();
        var roleModeratorId = Guid.NewGuid();

        modelBuilder.Entity<AppRole>().HasData(
            new AppRole
            {
                Id = roleAdminId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new AppRole
            {
                Id = roleUserId,
                Name = "Member",
                NormalizedName = "MEMBER"
            },
            new AppRole
            {
                Id = roleModeratorId,
                Name = "Moderator",
                NormalizedName = "MODERATOR"
            }
        );
        
        modelBuilder.Entity<AppUserRole>().HasData(
            new AppUserRole
            {
                UserId = user1Id, // johndoe
                RoleId = roleUserId
            },
            new AppUserRole
            {
                UserId = user2Id, // admin
                RoleId = roleAdminId
            },
            new AppUserRole
            {
                UserId = user3Id, // admin
                RoleId = roleUserId
            }
        );



        // Seed data for Users
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = user1Id,
                UserName = "johndoe",
                Email = "johndoe@example.com",
                PasswordHash = PasswordHasher.HashPassword("hashedpassword"),
                //Role = "User",
                Country = "Ukraine"
            },
            new User
            {
                Id = user3Id,
                UserName = "Lisa",
                Email = "lisa@1",
                PasswordHash = PasswordHasher.HashPassword("1"),
                // Role = "User",
                Country = "Ukraine",
                Bio =
                    "Passionate about smart money management and personal growth. Tracking goals, budgeting wisely, and always learning something new about finance."
            },
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "tod",
                Email = "tod@1",
                PasswordHash = PasswordHasher.HashPassword("1"),
                Country = "Ukraine",
                Bio =
                    "Very cool investor."
            },
            new User
            {
                Id = user2Id,
                UserName = "admin",
                Email = "admin@example.com",
                PasswordHash = PasswordHasher.HashPassword("adminhashedpassword"),
                // Role = "Admin",
                Country = "England"
            }
        );

        // Seed data for Profiles
        // modelBuilder.Entity<Profile>().HasData(
        //     new Profile
        //     {
        //         Id = Guid.NewGuid(),
        //         UserId = user1Id, 
        //         PhoneNumber = "+1234567890",
        //         Country = "USA",
        //         CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //         UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //         DateOfBirth =  DateTime.SpecifyKind(new DateTime(1990, 1, 1), DateTimeKind.Utc)
        //     },
        //     new Profile
        //     {
        //         Id = Guid.NewGuid(),
        //         UserId = user2Id, 
        //         PhoneNumber = "+9876543210",
        //         Country = "Canada",
        //         CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //         UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
        //         DateOfBirth =  DateTime.SpecifyKind(new DateTime(2000, 10, 10), DateTimeKind.Utc)
        //     }
        // );

        //Seed data for Post
        modelBuilder.Entity<Post>().HasData(
            new Post
            {
                Id = post1Id,
                AuthorId = user1Id,
                Content = "This is an introductory post about finance.",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddDays(-5),
            },
            new Post
            {
                Id = post2Id,
                AuthorId = user2Id,
                Content = "Exploring advanced strategies in finance.",
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-2)
            });

        //Seed data for Category
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = category1Id,
                Name = "Technology",
                Description = "Posts related to the latest technology trends"
            },
            new Category
            {
                Id = category2Id,
                Name = "Health",
                Description = "Health tips and news"
            },
            new Category
            {
                Id = category3Id,
                Name = "Education",
                Description = "Educational articles and resources"
            }
        );

        //Seed data for PostCategory
        modelBuilder.Entity<PostCategory>().HasData(
            new PostCategory
            {
                PostId = post1Id,
                CategoryId = category1Id
            },
            new PostCategory
            {
                PostId = post1Id,
                CategoryId = category3Id
            },
            new PostCategory
            {
                PostId = post2Id,
                CategoryId = category2Id
            },
            new PostCategory
            {
                PostId = post2Id,
                CategoryId = category3Id
            });

        // Seed data for Comments
        modelBuilder.Entity<Comment>().HasData(
            new Comment
            {
                Id = comment1Id,
                PostId = post1Id,
                AuthorId = user1Id,
                Content = "Great introduction! Looking forward to learning more.",
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                IsModified = false,
                ParentId = null
            },
            new Comment
            {
                Id = comment2Id,
                PostId = post1Id,
                AuthorId = user2Id,
                Content = "Interesting perspective on finance.",
                CreatedAt = DateTime.UtcNow.AddDays(-4),
                IsModified = false,
                ParentId = null
            },
            new Comment
            {
                Id = comment3Id,
                PostId = post2Id,
                AuthorId = user1Id,
                Content = "I found this article very helpful!",
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                IsModified = false,
                ParentId = null
            }
        );

        modelBuilder.Entity<Like>().HasData(
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = user1Id,
                PostId = post1Id
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = user2Id,
                PostId = post1Id
            },
            new Like
            {
                Id = Guid.NewGuid(),
                UserId = user1Id,
                PostId = post2Id
            }
        );

        modelBuilder.Entity<Hub>().HasData(
            new Hub
            {
                Id = Guid.NewGuid(),
                Name = "Budgeting",
                Description = "Tips on managing money, saving, and budgeting.",
                PostPermission = "public"
            },
            new Hub
            {
                Id = Guid.NewGuid(),
                Name = "Crypto",
                Description = "News and trends in crypto and blockchain.",
                PostPermission = "public"
            },
            new Hub
            {
                Id = Guid.NewGuid(),
                Name = "Stocks",
                Description = "Market updates, analysis, and stock picks.",
                PostPermission = "public"
            },
            new Hub
            {
                Id = Guid.NewGuid(),
                Name = "FI/RE",
                Description = "Financial independence and early retirement.",
                PostPermission = "members"
            },
            new Hub
            {
                Id = Guid.NewGuid(),
                Name = "Side Hustles",
                Description = "Ideas and stories on earning extra income.",
                PostPermission = "members"
            },
            new Hub
            {
                Id = Guid.NewGuid(),
                Name = "Real Estate",
                Description = "Investing in properties and REITs.",
                PostPermission = "moderated"
            },
            new Hub
            {
                Id = Guid.NewGuid(),
                Name = "Mindset",
                Description = "Money habits and financial motivation.",
                PostPermission = "public"
            },
            new Hub
            {
                Id = Guid.NewGuid(),
                Name = "Finance News",
                Description = "Latest updates from the world of finance.",
                PostPermission = "moderated"
            }
        );
    }
}
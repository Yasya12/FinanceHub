﻿// <auto-generated />
using System;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceHub.Infrastructure.Migrations
{
    [DbContext(typeof(FinHubDbContext))]
    partial class FinHubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinanceHub.Core.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("43c530df-4c7f-4fef-9982-1d183217d147"),
                            Description = "Posts related to the latest technology trends",
                            Name = "Technology"
                        },
                        new
                        {
                            Id = new Guid("22f08db8-47cb-4f5c-a4cb-70b1d72bd0de"),
                            Description = "Health tips and news",
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830"),
                            Description = "Educational articles and resources",
                            Name = "Education"
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d"),
                            AuthorId = new Guid("c7b3e8fe-2518-4593-b3d4-5a7508a6f115"),
                            Content = "This is an introductory post about finance.",
                            CreatedAt = new DateTime(2024, 10, 21, 16, 5, 35, 620, DateTimeKind.Utc).AddTicks(25),
                            Title = "Introduction to Finance",
                            UpdatedAt = new DateTime(2024, 10, 26, 16, 5, 35, 620, DateTimeKind.Utc).AddTicks(53)
                        },
                        new
                        {
                            Id = new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe"),
                            AuthorId = new Guid("b300c149-3b45-41a6-8587-ae8a824316f5"),
                            Content = "Exploring advanced strategies in finance.",
                            CreatedAt = new DateTime(2024, 10, 11, 16, 5, 35, 620, DateTimeKind.Utc).AddTicks(55),
                            Title = "Advanced Financial Strategies",
                            UpdatedAt = new DateTime(2024, 10, 29, 16, 5, 35, 620, DateTimeKind.Utc).AddTicks(55)
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.PostCategory", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("PostId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PostCategories");

                    b.HasData(
                        new
                        {
                            PostId = new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d"),
                            CategoryId = new Guid("43c530df-4c7f-4fef-9982-1d183217d147")
                        },
                        new
                        {
                            PostId = new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d"),
                            CategoryId = new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830")
                        },
                        new
                        {
                            PostId = new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe"),
                            CategoryId = new Guid("22f08db8-47cb-4f5c-a4cb-70b1d72bd0de")
                        },
                        new
                        {
                            PostId = new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe"),
                            CategoryId = new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830")
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bio")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a142267c-6733-4816-9eab-f071c7ba34c8"),
                            Country = "USA",
                            CreatedAt = new DateTime(2024, 10, 31, 16, 5, 35, 619, DateTimeKind.Utc).AddTicks(9982),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+1234567890",
                            UpdatedAt = new DateTime(2024, 10, 31, 16, 5, 35, 619, DateTimeKind.Utc).AddTicks(9986),
                            UserId = new Guid("c7b3e8fe-2518-4593-b3d4-5a7508a6f115")
                        },
                        new
                        {
                            Id = new Guid("a63b0711-abec-416c-805c-117ed65cea9f"),
                            Country = "Canada",
                            CreatedAt = new DateTime(2024, 10, 31, 16, 5, 35, 619, DateTimeKind.Utc).AddTicks(9992),
                            DateOfBirth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+9876543210",
                            UpdatedAt = new DateTime(2024, 10, 31, 16, 5, 35, 619, DateTimeKind.Utc).AddTicks(9992),
                            UserId = new Guid("b300c149-3b45-41a6-8587-ae8a824316f5")
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("user");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c7b3e8fe-2518-4593-b3d4-5a7508a6f115"),
                            Email = "johndoe@example.com",
                            PasswordHash = "$2a$11$pxzKJDx2lxVbuGe3UuMig.1bYWjN43PkLyMCIAGkzG4K2YX/uyMJi",
                            Role = "User",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = new Guid("b300c149-3b45-41a6-8587-ae8a824316f5"),
                            Email = "admin@example.com",
                            PasswordHash = "$2a$11$Z.1Xs2e1Tolt3bFPMJrFq.2iUZYY.1f/bJdPbpyyfUVieA9kwLJQ.",
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Post", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.PostCategory", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.Category", "Category")
                        .WithMany("PostCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceHub.Core.Entities.Post", "Post")
                        .WithMany("PostCategory")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Profile", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("FinanceHub.Core.Entities.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Category", b =>
                {
                    b.Navigation("PostCategory");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Post", b =>
                {
                    b.Navigation("PostCategory");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.User", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}

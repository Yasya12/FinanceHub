﻿// <auto-generated />
using System;
using FinanceHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceHub.Infrastructure.Migrations
{
    [DbContext(typeof(FinHubDbContext))]
    [Migration("20241103164459_UpdateCommentRel")]
    partial class UpdateCommentRel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("a00555d7-d065-490e-88ce-92a9ad52987f"),
                            Description = "Posts related to the latest technology trends",
                            Name = "Technology"
                        },
                        new
                        {
                            Id = new Guid("60734545-fb55-499e-b466-cd2edda92b06"),
                            Description = "Health tips and news",
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b"),
                            Description = "Educational articles and resources",
                            Name = "Education"
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Comment", b =>
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

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("758d81c3-6b11-49e7-82d4-314ef2b271d1"),
                            AuthorId = new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"),
                            Content = "Great introduction! Looking forward to learning more.",
                            CreatedAt = new DateTime(2024, 10, 29, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(2127),
                            IsModified = false,
                            PostId = new Guid("d475a21b-d8d0-4f99-b458-30d865851b21")
                        },
                        new
                        {
                            Id = new Guid("585b6b36-8f91-4970-9f4c-b1a6930667af"),
                            AuthorId = new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551"),
                            Content = "Interesting perspective on finance.",
                            CreatedAt = new DateTime(2024, 10, 30, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(2128),
                            IsModified = false,
                            PostId = new Guid("d475a21b-d8d0-4f99-b458-30d865851b21")
                        },
                        new
                        {
                            Id = new Guid("e251bf26-0f12-4187-bb6c-533bbb11f210"),
                            AuthorId = new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"),
                            Content = "I found this article very helpful!",
                            CreatedAt = new DateTime(2024, 10, 31, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(2130),
                            IsModified = false,
                            PostId = new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8")
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
                            Id = new Guid("d475a21b-d8d0-4f99-b458-30d865851b21"),
                            AuthorId = new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"),
                            Content = "This is an introductory post about finance.",
                            CreatedAt = new DateTime(2024, 10, 24, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1978),
                            Title = "Introduction to Finance",
                            UpdatedAt = new DateTime(2024, 10, 29, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1996)
                        },
                        new
                        {
                            Id = new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8"),
                            AuthorId = new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551"),
                            Content = "Exploring advanced strategies in finance.",
                            CreatedAt = new DateTime(2024, 10, 14, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1997),
                            Title = "Advanced Financial Strategies",
                            UpdatedAt = new DateTime(2024, 11, 1, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1998)
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
                            PostId = new Guid("d475a21b-d8d0-4f99-b458-30d865851b21"),
                            CategoryId = new Guid("a00555d7-d065-490e-88ce-92a9ad52987f")
                        },
                        new
                        {
                            PostId = new Guid("d475a21b-d8d0-4f99-b458-30d865851b21"),
                            CategoryId = new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b")
                        },
                        new
                        {
                            PostId = new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8"),
                            CategoryId = new Guid("60734545-fb55-499e-b466-cd2edda92b06")
                        },
                        new
                        {
                            PostId = new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8"),
                            CategoryId = new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b")
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
                            Id = new Guid("4c4f8157-68db-4c65-a514-d7115c4557bb"),
                            Country = "USA",
                            CreatedAt = new DateTime(2024, 11, 3, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1893),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+1234567890",
                            UpdatedAt = new DateTime(2024, 11, 3, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1897),
                            UserId = new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b")
                        },
                        new
                        {
                            Id = new Guid("b8b8b100-8c77-4674-a650-ac3baa5e7b6b"),
                            Country = "Canada",
                            CreatedAt = new DateTime(2024, 11, 3, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1903),
                            DateOfBirth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+9876543210",
                            UpdatedAt = new DateTime(2024, 11, 3, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1904),
                            UserId = new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551")
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
                            Id = new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"),
                            Email = "johndoe@example.com",
                            PasswordHash = "$2a$11$U8wph2P96//rlF1X8g2n..BZ9eKJ2RBwaQXI4nz7.mefohJCx7FRu",
                            Role = "User",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551"),
                            Email = "admin@example.com",
                            PasswordHash = "$2a$11$MJ4xrYG8In4D8SdOU26La.zibbhZLvzu3KU1tSPW2v.RnNz4OYtYy",
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Comment", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceHub.Core.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Post");
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
                    b.Navigation("Comments");

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
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
    [Migration("20241208170703_AddNewEntities")]
    partial class AddNewEntities
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
                            Id = new Guid("981796df-9b65-4d86-ae7d-5810bd10b1b7"),
                            Description = "Posts related to the latest technology trends",
                            Name = "Technology"
                        },
                        new
                        {
                            Id = new Guid("26cda588-7e99-4d90-9a13-e704bc891b18"),
                            Description = "Health tips and news",
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba"),
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
                            Id = new Guid("3ddfae8a-abae-4270-9de8-44cb4c91531c"),
                            AuthorId = new Guid("2350f49a-e51f-4623-953f-3692c6186b95"),
                            Content = "Great introduction! Looking forward to learning more.",
                            CreatedAt = new DateTime(2024, 12, 3, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9294),
                            IsModified = false,
                            PostId = new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8")
                        },
                        new
                        {
                            Id = new Guid("3b7aef6a-94a2-42f6-a001-a1f46005ae3e"),
                            AuthorId = new Guid("ba0df017-3298-4113-988c-9bc5b709776c"),
                            Content = "Interesting perspective on finance.",
                            CreatedAt = new DateTime(2024, 12, 4, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9296),
                            IsModified = false,
                            PostId = new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8")
                        },
                        new
                        {
                            Id = new Guid("7c6c3839-3ad2-4348-816f-a0bbc1fcfdc0"),
                            AuthorId = new Guid("2350f49a-e51f-4623-953f-3692c6186b95"),
                            Content = "I found this article very helpful!",
                            CreatedAt = new DateTime(2024, 12, 5, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9297),
                            IsModified = false,
                            PostId = new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6")
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5c676bad-abd2-4e06-ac04-7322d01f278e"),
                            PostId = new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"),
                            UserId = new Guid("2350f49a-e51f-4623-953f-3692c6186b95")
                        },
                        new
                        {
                            Id = new Guid("338f6be7-2ddc-45ef-a172-0635f0deba89"),
                            PostId = new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"),
                            UserId = new Guid("ba0df017-3298-4113-988c-9bc5b709776c")
                        },
                        new
                        {
                            Id = new Guid("284c1429-9340-468c-98dd-654fc83b8d2b"),
                            PostId = new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6"),
                            UserId = new Guid("2350f49a-e51f-4623-953f-3692c6186b95")
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
                            Id = new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"),
                            AuthorId = new Guid("2350f49a-e51f-4623-953f-3692c6186b95"),
                            Content = "This is an introductory post about finance.",
                            CreatedAt = new DateTime(2024, 11, 28, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9145),
                            Title = "Introduction to Finance",
                            UpdatedAt = new DateTime(2024, 12, 3, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9158)
                        },
                        new
                        {
                            Id = new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6"),
                            AuthorId = new Guid("ba0df017-3298-4113-988c-9bc5b709776c"),
                            Content = "Exploring advanced strategies in finance.",
                            CreatedAt = new DateTime(2024, 11, 18, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9159),
                            Title = "Advanced Financial Strategies",
                            UpdatedAt = new DateTime(2024, 12, 6, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9160)
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
                            PostId = new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"),
                            CategoryId = new Guid("981796df-9b65-4d86-ae7d-5810bd10b1b7")
                        },
                        new
                        {
                            PostId = new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"),
                            CategoryId = new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba")
                        },
                        new
                        {
                            PostId = new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6"),
                            CategoryId = new Guid("26cda588-7e99-4d90-9a13-e704bc891b18")
                        },
                        new
                        {
                            PostId = new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6"),
                            CategoryId = new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba")
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
                            Id = new Guid("dfdd9e73-1ae4-4c2c-b8df-6d51c65c93ca"),
                            Country = "USA",
                            CreatedAt = new DateTime(2024, 12, 8, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9104),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+1234567890",
                            UpdatedAt = new DateTime(2024, 12, 8, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9107),
                            UserId = new Guid("2350f49a-e51f-4623-953f-3692c6186b95")
                        },
                        new
                        {
                            Id = new Guid("a468340d-f683-4715-b565-b37bde86792d"),
                            Country = "Canada",
                            CreatedAt = new DateTime(2024, 12, 8, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9112),
                            DateOfBirth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+9876543210",
                            UpdatedAt = new DateTime(2024, 12, 8, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9113),
                            UserId = new Guid("ba0df017-3298-4113-988c-9bc5b709776c")
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

                    b.Property<string>("GoogleId")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
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
                            Id = new Guid("2350f49a-e51f-4623-953f-3692c6186b95"),
                            Email = "johndoe@example.com",
                            PasswordHash = "$2a$11$TmqPqDdjsorNj6fMiAgO7uodr1q0aq/35/dIKXdNZT3fC.HFSTOIa",
                            Role = "User",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = new Guid("ba0df017-3298-4113-988c-9bc5b709776c"),
                            Email = "admin@example.com",
                            PasswordHash = "$2a$11$wLBsNYEknmhSylTnEqzW7uCsm/pVHHEwKVSt8P46xXitel7dtrVKa",
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

            modelBuilder.Entity("FinanceHub.Core.Entities.Like", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceHub.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
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

                    b.Navigation("Likes");

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

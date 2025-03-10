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
    [Migration("20241202215015_AddUpdatePaswordUser1")]
    partial class AddUpdatePaswordUser1
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
                            Id = new Guid("8ac31ba7-8a58-4692-ae0a-cf02d6743574"),
                            Description = "Posts related to the latest technology trends",
                            Name = "Technology"
                        },
                        new
                        {
                            Id = new Guid("e25175a8-f9e9-41bc-864a-5eeea13c5860"),
                            Description = "Health tips and news",
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b"),
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
                            Id = new Guid("5e81fbc7-fd97-458d-95e0-87401a32879a"),
                            AuthorId = new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"),
                            Content = "Great introduction! Looking forward to learning more.",
                            CreatedAt = new DateTime(2024, 11, 27, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6518),
                            IsModified = false,
                            PostId = new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe")
                        },
                        new
                        {
                            Id = new Guid("c44b8658-6757-40f3-87e4-184d3fbd572b"),
                            AuthorId = new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c"),
                            Content = "Interesting perspective on finance.",
                            CreatedAt = new DateTime(2024, 11, 28, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6521),
                            IsModified = false,
                            PostId = new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe")
                        },
                        new
                        {
                            Id = new Guid("32689cf2-a423-41c9-8340-d0e4a05a8414"),
                            AuthorId = new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"),
                            Content = "I found this article very helpful!",
                            CreatedAt = new DateTime(2024, 11, 29, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6524),
                            IsModified = false,
                            PostId = new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d")
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
                            Id = new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe"),
                            AuthorId = new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"),
                            Content = "This is an introductory post about finance.",
                            CreatedAt = new DateTime(2024, 11, 22, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6326),
                            Title = "Introduction to Finance",
                            UpdatedAt = new DateTime(2024, 11, 27, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6340)
                        },
                        new
                        {
                            Id = new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d"),
                            AuthorId = new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c"),
                            Content = "Exploring advanced strategies in finance.",
                            CreatedAt = new DateTime(2024, 11, 12, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6343),
                            Title = "Advanced Financial Strategies",
                            UpdatedAt = new DateTime(2024, 11, 30, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6344)
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
                            PostId = new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe"),
                            CategoryId = new Guid("8ac31ba7-8a58-4692-ae0a-cf02d6743574")
                        },
                        new
                        {
                            PostId = new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe"),
                            CategoryId = new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b")
                        },
                        new
                        {
                            PostId = new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d"),
                            CategoryId = new Guid("e25175a8-f9e9-41bc-864a-5eeea13c5860")
                        },
                        new
                        {
                            PostId = new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d"),
                            CategoryId = new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b")
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
                            Id = new Guid("e44c3a89-380b-4d3c-a2de-3fe88c8b1196"),
                            Country = "USA",
                            CreatedAt = new DateTime(2024, 12, 2, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6235),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+1234567890",
                            UpdatedAt = new DateTime(2024, 12, 2, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6241),
                            UserId = new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27")
                        },
                        new
                        {
                            Id = new Guid("9558b8ca-1bc0-4c8d-be21-838885c5f275"),
                            Country = "Canada",
                            CreatedAt = new DateTime(2024, 12, 2, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6249),
                            DateOfBirth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+9876543210",
                            UpdatedAt = new DateTime(2024, 12, 2, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6252),
                            UserId = new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c")
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
                            Id = new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"),
                            Email = "johndoe@example.com",
                            PasswordHash = "$2a$11$1OgqRLlP414t//YYHJEl1u7Y82rX.PKbWUKIZ5Zi1pkXgE3O26jGm",
                            Role = "User",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c"),
                            Email = "admin@example.com",
                            PasswordHash = "$2a$11$vx76nutefJewLkSLttyhtujYrsyCahjJef9SbIc4ksoios6hKCofS",
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

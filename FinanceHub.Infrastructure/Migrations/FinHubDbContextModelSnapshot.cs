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
                            Id = new Guid("a04baf59-03dd-4b55-91ef-d87e06901021"),
                            Description = "Posts related to the latest technology trends",
                            Name = "Technology"
                        },
                        new
                        {
                            Id = new Guid("251fb8ef-235d-4f42-ac29-4dde0437e8b6"),
                            Description = "Health tips and news",
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546"),
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
                            Id = new Guid("b15380bf-73cb-4e75-b400-ff4a4d20dba5"),
                            AuthorId = new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"),
                            Content = "Great introduction! Looking forward to learning more.",
                            CreatedAt = new DateTime(2024, 10, 29, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7754),
                            IsModified = false,
                            PostId = new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d")
                        },
                        new
                        {
                            Id = new Guid("14c8d85b-b75c-45d8-891d-fe17b629b0c0"),
                            AuthorId = new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b"),
                            Content = "Interesting perspective on finance.",
                            CreatedAt = new DateTime(2024, 10, 30, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7756),
                            IsModified = false,
                            PostId = new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d")
                        },
                        new
                        {
                            Id = new Guid("e30d669e-c560-4538-a0bd-43d39c3a2a5d"),
                            AuthorId = new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"),
                            Content = "I found this article very helpful!",
                            CreatedAt = new DateTime(2024, 10, 31, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7758),
                            IsModified = false,
                            PostId = new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad")
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
                            Id = new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d"),
                            AuthorId = new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"),
                            Content = "This is an introductory post about finance.",
                            CreatedAt = new DateTime(2024, 10, 24, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7570),
                            Title = "Introduction to Finance",
                            UpdatedAt = new DateTime(2024, 10, 29, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7583)
                        },
                        new
                        {
                            Id = new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad"),
                            AuthorId = new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b"),
                            Content = "Exploring advanced strategies in finance.",
                            CreatedAt = new DateTime(2024, 10, 14, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7585),
                            Title = "Advanced Financial Strategies",
                            UpdatedAt = new DateTime(2024, 11, 1, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7586)
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
                            PostId = new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d"),
                            CategoryId = new Guid("a04baf59-03dd-4b55-91ef-d87e06901021")
                        },
                        new
                        {
                            PostId = new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d"),
                            CategoryId = new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546")
                        },
                        new
                        {
                            PostId = new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad"),
                            CategoryId = new Guid("251fb8ef-235d-4f42-ac29-4dde0437e8b6")
                        },
                        new
                        {
                            PostId = new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad"),
                            CategoryId = new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546")
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
                            Id = new Guid("68f6c132-1e45-4b5a-b874-8c558452aa9b"),
                            Country = "USA",
                            CreatedAt = new DateTime(2024, 11, 3, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7481),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+1234567890",
                            UpdatedAt = new DateTime(2024, 11, 3, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7488),
                            UserId = new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6")
                        },
                        new
                        {
                            Id = new Guid("f338fe07-8242-495c-bf3d-30e84e6d1d7d"),
                            Country = "Canada",
                            CreatedAt = new DateTime(2024, 11, 3, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7520),
                            DateOfBirth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+9876543210",
                            UpdatedAt = new DateTime(2024, 11, 3, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7521),
                            UserId = new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b")
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
                            Id = new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"),
                            Email = "johndoe@example.com",
                            PasswordHash = "$2a$11$mJPz98jGLn2fTy0X.uhvUeou0Pv51uAyH3TysCj6cTeAObPXv3Key",
                            Role = "User",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b"),
                            Email = "admin@example.com",
                            PasswordHash = "$2a$11$w9Ogbw7B8KEJYZ/KPZD6u.yFqSp01VRX7Mj8JPgxidwnGzF9TEN.G",
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

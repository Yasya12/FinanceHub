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
    [Migration("20241226202037_UpdateCommentEntity")]
    partial class UpdateCommentEntity
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
                            Id = new Guid("beaf595b-9f99-4c5f-ad86-3c21da3f3057"),
                            Description = "Posts related to the latest technology trends",
                            Name = "Technology"
                        },
                        new
                        {
                            Id = new Guid("c79d683a-38a5-458d-b6f8-8552a22776c9"),
                            Description = "Health tips and news",
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("238f046d-a13f-47b5-8283-1454610d480b"),
                            Description = "Educational articles and resources",
                            Name = "Education"
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.ChatParticipant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatParticipants");
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

                    b.Property<Guid?>("ParentCommentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("964dbe09-2a98-4f79-a815-38752a9a8cb1"),
                            AuthorId = new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"),
                            Content = "Great introduction! Looking forward to learning more.",
                            CreatedAt = new DateTime(2024, 12, 21, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(2145),
                            IsModified = false,
                            PostId = new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f")
                        },
                        new
                        {
                            Id = new Guid("bd18bf0b-6213-4272-b68d-734e21198671"),
                            AuthorId = new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1"),
                            Content = "Interesting perspective on finance.",
                            CreatedAt = new DateTime(2024, 12, 22, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(2147),
                            IsModified = false,
                            PostId = new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f")
                        },
                        new
                        {
                            Id = new Guid("5d3d7395-baf5-49f6-aace-c813831fee5d"),
                            AuthorId = new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"),
                            Content = "I found this article very helpful!",
                            CreatedAt = new DateTime(2024, 12, 23, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(2149),
                            IsModified = false,
                            PostId = new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3")
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
                            Id = new Guid("00fd0f1f-10d6-4c35-9d1d-f6d664c8d838"),
                            PostId = new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"),
                            UserId = new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3")
                        },
                        new
                        {
                            Id = new Guid("a9c355d9-e907-4a20-9186-34d6d952e9d3"),
                            PostId = new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"),
                            UserId = new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1")
                        },
                        new
                        {
                            Id = new Guid("f3c3f52f-19c3-43f1-aba5-2b1375efb546"),
                            PostId = new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3"),
                            UserId = new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3")
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
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
                            Id = new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"),
                            AuthorId = new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"),
                            Content = "This is an introductory post about finance.",
                            CreatedAt = new DateTime(2024, 12, 16, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1962),
                            Title = "Introduction to Finance",
                            UpdatedAt = new DateTime(2024, 12, 21, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1974)
                        },
                        new
                        {
                            Id = new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3"),
                            AuthorId = new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1"),
                            Content = "Exploring advanced strategies in finance.",
                            CreatedAt = new DateTime(2024, 12, 6, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1975),
                            Title = "Advanced Financial Strategies",
                            UpdatedAt = new DateTime(2024, 12, 24, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1976)
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
                            PostId = new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"),
                            CategoryId = new Guid("beaf595b-9f99-4c5f-ad86-3c21da3f3057")
                        },
                        new
                        {
                            PostId = new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"),
                            CategoryId = new Guid("238f046d-a13f-47b5-8283-1454610d480b")
                        },
                        new
                        {
                            PostId = new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3"),
                            CategoryId = new Guid("c79d683a-38a5-458d-b6f8-8552a22776c9")
                        },
                        new
                        {
                            PostId = new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3"),
                            CategoryId = new Guid("238f046d-a13f-47b5-8283-1454610d480b")
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
                            Id = new Guid("cae438b0-764a-4048-858f-bde9ac724012"),
                            Country = "USA",
                            CreatedAt = new DateTime(2024, 12, 26, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1915),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+1234567890",
                            UpdatedAt = new DateTime(2024, 12, 26, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1920),
                            UserId = new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3")
                        },
                        new
                        {
                            Id = new Guid("f6870b65-18fa-4c3e-8d38-3d75d29cb7b5"),
                            Country = "Canada",
                            CreatedAt = new DateTime(2024, 12, 26, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1926),
                            DateOfBirth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+9876543210",
                            UpdatedAt = new DateTime(2024, 12, 26, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1927),
                            UserId = new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1")
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SubscribedToId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubscriberId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SubscribedToId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("Subscriptions");
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
                            Id = new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"),
                            Email = "johndoe@example.com",
                            PasswordHash = "$2a$11$ehHI8/IdBp.EryAnY2zkmux.FzidGhyfmlPjp82HKMlOegUKGFIly",
                            Role = "User",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1"),
                            Email = "admin@example.com",
                            PasswordHash = "$2a$11$116HprAOPEUEWjktKQoTaONDlrJMimNX4ZD266/HVC5UyuVyPtM1a",
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.ChatParticipant", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.Chat", "Chat")
                        .WithMany("Participants")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceHub.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Comment", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceHub.Core.Entities.Comment", "ParentComment")
                        .WithMany("Replies")
                        .HasForeignKey("ParentCommentId");

                    b.HasOne("FinanceHub.Core.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("ParentComment");

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

            modelBuilder.Entity("FinanceHub.Core.Entities.Message", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceHub.Core.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Sender");
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

            modelBuilder.Entity("FinanceHub.Core.Entities.Subscription", b =>
                {
                    b.HasOne("FinanceHub.Core.Entities.User", "SubscribedTo")
                        .WithMany()
                        .HasForeignKey("SubscribedToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceHub.Core.Entities.User", "Subscriber")
                        .WithMany()
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscribedTo");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Category", b =>
                {
                    b.Navigation("PostCategory");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Chat", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("FinanceHub.Core.Entities.Comment", b =>
                {
                    b.Navigation("Replies");
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

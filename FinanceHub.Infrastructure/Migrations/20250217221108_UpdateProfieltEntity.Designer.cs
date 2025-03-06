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
    [Migration("20250217221108_UpdateProfieltEntity")]
    partial class UpdateProfieltEntity
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
                            Id = new Guid("ebb27798-ea30-473f-a8d4-eeed7db28b11"),
                            Description = "Posts related to the latest technology trends",
                            Name = "Technology"
                        },
                        new
                        {
                            Id = new Guid("55a43592-0128-4c9f-b2bd-baa69c7e3e9e"),
                            Description = "Health tips and news",
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2"),
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

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ParentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3b21bf8-eb49-4b56-ae9a-48f11e1e27f5"),
                            AuthorId = new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"),
                            Content = "Great introduction! Looking forward to learning more.",
                            CreatedAt = new DateTime(2025, 2, 12, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(8157),
                            IsModified = false,
                            PostId = new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b")
                        },
                        new
                        {
                            Id = new Guid("d14bd6bc-ff33-4e93-bd07-af661dd0ca9b"),
                            AuthorId = new Guid("d6fb4470-a205-49f2-b804-6200a92424d4"),
                            Content = "Interesting perspective on finance.",
                            CreatedAt = new DateTime(2025, 2, 13, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(8159),
                            IsModified = false,
                            PostId = new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b")
                        },
                        new
                        {
                            Id = new Guid("21b5dcca-2f23-49c0-b506-a1da0583cd91"),
                            AuthorId = new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"),
                            Content = "I found this article very helpful!",
                            CreatedAt = new DateTime(2025, 2, 14, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(8161),
                            IsModified = false,
                            PostId = new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e")
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
                            Id = new Guid("7dbbad8b-96ac-4ec5-9fa2-cf8c4a4e4fbd"),
                            PostId = new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"),
                            UserId = new Guid("7653fb83-d36d-4f24-98df-bce7ba718839")
                        },
                        new
                        {
                            Id = new Guid("12030011-8c9b-43ef-82fb-b95334081059"),
                            PostId = new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"),
                            UserId = new Guid("d6fb4470-a205-49f2-b804-6200a92424d4")
                        },
                        new
                        {
                            Id = new Guid("f774d138-9424-4e62-b945-60ac01bdb5b6"),
                            PostId = new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e"),
                            UserId = new Guid("7653fb83-d36d-4f24-98df-bce7ba718839")
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
                            Id = new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"),
                            AuthorId = new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"),
                            Content = "This is an introductory post about finance.",
                            CreatedAt = new DateTime(2025, 2, 7, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7974),
                            Title = "Introduction to Finance",
                            UpdatedAt = new DateTime(2025, 2, 12, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7984)
                        },
                        new
                        {
                            Id = new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e"),
                            AuthorId = new Guid("d6fb4470-a205-49f2-b804-6200a92424d4"),
                            Content = "Exploring advanced strategies in finance.",
                            CreatedAt = new DateTime(2025, 1, 28, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7985),
                            Title = "Advanced Financial Strategies",
                            UpdatedAt = new DateTime(2025, 2, 15, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7986)
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
                            PostId = new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"),
                            CategoryId = new Guid("ebb27798-ea30-473f-a8d4-eeed7db28b11")
                        },
                        new
                        {
                            PostId = new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"),
                            CategoryId = new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2")
                        },
                        new
                        {
                            PostId = new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e"),
                            CategoryId = new Guid("55a43592-0128-4c9f-b2bd-baa69c7e3e9e")
                        },
                        new
                        {
                            PostId = new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e"),
                            CategoryId = new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2")
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
                            Id = new Guid("f13f0bac-b611-48fd-92a3-d1c0d897b70f"),
                            Country = "USA",
                            CreatedAt = new DateTime(2025, 2, 17, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7926),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+1234567890",
                            UpdatedAt = new DateTime(2025, 2, 17, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7931),
                            UserId = new Guid("7653fb83-d36d-4f24-98df-bce7ba718839")
                        },
                        new
                        {
                            Id = new Guid("1ad8a52d-5010-476e-853c-a64df99e70ec"),
                            Country = "Canada",
                            CreatedAt = new DateTime(2025, 2, 17, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7937),
                            DateOfBirth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+9876543210",
                            UpdatedAt = new DateTime(2025, 2, 17, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7938),
                            UserId = new Guid("d6fb4470-a205-49f2-b804-6200a92424d4")
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
                            Id = new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"),
                            Email = "johndoe@example.com",
                            PasswordHash = "$2a$11$O2P0XXrinTQRraajmPTDr.OdQYe22hq8NIhM0HLPBK.alvfRsDFIG",
                            Role = "User",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = new Guid("d6fb4470-a205-49f2-b804-6200a92424d4"),
                            Email = "admin@example.com",
                            PasswordHash = "$2a$11$R9VS30qCNQI.IccWdRMiwunxtz5VneHMksW59b2tNIRtBGYXQQRj6",
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
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade);

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

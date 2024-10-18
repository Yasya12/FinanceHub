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
    [Migration("20241016193146_Update2")]
    partial class Update2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                            Id = new Guid("2f3b94da-4bea-435c-8db9-fb30945c8761"),
                            Country = "USA",
                            CreatedAt = new DateTime(2024, 10, 16, 19, 31, 46, 366, DateTimeKind.Utc).AddTicks(6292),
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+1234567890",
                            UpdatedAt = new DateTime(2024, 10, 16, 19, 31, 46, 366, DateTimeKind.Utc).AddTicks(6297),
                            UserId = new Guid("34de7233-8e20-42c2-883c-928dcf836197")
                        },
                        new
                        {
                            Id = new Guid("544a72f7-cfad-463b-ae2d-37100d146b48"),
                            Country = "Canada",
                            CreatedAt = new DateTime(2024, 10, 16, 19, 31, 46, 366, DateTimeKind.Utc).AddTicks(6302),
                            DateOfBirth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            PhoneNumber = "+9876543210",
                            UpdatedAt = new DateTime(2024, 10, 16, 19, 31, 46, 366, DateTimeKind.Utc).AddTicks(6303),
                            UserId = new Guid("e5a3c644-c3fd-4510-8bba-14d8092b9cd9")
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
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("34de7233-8e20-42c2-883c-928dcf836197"),
                            Email = "johndoe@example.com",
                            PasswordHash = "$2a$11$AWexz4OCTnc5mt3DQo/tEe/XS.r64wh6tdcC0gJXV1lxsjqqqtFg6",
                            Role = "User",
                            Username = "johndoe"
                        },
                        new
                        {
                            Id = new Guid("e5a3c644-c3fd-4510-8bba-14d8092b9cd9"),
                            Email = "admin@example.com",
                            PasswordHash = "$2a$11$GAyqJXEsl18Coa8KAotQiOZ1AJVB57S3m8VgwPlr.HF1qqxmewvVK",
                            Role = "Admin",
                            Username = "admin"
                        });
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

            modelBuilder.Entity("FinanceHub.Core.Entities.User", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}

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

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9edc80bb-adba-4618-968e-69d80fd2b949"),
                            Email = "admin@example.com",
                            PasswordHash = "hashed_password_1",
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("48a4fe48-e716-46c3-88f3-45c0ea3ee47f"),
                            Email = "user1@example.com",
                            PasswordHash = "hashed_password_2",
                            Username = "user1"
                        },
                        new
                        {
                            Id = new Guid("eaa3dc89-f501-4d62-b5d2-5daa2c0dabb5"),
                            Email = "user2@example.com",
                            PasswordHash = "hashed_password_3",
                            Username = "user2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

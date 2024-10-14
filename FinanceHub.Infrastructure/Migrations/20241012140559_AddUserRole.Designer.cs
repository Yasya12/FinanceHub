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
    [Migration("20241012140559_AddUserRole")]
    partial class AddUserRole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("2d151243-a963-4cba-b02a-f6c9bee00528"),
                            Email = "admin@example.com",
                            PasswordHash = "hashed_password_1",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("6b2fb6cf-5c66-4ba8-ba4a-2cd2f7ca76af"),
                            Email = "user1@example.com",
                            PasswordHash = "hashed_password_2",
                            Role = "User",
                            Username = "user1"
                        },
                        new
                        {
                            Id = new Guid("59c37103-a4bb-4f0a-a059-5e0d90706e82"),
                            Email = "user2@example.com",
                            PasswordHash = "hashed_password_3",
                            Role = "User",
                            Username = "user2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
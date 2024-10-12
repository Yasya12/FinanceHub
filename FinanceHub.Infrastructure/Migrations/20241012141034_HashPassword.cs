using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HashPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2d151243-a963-4cba-b02a-f6c9bee00528"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("59c37103-a4bb-4f0a-a059-5e0d90706e82"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6b2fb6cf-5c66-4ba8-ba4a-2cd2f7ca76af"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("1fad48fc-635c-4da8-a911-98bb81d402e1"), "user1@example.com", "$2a$11$wUPCnQfGB6HN6LJEwjL1Cuepd7/82UFCrAejL9PG4UqaOUvv5fTCS", "User", "user1" },
                    { new Guid("779b75ba-a218-4292-a370-0fd208b22f54"), "user2@example.com", "$2a$11$BEKQaUpp8UI6n/KOSWaFZ.0Vwo7kch/8p9YdbiXSCpPptjfXnEh0C", "User", "user2" },
                    { new Guid("ec7268df-1b2c-44c5-8f90-1b31aacfacd3"), "admin@example.com", "$2a$11$WoX2aNlGJxSBeBEd9wdHe.9ORoNh8WLTCgEWmvqNaoKx3C2AnkEzm", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fad48fc-635c-4da8-a911-98bb81d402e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("779b75ba-a218-4292-a370-0fd208b22f54"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ec7268df-1b2c-44c5-8f90-1b31aacfacd3"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("2d151243-a963-4cba-b02a-f6c9bee00528"), "admin@example.com", "hashed_password_1", "Admin", "admin" },
                    { new Guid("59c37103-a4bb-4f0a-a059-5e0d90706e82"), "user2@example.com", "hashed_password_3", "User", "user2" },
                    { new Guid("6b2fb6cf-5c66-4ba8-ba4a-2cd2f7ca76af"), "user1@example.com", "hashed_password_2", "User", "user1" }
                });
        }
    }
}

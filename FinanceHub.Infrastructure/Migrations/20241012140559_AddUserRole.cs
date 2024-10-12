using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("48a4fe48-e716-46c3-88f3-45c0ea3ee47f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9edc80bb-adba-4618-968e-69d80fd2b949"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eaa3dc89-f501-4d62-b5d2-5daa2c0dabb5"));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { new Guid("48a4fe48-e716-46c3-88f3-45c0ea3ee47f"), "user1@example.com", "hashed_password_2", "user1" },
                    { new Guid("9edc80bb-adba-4618-968e-69d80fd2b949"), "admin@example.com", "hashed_password_1", "admin" },
                    { new Guid("eaa3dc89-f501-4d62-b5d2-5daa2c0dabb5"), "user2@example.com", "hashed_password_3", "user2" }
                });
        }
    }
}

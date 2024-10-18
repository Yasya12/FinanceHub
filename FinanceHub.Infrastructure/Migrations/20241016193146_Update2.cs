using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2e582211-6f5b-459b-b35e-a7cf63e07351"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("c938c8b6-9219-477d-b8ff-98db667c7dd8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7032bbd2-bcae-4d3e-9777-f8101e3bd2b7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1da7d6f-f848-4614-82d0-5a7560face41"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("34de7233-8e20-42c2-883c-928dcf836197"), "johndoe@example.com", "$2a$11$AWexz4OCTnc5mt3DQo/tEe/XS.r64wh6tdcC0gJXV1lxsjqqqtFg6", "User", "johndoe" },
                    { new Guid("e5a3c644-c3fd-4510-8bba-14d8092b9cd9"), "admin@example.com", "$2a$11$GAyqJXEsl18Coa8KAotQiOZ1AJVB57S3m8VgwPlr.HF1qqxmewvVK", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2f3b94da-4bea-435c-8db9-fb30945c8761"), null, "USA", new DateTime(2024, 10, 16, 19, 31, 46, 366, DateTimeKind.Utc).AddTicks(6292), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 10, 16, 19, 31, 46, 366, DateTimeKind.Utc).AddTicks(6297), new Guid("34de7233-8e20-42c2-883c-928dcf836197") },
                    { new Guid("544a72f7-cfad-463b-ae2d-37100d146b48"), null, "Canada", new DateTime(2024, 10, 16, 19, 31, 46, 366, DateTimeKind.Utc).AddTicks(6302), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 10, 16, 19, 31, 46, 366, DateTimeKind.Utc).AddTicks(6303), new Guid("e5a3c644-c3fd-4510-8bba-14d8092b9cd9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2f3b94da-4bea-435c-8db9-fb30945c8761"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("544a72f7-cfad-463b-ae2d-37100d146b48"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("34de7233-8e20-42c2-883c-928dcf836197"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e5a3c644-c3fd-4510-8bba-14d8092b9cd9"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("7032bbd2-bcae-4d3e-9777-f8101e3bd2b7"), "admin@example.com", "adminhashedpassword", "Admin", "admin" },
                    { new Guid("b1da7d6f-f848-4614-82d0-5a7560face41"), "johndoe@example.com", "hashedpassword", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2e582211-6f5b-459b-b35e-a7cf63e07351"), null, "USA", new DateTime(2024, 10, 16, 19, 16, 4, 880, DateTimeKind.Utc).AddTicks(7853), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 10, 16, 19, 16, 4, 880, DateTimeKind.Utc).AddTicks(7857), new Guid("b1da7d6f-f848-4614-82d0-5a7560face41") },
                    { new Guid("c938c8b6-9219-477d-b8ff-98db667c7dd8"), null, "Canada", new DateTime(2024, 10, 16, 19, 16, 4, 880, DateTimeKind.Utc).AddTicks(7880), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 10, 16, 19, 16, 4, 880, DateTimeKind.Utc).AddTicks(7880), new Guid("7032bbd2-bcae-4d3e-9777-f8101e3bd2b7") }
                });
        }
    }
}

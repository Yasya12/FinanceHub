using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("3975b2d8-4d06-431b-a5c5-c8e5d0ad914c"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("aacee0f2-1d63-4863-abb8-2e27eda2fd6b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("518182b5-7445-42f2-8f2c-741f51d26329"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bf52fb6d-388c-455f-b94a-7709ae4726ce"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Profiles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Profiles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("518182b5-7445-42f2-8f2c-741f51d26329"), "admin@example.com", "adminhashedpassword", "Admin", "admin" },
                    { new Guid("bf52fb6d-388c-455f-b94a-7709ae4726ce"), "johndoe@example.com", "hashedpassword", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("3975b2d8-4d06-431b-a5c5-c8e5d0ad914c"), null, "USA", new DateTime(2024, 10, 16, 18, 55, 5, 490, DateTimeKind.Utc).AddTicks(1606), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 10, 16, 18, 55, 5, 490, DateTimeKind.Utc).AddTicks(1612), new Guid("bf52fb6d-388c-455f-b94a-7709ae4726ce") },
                    { new Guid("aacee0f2-1d63-4863-abb8-2e27eda2fd6b"), null, "Canada", new DateTime(2024, 10, 16, 18, 55, 5, 490, DateTimeKind.Utc).AddTicks(1631), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 10, 16, 18, 55, 5, 490, DateTimeKind.Utc).AddTicks(1631), new Guid("518182b5-7445-42f2-8f2c-741f51d26329") }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("0732cc6b-7198-4bdd-98a3-bbef9658f530"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("19f45a15-94e5-4d7c-8d4f-063a50207aa5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("162073a6-d9f4-4292-bd33-662c6b623e98"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("601eb161-9b38-4685-ba37-72732d670807"));

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Profiles");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Profiles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("162073a6-d9f4-4292-bd33-662c6b623e98"), "johndoe@example.com", "hashedpassword", "User", "johndoe" },
                    { new Guid("601eb161-9b38-4685-ba37-72732d670807"), "admin@example.com", "adminhashedpassword", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "FullName", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("0732cc6b-7198-4bdd-98a3-bbef9658f530"), null, "USA", new DateTime(2024, 10, 14, 14, 44, 13, 169, DateTimeKind.Utc).AddTicks(412), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "John Doe", "+1234567890", null, new DateTime(2024, 10, 14, 14, 44, 13, 169, DateTimeKind.Utc).AddTicks(415), new Guid("162073a6-d9f4-4292-bd33-662c6b623e98") },
                    { new Guid("19f45a15-94e5-4d7c-8d4f-063a50207aa5"), null, "Canada", new DateTime(2024, 10, 14, 14, 44, 13, 169, DateTimeKind.Utc).AddTicks(437), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Admin", "+9876543210", null, new DateTime(2024, 10, 14, 14, 44, 13, 169, DateTimeKind.Utc).AddTicks(438), new Guid("601eb161-9b38-4685-ba37-72732d670807") }
                });
        }
    }
}

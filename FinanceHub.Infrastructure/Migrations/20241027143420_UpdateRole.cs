using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "user",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("157835d9-97cf-437b-aab0-a185a6cbc214"), "johndoe@example.com", "$2a$11$RvunKJ1YOrz.eBSrMN2GvOMQfIC/HP4Ms2N7l3ksNBUgxDT88GGay", "User", "johndoe" },
                    { new Guid("9d1604a6-08a3-445e-99f1-f9cfa15a2236"), "admin@example.com", "$2a$11$ByRPGw2s1S7YboX1Rozsa.5iaHOo2u99nFK3Jcyh3dgHbN29LZu7S", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1852c39c-71ae-4959-929b-155de4d6e4ba"), null, "USA", new DateTime(2024, 10, 27, 14, 34, 18, 796, DateTimeKind.Utc).AddTicks(7702), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 10, 27, 14, 34, 18, 796, DateTimeKind.Utc).AddTicks(7708), new Guid("157835d9-97cf-437b-aab0-a185a6cbc214") },
                    { new Guid("3aee70e4-d983-4c75-bdd2-cdbc6d2b4a9f"), null, "Canada", new DateTime(2024, 10, 27, 14, 34, 18, 796, DateTimeKind.Utc).AddTicks(7714), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 10, 27, 14, 34, 18, 796, DateTimeKind.Utc).AddTicks(7715), new Guid("9d1604a6-08a3-445e-99f1-f9cfa15a2236") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("1852c39c-71ae-4959-929b-155de4d6e4ba"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("3aee70e4-d983-4c75-bdd2-cdbc6d2b4a9f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("157835d9-97cf-437b-aab0-a185a6cbc214"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d1604a6-08a3-445e-99f1-f9cfa15a2236"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "user");

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
    }
}

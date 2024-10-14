using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

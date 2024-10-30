using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("9717faa9-eb0a-4ed9-8598-882de21db6a1"), "johndoe@example.com", "$2a$11$6oCvzZ/mKyThzICeRP4J2OtZRrCH80h5bYMgXIeLZWKEKUwklfblW", "User", "johndoe" },
                    { new Guid("adb1e9cb-10a6-48cd-8103-fa7c5f5b5581"), "admin@example.com", "$2a$11$JhYjmqZnzHfvHQIfxzDZCuqqJCIknxgvSDRPpRYPqPQd/4vB.RsFC", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2a5ad868-152c-4d87-9208-95e203612ccd"), new Guid("adb1e9cb-10a6-48cd-8103-fa7c5f5b5581"), "Exploring advanced strategies in finance.", new DateTime(2024, 10, 10, 21, 9, 35, 545, DateTimeKind.Utc).AddTicks(2248), "Advanced Financial Strategies", new DateTime(2024, 10, 28, 21, 9, 35, 545, DateTimeKind.Utc).AddTicks(2248) },
                    { new Guid("314fe406-61f7-4397-bc3f-15fabf92e695"), new Guid("9717faa9-eb0a-4ed9-8598-882de21db6a1"), "This is an introductory post about finance.", new DateTime(2024, 10, 20, 21, 9, 35, 545, DateTimeKind.Utc).AddTicks(2235), "Introduction to Finance", new DateTime(2024, 10, 25, 21, 9, 35, 545, DateTimeKind.Utc).AddTicks(2245) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("c7253b72-c415-4a06-9415-2ac4539ddff4"), null, "Canada", new DateTime(2024, 10, 30, 21, 9, 35, 545, DateTimeKind.Utc).AddTicks(2186), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 10, 30, 21, 9, 35, 545, DateTimeKind.Utc).AddTicks(2186), new Guid("adb1e9cb-10a6-48cd-8103-fa7c5f5b5581") },
                    { new Guid("d0dfd6c3-8fc1-4eb1-8454-1d59abb8d476"), null, "USA", new DateTime(2024, 10, 30, 21, 9, 35, 545, DateTimeKind.Utc).AddTicks(2157), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 10, 30, 21, 9, 35, 545, DateTimeKind.Utc).AddTicks(2163), new Guid("9717faa9-eb0a-4ed9-8598-882de21db6a1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("c7253b72-c415-4a06-9415-2ac4539ddff4"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d0dfd6c3-8fc1-4eb1-8454-1d59abb8d476"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9717faa9-eb0a-4ed9-8598-882de21db6a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("adb1e9cb-10a6-48cd-8103-fa7c5f5b5581"));

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
    }
}

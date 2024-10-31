using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("2a5ad868-152c-4d87-9208-95e203612ccd"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("314fe406-61f7-4397-bc3f-15fabf92e695"));

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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("22f08db8-47cb-4f5c-a4cb-70b1d72bd0de"), "Health tips and news", "Health" },
                    { new Guid("43c530df-4c7f-4fef-9982-1d183217d147"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830"), "Educational articles and resources", "Education" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("b300c149-3b45-41a6-8587-ae8a824316f5"), "admin@example.com", "$2a$11$Z.1Xs2e1Tolt3bFPMJrFq.2iUZYY.1f/bJdPbpyyfUVieA9kwLJQ.", "Admin", "admin" },
                    { new Guid("c7b3e8fe-2518-4593-b3d4-5a7508a6f115"), "johndoe@example.com", "$2a$11$pxzKJDx2lxVbuGe3UuMig.1bYWjN43PkLyMCIAGkzG4K2YX/uyMJi", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe"), new Guid("b300c149-3b45-41a6-8587-ae8a824316f5"), "Exploring advanced strategies in finance.", new DateTime(2024, 10, 11, 16, 5, 35, 620, DateTimeKind.Utc).AddTicks(55), "Advanced Financial Strategies", new DateTime(2024, 10, 29, 16, 5, 35, 620, DateTimeKind.Utc).AddTicks(55) },
                    { new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d"), new Guid("c7b3e8fe-2518-4593-b3d4-5a7508a6f115"), "This is an introductory post about finance.", new DateTime(2024, 10, 21, 16, 5, 35, 620, DateTimeKind.Utc).AddTicks(25), "Introduction to Finance", new DateTime(2024, 10, 26, 16, 5, 35, 620, DateTimeKind.Utc).AddTicks(53) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("a142267c-6733-4816-9eab-f071c7ba34c8"), null, "USA", new DateTime(2024, 10, 31, 16, 5, 35, 619, DateTimeKind.Utc).AddTicks(9982), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 10, 31, 16, 5, 35, 619, DateTimeKind.Utc).AddTicks(9986), new Guid("c7b3e8fe-2518-4593-b3d4-5a7508a6f115") },
                    { new Guid("a63b0711-abec-416c-805c-117ed65cea9f"), null, "Canada", new DateTime(2024, 10, 31, 16, 5, 35, 619, DateTimeKind.Utc).AddTicks(9992), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 10, 31, 16, 5, 35, 619, DateTimeKind.Utc).AddTicks(9992), new Guid("b300c149-3b45-41a6-8587-ae8a824316f5") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("22f08db8-47cb-4f5c-a4cb-70b1d72bd0de"), new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe") },
                    { new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830"), new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe") },
                    { new Guid("43c530df-4c7f-4fef-9982-1d183217d147"), new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d") },
                    { new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830"), new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a142267c-6733-4816-9eab-f071c7ba34c8"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a63b0711-abec-416c-805c-117ed65cea9f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b300c149-3b45-41a6-8587-ae8a824316f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7b3e8fe-2518-4593-b3d4-5a7508a6f115"));

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
        }
    }
}

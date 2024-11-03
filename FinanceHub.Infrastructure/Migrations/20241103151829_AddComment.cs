using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("22f08db8-47cb-4f5c-a4cb-70b1d72bd0de"), new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830"), new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("43c530df-4c7f-4fef-9982-1d183217d147"), new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830"), new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a142267c-6733-4816-9eab-f071c7ba34c8"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a63b0711-abec-416c-805c-117ed65cea9f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22f08db8-47cb-4f5c-a4cb-70b1d72bd0de"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43c530df-4c7f-4fef-9982-1d183217d147"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f0be54ee-c653-4f07-8dfb-1ee8f2ac3830"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4398fefd-e92d-4a15-b11b-0958f003ebbe"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("dd91e750-7e3a-4317-9c92-7a3dd987ea1d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b300c149-3b45-41a6-8587-ae8a824316f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c7b3e8fe-2518-4593-b3d4-5a7508a6f115"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("74da599f-1d3d-4ef0-8f0e-8c918dd737f5"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("9f06db2e-8ddf-43b6-8f1f-fb8b888b0569"), "Health tips and news", "Health" },
                    { new Guid("a18939d0-a67c-40b6-aaee-741e151f938a"), "Educational articles and resources", "Education" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("1dfe606b-6abd-40e9-a3fd-28f233963188"), "johndoe@example.com", "$2a$11$GsCcxDRRsgVWy8fjANfXTuAKG2byLBNLOeGsrWgA6oHKPFIHn/vXy", "User", "johndoe" },
                    { new Guid("490e4312-ae7d-4945-a9b4-8b6222b214ab"), "admin@example.com", "$2a$11$rS0abr5O9COLb..F2.mJXuqlDbq0TQUgZO32.CRmHDpIeSTTxiCZm", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("6afc72c1-4779-4ca9-8949-4c25f4eaae28"), new Guid("490e4312-ae7d-4945-a9b4-8b6222b214ab"), "Exploring advanced strategies in finance.", new DateTime(2024, 10, 14, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(2987), "Advanced Financial Strategies", new DateTime(2024, 11, 1, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(2988) },
                    { new Guid("d23ac7a9-6c27-4e83-8956-50df768e927b"), new Guid("1dfe606b-6abd-40e9-a3fd-28f233963188"), "This is an introductory post about finance.", new DateTime(2024, 10, 24, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(2975), "Introduction to Finance", new DateTime(2024, 10, 29, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(2986) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("61233168-e22f-4b07-984e-ffcc09562fea"), null, "USA", new DateTime(2024, 11, 3, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(2928), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 11, 3, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(2932), new Guid("1dfe606b-6abd-40e9-a3fd-28f233963188") },
                    { new Guid("eea092d4-46f3-4a67-9baf-15fc562f03d9"), null, "Canada", new DateTime(2024, 11, 3, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(2938), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 11, 3, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(2939), new Guid("490e4312-ae7d-4945-a9b4-8b6222b214ab") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "PostId" },
                values: new object[,]
                {
                    { new Guid("677b265f-e072-4e2b-b9b4-7e07f21fc05f"), new Guid("490e4312-ae7d-4945-a9b4-8b6222b214ab"), "Interesting perspective on finance.", new DateTime(2024, 10, 30, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(3143), new Guid("d23ac7a9-6c27-4e83-8956-50df768e927b") },
                    { new Guid("77f9167d-e1af-4794-b6ce-db74d6d27d2a"), new Guid("1dfe606b-6abd-40e9-a3fd-28f233963188"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 10, 29, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(3142), new Guid("d23ac7a9-6c27-4e83-8956-50df768e927b") },
                    { new Guid("82ca66f0-4bbd-4558-8d44-719ecd9479e5"), new Guid("1dfe606b-6abd-40e9-a3fd-28f233963188"), "I found this article very helpful!", new DateTime(2024, 10, 31, 15, 18, 27, 495, DateTimeKind.Utc).AddTicks(3154), new Guid("6afc72c1-4779-4ca9-8949-4c25f4eaae28") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("9f06db2e-8ddf-43b6-8f1f-fb8b888b0569"), new Guid("6afc72c1-4779-4ca9-8949-4c25f4eaae28") },
                    { new Guid("a18939d0-a67c-40b6-aaee-741e151f938a"), new Guid("6afc72c1-4779-4ca9-8949-4c25f4eaae28") },
                    { new Guid("74da599f-1d3d-4ef0-8f0e-8c918dd737f5"), new Guid("d23ac7a9-6c27-4e83-8956-50df768e927b") },
                    { new Guid("a18939d0-a67c-40b6-aaee-741e151f938a"), new Guid("d23ac7a9-6c27-4e83-8956-50df768e927b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("9f06db2e-8ddf-43b6-8f1f-fb8b888b0569"), new Guid("6afc72c1-4779-4ca9-8949-4c25f4eaae28") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("a18939d0-a67c-40b6-aaee-741e151f938a"), new Guid("6afc72c1-4779-4ca9-8949-4c25f4eaae28") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("74da599f-1d3d-4ef0-8f0e-8c918dd737f5"), new Guid("d23ac7a9-6c27-4e83-8956-50df768e927b") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("a18939d0-a67c-40b6-aaee-741e151f938a"), new Guid("d23ac7a9-6c27-4e83-8956-50df768e927b") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("61233168-e22f-4b07-984e-ffcc09562fea"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("eea092d4-46f3-4a67-9baf-15fc562f03d9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74da599f-1d3d-4ef0-8f0e-8c918dd737f5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9f06db2e-8ddf-43b6-8f1f-fb8b888b0569"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a18939d0-a67c-40b6-aaee-741e151f938a"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("6afc72c1-4779-4ca9-8949-4c25f4eaae28"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d23ac7a9-6c27-4e83-8956-50df768e927b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1dfe606b-6abd-40e9-a3fd-28f233963188"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("490e4312-ae7d-4945-a9b4-8b6222b214ab"));

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
        }
    }
}

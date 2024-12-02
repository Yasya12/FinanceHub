using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGoogle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("585b6b36-8f91-4970-9f4c-b1a6930667af"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("758d81c3-6b11-49e7-82d4-314ef2b271d1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e251bf26-0f12-4187-bb6c-533bbb11f210"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b"), new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("60734545-fb55-499e-b466-cd2edda92b06"), new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b"), new Guid("d475a21b-d8d0-4f99-b458-30d865851b21") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("a00555d7-d065-490e-88ce-92a9ad52987f"), new Guid("d475a21b-d8d0-4f99-b458-30d865851b21") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("4c4f8157-68db-4c65-a514-d7115c4557bb"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("b8b8b100-8c77-4674-a650-ac3baa5e7b6b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("60734545-fb55-499e-b466-cd2edda92b06"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a00555d7-d065-490e-88ce-92a9ad52987f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d475a21b-d8d0-4f99-b458-30d865851b21"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"));

            migrationBuilder.AddColumn<string>(
                name: "GoogleId",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("18994354-e438-472b-9f9c-6a579f331176"), "Health tips and news", "Health" },
                    { new Guid("601d7aec-1643-4ab1-83f8-268df8998134"), "Educational articles and resources", "Education" },
                    { new Guid("71c7cdd8-88d0-49e1-9e7d-661b81ab9582"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("681219eb-03ca-4c27-a987-274bf1f0aab7"), "johndoe@example.com", null, "$2a$11$/0HXgOTJlcdvoWHhCvYMMuMlqkH4OjBZHsQ46dkL.bcp4IdCVAhM2", "User", "johndoe" },
                    { new Guid("a56e5680-88aa-41cd-9bdc-cae4e8a2bb47"), "admin@example.com", null, "$2a$11$Q.OhTC8yt0cR9BUKA6fsrult56g80BKdmo8GWRCCNLXy/XpFPLeIm", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("12b541b7-e4ce-43cb-b930-4c3e6536f827"), new Guid("a56e5680-88aa-41cd-9bdc-cae4e8a2bb47"), "Exploring advanced strategies in finance.", new DateTime(2024, 10, 31, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8447), "Advanced Financial Strategies", new DateTime(2024, 11, 18, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8447) },
                    { new Guid("43b7bfb9-81fb-49b6-a275-0e3d4292b9ea"), new Guid("681219eb-03ca-4c27-a987-274bf1f0aab7"), "This is an introductory post about finance.", new DateTime(2024, 11, 10, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8432), "Introduction to Finance", new DateTime(2024, 11, 15, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8446) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("3216aaad-6df0-4960-a58b-3c8b339bf8a1"), null, "USA", new DateTime(2024, 11, 20, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8357), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 11, 20, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8360), new Guid("681219eb-03ca-4c27-a987-274bf1f0aab7") },
                    { new Guid("5bf7fe92-4e4e-4810-9953-c34d08f0db28"), null, "Canada", new DateTime(2024, 11, 20, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8386), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 11, 20, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8387), new Guid("a56e5680-88aa-41cd-9bdc-cae4e8a2bb47") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "PostId" },
                values: new object[,]
                {
                    { new Guid("1ba8d72b-107a-4e22-b360-bf2721f10290"), new Guid("a56e5680-88aa-41cd-9bdc-cae4e8a2bb47"), "Interesting perspective on finance.", new DateTime(2024, 11, 16, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8579), false, new Guid("43b7bfb9-81fb-49b6-a275-0e3d4292b9ea") },
                    { new Guid("42098c66-e472-43a7-9135-0182d309aab0"), new Guid("681219eb-03ca-4c27-a987-274bf1f0aab7"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 11, 15, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8578), false, new Guid("43b7bfb9-81fb-49b6-a275-0e3d4292b9ea") },
                    { new Guid("75dc3750-a856-4350-9c2f-fee5094f4720"), new Guid("681219eb-03ca-4c27-a987-274bf1f0aab7"), "I found this article very helpful!", new DateTime(2024, 11, 17, 21, 33, 6, 643, DateTimeKind.Utc).AddTicks(8580), false, new Guid("12b541b7-e4ce-43cb-b930-4c3e6536f827") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("18994354-e438-472b-9f9c-6a579f331176"), new Guid("12b541b7-e4ce-43cb-b930-4c3e6536f827") },
                    { new Guid("601d7aec-1643-4ab1-83f8-268df8998134"), new Guid("12b541b7-e4ce-43cb-b930-4c3e6536f827") },
                    { new Guid("601d7aec-1643-4ab1-83f8-268df8998134"), new Guid("43b7bfb9-81fb-49b6-a275-0e3d4292b9ea") },
                    { new Guid("71c7cdd8-88d0-49e1-9e7d-661b81ab9582"), new Guid("43b7bfb9-81fb-49b6-a275-0e3d4292b9ea") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("1ba8d72b-107a-4e22-b360-bf2721f10290"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("42098c66-e472-43a7-9135-0182d309aab0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("75dc3750-a856-4350-9c2f-fee5094f4720"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("18994354-e438-472b-9f9c-6a579f331176"), new Guid("12b541b7-e4ce-43cb-b930-4c3e6536f827") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("601d7aec-1643-4ab1-83f8-268df8998134"), new Guid("12b541b7-e4ce-43cb-b930-4c3e6536f827") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("601d7aec-1643-4ab1-83f8-268df8998134"), new Guid("43b7bfb9-81fb-49b6-a275-0e3d4292b9ea") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("71c7cdd8-88d0-49e1-9e7d-661b81ab9582"), new Guid("43b7bfb9-81fb-49b6-a275-0e3d4292b9ea") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("3216aaad-6df0-4960-a58b-3c8b339bf8a1"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("5bf7fe92-4e4e-4810-9953-c34d08f0db28"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("18994354-e438-472b-9f9c-6a579f331176"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("601d7aec-1643-4ab1-83f8-268df8998134"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("71c7cdd8-88d0-49e1-9e7d-661b81ab9582"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("12b541b7-e4ce-43cb-b930-4c3e6536f827"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("43b7bfb9-81fb-49b6-a275-0e3d4292b9ea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("681219eb-03ca-4c27-a987-274bf1f0aab7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a56e5680-88aa-41cd-9bdc-cae4e8a2bb47"));

            migrationBuilder.DropColumn(
                name: "GoogleId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b"), "Educational articles and resources", "Education" },
                    { new Guid("60734545-fb55-499e-b466-cd2edda92b06"), "Health tips and news", "Health" },
                    { new Guid("a00555d7-d065-490e-88ce-92a9ad52987f"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551"), "admin@example.com", "$2a$11$MJ4xrYG8In4D8SdOU26La.zibbhZLvzu3KU1tSPW2v.RnNz4OYtYy", "Admin", "admin" },
                    { new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"), "johndoe@example.com", "$2a$11$U8wph2P96//rlF1X8g2n..BZ9eKJ2RBwaQXI4nz7.mefohJCx7FRu", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8"), new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551"), "Exploring advanced strategies in finance.", new DateTime(2024, 10, 14, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1997), "Advanced Financial Strategies", new DateTime(2024, 11, 1, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1998) },
                    { new Guid("d475a21b-d8d0-4f99-b458-30d865851b21"), new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"), "This is an introductory post about finance.", new DateTime(2024, 10, 24, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1978), "Introduction to Finance", new DateTime(2024, 10, 29, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1996) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("4c4f8157-68db-4c65-a514-d7115c4557bb"), null, "USA", new DateTime(2024, 11, 3, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1893), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 11, 3, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1897), new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b") },
                    { new Guid("b8b8b100-8c77-4674-a650-ac3baa5e7b6b"), null, "Canada", new DateTime(2024, 11, 3, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1903), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 11, 3, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(1904), new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "PostId" },
                values: new object[,]
                {
                    { new Guid("585b6b36-8f91-4970-9f4c-b1a6930667af"), new Guid("14c53c32-2d81-4e79-a2dd-0b8a40bf3551"), "Interesting perspective on finance.", new DateTime(2024, 10, 30, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(2128), false, new Guid("d475a21b-d8d0-4f99-b458-30d865851b21") },
                    { new Guid("758d81c3-6b11-49e7-82d4-314ef2b271d1"), new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 10, 29, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(2127), false, new Guid("d475a21b-d8d0-4f99-b458-30d865851b21") },
                    { new Guid("e251bf26-0f12-4187-bb6c-533bbb11f210"), new Guid("2ccefb15-3e8f-4dc9-9c50-2fd2b35cc14b"), "I found this article very helpful!", new DateTime(2024, 10, 31, 16, 44, 58, 248, DateTimeKind.Utc).AddTicks(2130), false, new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b"), new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8") },
                    { new Guid("60734545-fb55-499e-b466-cd2edda92b06"), new Guid("46f1aae8-4eef-4296-8ff0-4449ee3385e8") },
                    { new Guid("1eba2ea8-4b23-4eb3-9995-0e079a5ffd2b"), new Guid("d475a21b-d8d0-4f99-b458-30d865851b21") },
                    { new Guid("a00555d7-d065-490e-88ce-92a9ad52987f"), new Guid("d475a21b-d8d0-4f99-b458-30d865851b21") }
                });
        }
    }
}

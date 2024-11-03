using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("14c8d85b-b75c-45d8-891d-fe17b629b0c0"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b15380bf-73cb-4e75-b400-ff4a4d20dba5"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("e30d669e-c560-4538-a0bd-43d39c3a2a5d"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546"), new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("a04baf59-03dd-4b55-91ef-d87e06901021"), new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("251fb8ef-235d-4f42-ac29-4dde0437e8b6"), new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546"), new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("68f6c132-1e45-4b5a-b874-8c558452aa9b"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("f338fe07-8242-495c-bf3d-30e84e6d1d7d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("251fb8ef-235d-4f42-ac29-4dde0437e8b6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a04baf59-03dd-4b55-91ef-d87e06901021"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("251fb8ef-235d-4f42-ac29-4dde0437e8b6"), "Health tips and news", "Health" },
                    { new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546"), "Educational articles and resources", "Education" },
                    { new Guid("a04baf59-03dd-4b55-91ef-d87e06901021"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"), "johndoe@example.com", "$2a$11$mJPz98jGLn2fTy0X.uhvUeou0Pv51uAyH3TysCj6cTeAObPXv3Key", "User", "johndoe" },
                    { new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b"), "admin@example.com", "$2a$11$w9Ogbw7B8KEJYZ/KPZD6u.yFqSp01VRX7Mj8JPgxidwnGzF9TEN.G", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d"), new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"), "This is an introductory post about finance.", new DateTime(2024, 10, 24, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7570), "Introduction to Finance", new DateTime(2024, 10, 29, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7583) },
                    { new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad"), new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b"), "Exploring advanced strategies in finance.", new DateTime(2024, 10, 14, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7585), "Advanced Financial Strategies", new DateTime(2024, 11, 1, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7586) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("68f6c132-1e45-4b5a-b874-8c558452aa9b"), null, "USA", new DateTime(2024, 11, 3, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7481), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 11, 3, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7488), new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6") },
                    { new Guid("f338fe07-8242-495c-bf3d-30e84e6d1d7d"), null, "Canada", new DateTime(2024, 11, 3, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7520), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 11, 3, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7521), new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "PostId" },
                values: new object[,]
                {
                    { new Guid("14c8d85b-b75c-45d8-891d-fe17b629b0c0"), new Guid("9d669dc9-8d3f-4258-90db-db99411cbd7b"), "Interesting perspective on finance.", new DateTime(2024, 10, 30, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7756), false, new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d") },
                    { new Guid("b15380bf-73cb-4e75-b400-ff4a4d20dba5"), new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 10, 29, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7754), false, new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d") },
                    { new Guid("e30d669e-c560-4538-a0bd-43d39c3a2a5d"), new Guid("66d0bcd3-fccc-45c9-bc4b-89edf7c153f6"), "I found this article very helpful!", new DateTime(2024, 10, 31, 15, 22, 30, 679, DateTimeKind.Utc).AddTicks(7758), false, new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546"), new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d") },
                    { new Guid("a04baf59-03dd-4b55-91ef-d87e06901021"), new Guid("9503acd7-4581-4e31-ab48-13c99c3b165d") },
                    { new Guid("251fb8ef-235d-4f42-ac29-4dde0437e8b6"), new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad") },
                    { new Guid("889390ff-4a0d-46fa-b01d-a9653af2f546"), new Guid("dd9eaf2f-899e-4162-96df-7ebd882026ad") }
                });
        }
    }
}

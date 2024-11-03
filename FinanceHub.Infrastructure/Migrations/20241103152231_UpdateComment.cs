using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("677b265f-e072-4e2b-b9b4-7e07f21fc05f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("77f9167d-e1af-4794-b6ce-db74d6d27d2a"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("82ca66f0-4bbd-4558-8d44-719ecd9479e5"));

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

            migrationBuilder.AddColumn<bool>(
                name: "IsModified",
                table: "Comments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsModified",
                table: "Comments");

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
        }
    }
}

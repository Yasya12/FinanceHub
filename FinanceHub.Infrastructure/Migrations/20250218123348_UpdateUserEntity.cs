using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("21b5dcca-2f23-49c0-b506-a1da0583cd91"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a3b21bf8-eb49-4b56-ae9a-48f11e1e27f5"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d14bd6bc-ff33-4e93-bd07-af661dd0ca9b"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("12030011-8c9b-43ef-82fb-b95334081059"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("7dbbad8b-96ac-4ec5-9fa2-cf8c4a4e4fbd"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("f774d138-9424-4e62-b945-60ac01bdb5b6"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2"), new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("ebb27798-ea30-473f-a8d4-eeed7db28b11"), new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("55a43592-0128-4c9f-b2bd-baa69c7e3e9e"), new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2"), new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("1ad8a52d-5010-476e-853c-a64df99e70ec"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("f13f0bac-b611-48fd-92a3-d1c0d897b70f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55a43592-0128-4c9f-b2bd-baa69c7e3e9e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ebb27798-ea30-473f-a8d4-eeed7db28b11"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6fb4470-a205-49f2-b804-6200a92424d4"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("460929ba-a82f-46d1-ab8b-a8e85f987346"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("8449d5d1-0164-4b28-bd2c-e5cc657a0ee2"), "Health tips and news", "Health" },
                    { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), "Educational articles and resources", "Education" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"), "johndoe@example.com", null, "$2a$11$vOYpttYWU6QvWuw3KyTowu0K/A8PHOe3PNMcfh7186XD1sFtnYJoO", "User", "johndoe" },
                    { new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30"), "admin@example.com", null, "$2a$11$UDNZ7Hj.HkiqeBkF.SuVyeFpLNjFqslSOuMnI68ORZ5lzyvktKGky", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc"), new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30"), "Exploring advanced strategies in finance.", new DateTime(2025, 1, 29, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3521), "Advanced Financial Strategies", new DateTime(2025, 2, 16, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3522) },
                    { new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"), "This is an introductory post about finance.", new DateTime(2025, 2, 8, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3502), "Introduction to Finance", new DateTime(2025, 2, 13, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3518) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2fc82168-6f82-4c4f-9533-6c5c7896fbc5"), null, "Canada", new DateTime(2025, 2, 18, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3439), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 2, 18, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3440), new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30") },
                    { new Guid("9c6bf666-8de7-4b4b-ac69-7fdfa6c38cdf"), null, "USA", new DateTime(2025, 2, 18, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3404), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 2, 18, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3409), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("804cb1f3-6244-4326-8945-4c35ff917543"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 2, 13, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3817), false, null, new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") },
                    { new Guid("c37de9c7-c888-44a4-a60b-79b5fa8b177b"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"), "I found this article very helpful!", new DateTime(2025, 2, 15, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3825), false, null, new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") },
                    { new Guid("fabf5a1a-117d-43f2-bce7-c336e5da3a1d"), new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30"), "Interesting perspective on finance.", new DateTime(2025, 2, 14, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3822), false, null, new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("62d8b646-0e40-4145-89aa-bda90e660d13"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415"), new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30") },
                    { new Guid("810e45c2-00d7-4fc2-a477-32cdc9decbb7"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f") },
                    { new Guid("b0ac3947-77fc-44ad-adc4-09a95bdc8597"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("8449d5d1-0164-4b28-bd2c-e5cc657a0ee2"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") },
                    { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") },
                    { new Guid("460929ba-a82f-46d1-ab8b-a8e85f987346"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") },
                    { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("804cb1f3-6244-4326-8945-4c35ff917543"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c37de9c7-c888-44a4-a60b-79b5fa8b177b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("fabf5a1a-117d-43f2-bce7-c336e5da3a1d"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("62d8b646-0e40-4145-89aa-bda90e660d13"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("810e45c2-00d7-4fc2-a477-32cdc9decbb7"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("b0ac3947-77fc-44ad-adc4-09a95bdc8597"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8449d5d1-0164-4b28-bd2c-e5cc657a0ee2"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("460929ba-a82f-46d1-ab8b-a8e85f987346"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2fc82168-6f82-4c4f-9533-6c5c7896fbc5"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("9c6bf666-8de7-4b4b-ac69-7fdfa6c38cdf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("460929ba-a82f-46d1-ab8b-a8e85f987346"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8449d5d1-0164-4b28-bd2c-e5cc657a0ee2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("55a43592-0128-4c9f-b2bd-baa69c7e3e9e"), "Health tips and news", "Health" },
                    { new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2"), "Educational articles and resources", "Education" },
                    { new Guid("ebb27798-ea30-473f-a8d4-eeed7db28b11"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"), "johndoe@example.com", null, "$2a$11$O2P0XXrinTQRraajmPTDr.OdQYe22hq8NIhM0HLPBK.alvfRsDFIG", "User", "johndoe" },
                    { new Guid("d6fb4470-a205-49f2-b804-6200a92424d4"), "admin@example.com", null, "$2a$11$R9VS30qCNQI.IccWdRMiwunxtz5VneHMksW59b2tNIRtBGYXQQRj6", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"), new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"), "This is an introductory post about finance.", new DateTime(2025, 2, 7, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7974), "Introduction to Finance", new DateTime(2025, 2, 12, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7984) },
                    { new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e"), new Guid("d6fb4470-a205-49f2-b804-6200a92424d4"), "Exploring advanced strategies in finance.", new DateTime(2025, 1, 28, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7985), "Advanced Financial Strategies", new DateTime(2025, 2, 15, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7986) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1ad8a52d-5010-476e-853c-a64df99e70ec"), null, "Canada", new DateTime(2025, 2, 17, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7937), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 2, 17, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7938), new Guid("d6fb4470-a205-49f2-b804-6200a92424d4") },
                    { new Guid("f13f0bac-b611-48fd-92a3-d1c0d897b70f"), null, "USA", new DateTime(2025, 2, 17, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7926), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 2, 17, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(7931), new Guid("7653fb83-d36d-4f24-98df-bce7ba718839") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("21b5dcca-2f23-49c0-b506-a1da0583cd91"), new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"), "I found this article very helpful!", new DateTime(2025, 2, 14, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(8161), false, null, new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e") },
                    { new Guid("a3b21bf8-eb49-4b56-ae9a-48f11e1e27f5"), new Guid("7653fb83-d36d-4f24-98df-bce7ba718839"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 2, 12, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(8157), false, null, new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b") },
                    { new Guid("d14bd6bc-ff33-4e93-bd07-af661dd0ca9b"), new Guid("d6fb4470-a205-49f2-b804-6200a92424d4"), "Interesting perspective on finance.", new DateTime(2025, 2, 13, 22, 11, 8, 116, DateTimeKind.Utc).AddTicks(8159), false, null, new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("12030011-8c9b-43ef-82fb-b95334081059"), new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"), new Guid("d6fb4470-a205-49f2-b804-6200a92424d4") },
                    { new Guid("7dbbad8b-96ac-4ec5-9fa2-cf8c4a4e4fbd"), new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b"), new Guid("7653fb83-d36d-4f24-98df-bce7ba718839") },
                    { new Guid("f774d138-9424-4e62-b945-60ac01bdb5b6"), new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e"), new Guid("7653fb83-d36d-4f24-98df-bce7ba718839") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2"), new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b") },
                    { new Guid("ebb27798-ea30-473f-a8d4-eeed7db28b11"), new Guid("8349ef1e-b707-4e57-9a7a-08c88a1efe1b") },
                    { new Guid("55a43592-0128-4c9f-b2bd-baa69c7e3e9e"), new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e") },
                    { new Guid("883e3bb2-3485-4929-84d8-3917f2c75ad2"), new Guid("ab4ae25f-b580-44ca-acd9-6168f74f373e") }
                });
        }
    }
}

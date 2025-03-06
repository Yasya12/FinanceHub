using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfieltEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7430b0e2-73a9-4b22-841e-c212d9dc1a41"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("90fe4d13-816f-45f7-81f7-a47fc32ccdca"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b5ac7d32-1280-457b-8fb2-21588a75fa7b"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("23a975a7-82b6-4e46-b595-580d93df1d16"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("3ca5cd54-1b2a-44fd-ba7b-91f192e58349"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("e12c0482-f200-42a9-8b6a-7267aaff1c4e"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("9045e8b0-36f9-43b5-bd0d-c8be02881cb2"), new Guid("0870b0a8-ae27-4a1a-a5f6-e5c9fc66dc01") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("989c284f-d2d7-44e3-8c64-3f9f970439a8"), new Guid("0870b0a8-ae27-4a1a-a5f6-e5c9fc66dc01") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("989c284f-d2d7-44e3-8c64-3f9f970439a8"), new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("bcb62678-42d7-4dea-b80d-ff8ce8d73608"), new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2a15ab42-521b-4a5b-a468-2cc729e1cab8"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("408403c7-91e6-4705-82aa-c03eafda9f00"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9045e8b0-36f9-43b5-bd0d-c8be02881cb2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("989c284f-d2d7-44e3-8c64-3f9f970439a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcb62678-42d7-4dea-b80d-ff8ce8d73608"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0870b0a8-ae27-4a1a-a5f6-e5c9fc66dc01"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6464508b-4876-480b-8c21-0c398f6441c4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e29fd85e-0ad6-426d-abe0-db8ce11618b3"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments",
                column: "ParentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments");

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
                    { new Guid("9045e8b0-36f9-43b5-bd0d-c8be02881cb2"), "Health tips and news", "Health" },
                    { new Guid("989c284f-d2d7-44e3-8c64-3f9f970439a8"), "Educational articles and resources", "Education" },
                    { new Guid("bcb62678-42d7-4dea-b80d-ff8ce8d73608"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("6464508b-4876-480b-8c21-0c398f6441c4"), "admin@example.com", null, "$2a$11$qufwyyXmbqulFnkap7tVKOOOYelQv768X4WE1FNsQ0JWHdNG3zzee", "Admin", "admin" },
                    { new Guid("e29fd85e-0ad6-426d-abe0-db8ce11618b3"), "johndoe@example.com", null, "$2a$11$nCBgQZ9imtNrMM0zsNYizes3TekuC3dYkCvqBR1FblSFDkUJAC2z.", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0870b0a8-ae27-4a1a-a5f6-e5c9fc66dc01"), new Guid("6464508b-4876-480b-8c21-0c398f6441c4"), "Exploring advanced strategies in finance.", new DateTime(2024, 12, 28, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6302), "Advanced Financial Strategies", new DateTime(2025, 1, 15, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6303) },
                    { new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16"), new Guid("e29fd85e-0ad6-426d-abe0-db8ce11618b3"), "This is an introductory post about finance.", new DateTime(2025, 1, 7, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6289), "Introduction to Finance", new DateTime(2025, 1, 12, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6300) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a15ab42-521b-4a5b-a468-2cc729e1cab8"), null, "USA", new DateTime(2025, 1, 17, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6209), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 1, 17, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6214), new Guid("e29fd85e-0ad6-426d-abe0-db8ce11618b3") },
                    { new Guid("408403c7-91e6-4705-82aa-c03eafda9f00"), null, "Canada", new DateTime(2025, 1, 17, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6220), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 1, 17, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6221), new Guid("6464508b-4876-480b-8c21-0c398f6441c4") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("7430b0e2-73a9-4b22-841e-c212d9dc1a41"), new Guid("e29fd85e-0ad6-426d-abe0-db8ce11618b3"), "I found this article very helpful!", new DateTime(2025, 1, 14, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6472), false, null, new Guid("0870b0a8-ae27-4a1a-a5f6-e5c9fc66dc01") },
                    { new Guid("90fe4d13-816f-45f7-81f7-a47fc32ccdca"), new Guid("6464508b-4876-480b-8c21-0c398f6441c4"), "Interesting perspective on finance.", new DateTime(2025, 1, 13, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6470), false, null, new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16") },
                    { new Guid("b5ac7d32-1280-457b-8fb2-21588a75fa7b"), new Guid("e29fd85e-0ad6-426d-abe0-db8ce11618b3"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 1, 12, 12, 29, 35, 625, DateTimeKind.Utc).AddTicks(6467), false, null, new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("23a975a7-82b6-4e46-b595-580d93df1d16"), new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16"), new Guid("6464508b-4876-480b-8c21-0c398f6441c4") },
                    { new Guid("3ca5cd54-1b2a-44fd-ba7b-91f192e58349"), new Guid("0870b0a8-ae27-4a1a-a5f6-e5c9fc66dc01"), new Guid("e29fd85e-0ad6-426d-abe0-db8ce11618b3") },
                    { new Guid("e12c0482-f200-42a9-8b6a-7267aaff1c4e"), new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16"), new Guid("e29fd85e-0ad6-426d-abe0-db8ce11618b3") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("9045e8b0-36f9-43b5-bd0d-c8be02881cb2"), new Guid("0870b0a8-ae27-4a1a-a5f6-e5c9fc66dc01") },
                    { new Guid("989c284f-d2d7-44e3-8c64-3f9f970439a8"), new Guid("0870b0a8-ae27-4a1a-a5f6-e5c9fc66dc01") },
                    { new Guid("989c284f-d2d7-44e3-8c64-3f9f970439a8"), new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16") },
                    { new Guid("bcb62678-42d7-4dea-b80d-ff8ce8d73608"), new Guid("19227daa-4a87-4d59-9ddd-3171d55c6a16") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments",
                column: "ParentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}

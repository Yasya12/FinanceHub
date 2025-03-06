using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentParentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5d3d7395-baf5-49f6-aace-c813831fee5d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("964dbe09-2a98-4f79-a815-38752a9a8cb1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("bd18bf0b-6213-4272-b68d-734e21198671"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("00fd0f1f-10d6-4c35-9d1d-f6d664c8d838"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("a9c355d9-e907-4a20-9186-34d6d952e9d3"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("f3c3f52f-19c3-43f1-aba5-2b1375efb546"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("238f046d-a13f-47b5-8283-1454610d480b"), new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("c79d683a-38a5-458d-b6f8-8552a22776c9"), new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("238f046d-a13f-47b5-8283-1454610d480b"), new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("beaf595b-9f99-4c5f-ad86-3c21da3f3057"), new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("cae438b0-764a-4048-858f-bde9ac724012"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("f6870b65-18fa-4c3e-8d38-3d75d29cb7b5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("238f046d-a13f-47b5-8283-1454610d480b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("beaf595b-9f99-4c5f-ad86-3c21da3f3057"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c79d683a-38a5-458d-b6f8-8552a22776c9"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1"));

            migrationBuilder.RenameColumn(
                name: "ParentCommentId",
                table: "Comments",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                newName: "IX_Comments_ParentId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("8b93fce5-3a30-4649-8796-d9f02fce1ea9"), "Educational articles and resources", "Education" },
                    { new Guid("ae975476-7288-4062-b9cd-3783230dd751"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("af12aaa4-27e4-45a6-a78d-b187fb024f67"), "Health tips and news", "Health" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("12d3de5e-3bad-4c86-959f-2bb38db1e303"), "admin@example.com", null, "$2a$11$Ewsh7kRI27nzqZ0VQspr6Ojkg5U1nlvC2mnYaYpNxISz7UDX8AjBC", "Admin", "admin" },
                    { new Guid("2f55662a-9233-4f10-89c4-80bf9aa73930"), "johndoe@example.com", null, "$2a$11$l6Vfro/2Bmlnzd1VRk.tnOgDtWqNf0r8TOWbA/dql3dd/qagLXBfi", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4d271309-e20c-4744-9354-cc829ec94d93"), new Guid("2f55662a-9233-4f10-89c4-80bf9aa73930"), "This is an introductory post about finance.", new DateTime(2024, 12, 25, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1571), "Introduction to Finance", new DateTime(2024, 12, 30, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1584) },
                    { new Guid("96c05722-8faf-41e8-9ced-9d010d015807"), new Guid("12d3de5e-3bad-4c86-959f-2bb38db1e303"), "Exploring advanced strategies in finance.", new DateTime(2024, 12, 15, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1586), "Advanced Financial Strategies", new DateTime(2025, 1, 2, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1587) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("1715cfb6-8cfd-4052-8616-0514f58fba66"), null, "USA", new DateTime(2025, 1, 4, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1517), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 1, 4, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1521), new Guid("2f55662a-9233-4f10-89c4-80bf9aa73930") },
                    { new Guid("db9ee1ad-e89a-4584-be6f-b47d74fd9a53"), null, "Canada", new DateTime(2025, 1, 4, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1529), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 1, 4, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1530), new Guid("12d3de5e-3bad-4c86-959f-2bb38db1e303") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("03874371-d31a-419f-ac95-576a1c4547a9"), new Guid("2f55662a-9233-4f10-89c4-80bf9aa73930"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 12, 30, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1774), false, null, new Guid("4d271309-e20c-4744-9354-cc829ec94d93") },
                    { new Guid("6f2d5670-9c66-4dfe-952b-a0cd633cf86e"), new Guid("12d3de5e-3bad-4c86-959f-2bb38db1e303"), "Interesting perspective on finance.", new DateTime(2024, 12, 31, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1777), false, null, new Guid("4d271309-e20c-4744-9354-cc829ec94d93") },
                    { new Guid("d50e32c6-3d47-4ad1-ac9c-f430611170ce"), new Guid("2f55662a-9233-4f10-89c4-80bf9aa73930"), "I found this article very helpful!", new DateTime(2025, 1, 1, 13, 54, 58, 287, DateTimeKind.Utc).AddTicks(1779), false, null, new Guid("96c05722-8faf-41e8-9ced-9d010d015807") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("28f1433e-67f3-4853-bab0-b4c6e49d8f62"), new Guid("96c05722-8faf-41e8-9ced-9d010d015807"), new Guid("2f55662a-9233-4f10-89c4-80bf9aa73930") },
                    { new Guid("2c0c4755-3993-4894-b150-4fff40720d9a"), new Guid("4d271309-e20c-4744-9354-cc829ec94d93"), new Guid("2f55662a-9233-4f10-89c4-80bf9aa73930") },
                    { new Guid("f324b07a-689a-425e-9491-2935973db65e"), new Guid("4d271309-e20c-4744-9354-cc829ec94d93"), new Guid("12d3de5e-3bad-4c86-959f-2bb38db1e303") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("8b93fce5-3a30-4649-8796-d9f02fce1ea9"), new Guid("4d271309-e20c-4744-9354-cc829ec94d93") },
                    { new Guid("ae975476-7288-4062-b9cd-3783230dd751"), new Guid("4d271309-e20c-4744-9354-cc829ec94d93") },
                    { new Guid("8b93fce5-3a30-4649-8796-d9f02fce1ea9"), new Guid("96c05722-8faf-41e8-9ced-9d010d015807") },
                    { new Guid("af12aaa4-27e4-45a6-a78d-b187fb024f67"), new Guid("96c05722-8faf-41e8-9ced-9d010d015807") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                table: "Comments",
                column: "ParentId",
                principalTable: "Comments",
                principalColumn: "Id");
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
                keyValue: new Guid("03874371-d31a-419f-ac95-576a1c4547a9"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6f2d5670-9c66-4dfe-952b-a0cd633cf86e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d50e32c6-3d47-4ad1-ac9c-f430611170ce"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("28f1433e-67f3-4853-bab0-b4c6e49d8f62"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("2c0c4755-3993-4894-b150-4fff40720d9a"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("f324b07a-689a-425e-9491-2935973db65e"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8b93fce5-3a30-4649-8796-d9f02fce1ea9"), new Guid("4d271309-e20c-4744-9354-cc829ec94d93") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("ae975476-7288-4062-b9cd-3783230dd751"), new Guid("4d271309-e20c-4744-9354-cc829ec94d93") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8b93fce5-3a30-4649-8796-d9f02fce1ea9"), new Guid("96c05722-8faf-41e8-9ced-9d010d015807") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("af12aaa4-27e4-45a6-a78d-b187fb024f67"), new Guid("96c05722-8faf-41e8-9ced-9d010d015807") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("1715cfb6-8cfd-4052-8616-0514f58fba66"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("db9ee1ad-e89a-4584-be6f-b47d74fd9a53"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8b93fce5-3a30-4649-8796-d9f02fce1ea9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ae975476-7288-4062-b9cd-3783230dd751"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af12aaa4-27e4-45a6-a78d-b187fb024f67"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4d271309-e20c-4744-9354-cc829ec94d93"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("96c05722-8faf-41e8-9ced-9d010d015807"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("12d3de5e-3bad-4c86-959f-2bb38db1e303"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2f55662a-9233-4f10-89c4-80bf9aa73930"));

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Comments",
                newName: "ParentCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                newName: "IX_Comments_ParentCommentId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("238f046d-a13f-47b5-8283-1454610d480b"), "Educational articles and resources", "Education" },
                    { new Guid("beaf595b-9f99-4c5f-ad86-3c21da3f3057"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("c79d683a-38a5-458d-b6f8-8552a22776c9"), "Health tips and news", "Health" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"), "johndoe@example.com", null, "$2a$11$ehHI8/IdBp.EryAnY2zkmux.FzidGhyfmlPjp82HKMlOegUKGFIly", "User", "johndoe" },
                    { new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1"), "admin@example.com", null, "$2a$11$116HprAOPEUEWjktKQoTaONDlrJMimNX4ZD266/HVC5UyuVyPtM1a", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3"), new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1"), "Exploring advanced strategies in finance.", new DateTime(2024, 12, 6, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1975), "Advanced Financial Strategies", new DateTime(2024, 12, 24, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1976) },
                    { new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"), new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"), "This is an introductory post about finance.", new DateTime(2024, 12, 16, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1962), "Introduction to Finance", new DateTime(2024, 12, 21, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1974) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("cae438b0-764a-4048-858f-bde9ac724012"), null, "USA", new DateTime(2024, 12, 26, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1915), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 12, 26, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1920), new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3") },
                    { new Guid("f6870b65-18fa-4c3e-8d38-3d75d29cb7b5"), null, "Canada", new DateTime(2024, 12, 26, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1926), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 12, 26, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(1927), new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentCommentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("5d3d7395-baf5-49f6-aace-c813831fee5d"), new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"), "I found this article very helpful!", new DateTime(2024, 12, 23, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(2149), false, null, new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3") },
                    { new Guid("964dbe09-2a98-4f79-a815-38752a9a8cb1"), new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 12, 21, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(2145), false, null, new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f") },
                    { new Guid("bd18bf0b-6213-4272-b68d-734e21198671"), new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1"), "Interesting perspective on finance.", new DateTime(2024, 12, 22, 20, 20, 36, 92, DateTimeKind.Utc).AddTicks(2147), false, null, new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00fd0f1f-10d6-4c35-9d1d-f6d664c8d838"), new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"), new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3") },
                    { new Guid("a9c355d9-e907-4a20-9186-34d6d952e9d3"), new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f"), new Guid("ecfb4c05-83e6-4b2f-b9bf-1437e95373b1") },
                    { new Guid("f3c3f52f-19c3-43f1-aba5-2b1375efb546"), new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3"), new Guid("219bfadc-a09e-4cd6-bb02-d5ee449a24a3") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("238f046d-a13f-47b5-8283-1454610d480b"), new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3") },
                    { new Guid("c79d683a-38a5-458d-b6f8-8552a22776c9"), new Guid("001318f0-05bc-46d1-a770-459fa16fdeb3") },
                    { new Guid("238f046d-a13f-47b5-8283-1454610d480b"), new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f") },
                    { new Guid("beaf595b-9f99-4c5f-ad86-3c21da3f3057"), new Guid("ab609b90-86de-4bf8-944c-ef88b0a4381f") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}

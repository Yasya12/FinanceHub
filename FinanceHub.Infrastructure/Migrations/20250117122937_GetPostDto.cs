using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetPostDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

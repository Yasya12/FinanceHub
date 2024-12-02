using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatePaswordUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2102a8fb-05ac-4682-a1f7-4cfe27a26c8d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b2ea5cdc-8f8c-4228-9aa8-d5e4a73c1e9f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d228ea83-93e5-4be3-a551-2aefb2f5de45"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8eae2d60-414a-4c70-a644-0920606919de"), new Guid("131909b1-e68e-4406-b869-56bab3aa19ea") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("e29af721-d028-41c3-8d38-84e6527b4dee"), new Guid("131909b1-e68e-4406-b869-56bab3aa19ea") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("774c66ff-c56b-4bca-aa33-4ab870b69c4c"), new Guid("419e9abc-c1a6-4906-bdb9-248930e91310") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8eae2d60-414a-4c70-a644-0920606919de"), new Guid("419e9abc-c1a6-4906-bdb9-248930e91310") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d6d475a8-17ed-4dfe-8a74-00ef8ed66d9c"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("f06c1cf3-0e06-4546-a655-dede99eb8728"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("774c66ff-c56b-4bca-aa33-4ab870b69c4c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8eae2d60-414a-4c70-a644-0920606919de"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e29af721-d028-41c3-8d38-84e6527b4dee"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("131909b1-e68e-4406-b869-56bab3aa19ea"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("419e9abc-c1a6-4906-bdb9-248930e91310"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f80892e-ca32-4f1b-a8cd-22871d9dc17c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cc3e5bdb-8f05-436d-b52d-6ea1c1a671b3"));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b"), "Educational articles and resources", "Education" },
                    { new Guid("8ac31ba7-8a58-4692-ae0a-cf02d6743574"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("e25175a8-f9e9-41bc-864a-5eeea13c5860"), "Health tips and news", "Health" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"), "johndoe@example.com", null, "$2a$11$1OgqRLlP414t//YYHJEl1u7Y82rX.PKbWUKIZ5Zi1pkXgE3O26jGm", "User", "johndoe" },
                    { new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c"), "admin@example.com", null, "$2a$11$vx76nutefJewLkSLttyhtujYrsyCahjJef9SbIc4ksoios6hKCofS", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d"), new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c"), "Exploring advanced strategies in finance.", new DateTime(2024, 11, 12, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6343), "Advanced Financial Strategies", new DateTime(2024, 11, 30, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6344) },
                    { new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe"), new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"), "This is an introductory post about finance.", new DateTime(2024, 11, 22, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6326), "Introduction to Finance", new DateTime(2024, 11, 27, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6340) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("9558b8ca-1bc0-4c8d-be21-838885c5f275"), null, "Canada", new DateTime(2024, 12, 2, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6249), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 12, 2, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6252), new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c") },
                    { new Guid("e44c3a89-380b-4d3c-a2de-3fe88c8b1196"), null, "USA", new DateTime(2024, 12, 2, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6235), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 12, 2, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6241), new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "PostId" },
                values: new object[,]
                {
                    { new Guid("32689cf2-a423-41c9-8340-d0e4a05a8414"), new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"), "I found this article very helpful!", new DateTime(2024, 11, 29, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6524), false, new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d") },
                    { new Guid("5e81fbc7-fd97-458d-95e0-87401a32879a"), new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 11, 27, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6518), false, new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe") },
                    { new Guid("c44b8658-6757-40f3-87e4-184d3fbd572b"), new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c"), "Interesting perspective on finance.", new DateTime(2024, 11, 28, 21, 50, 14, 822, DateTimeKind.Utc).AddTicks(6521), false, new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b"), new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d") },
                    { new Guid("e25175a8-f9e9-41bc-864a-5eeea13c5860"), new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d") },
                    { new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b"), new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe") },
                    { new Guid("8ac31ba7-8a58-4692-ae0a-cf02d6743574"), new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("32689cf2-a423-41c9-8340-d0e4a05a8414"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("5e81fbc7-fd97-458d-95e0-87401a32879a"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c44b8658-6757-40f3-87e4-184d3fbd572b"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b"), new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("e25175a8-f9e9-41bc-864a-5eeea13c5860"), new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b"), new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8ac31ba7-8a58-4692-ae0a-cf02d6743574"), new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("9558b8ca-1bc0-4c8d-be21-838885c5f275"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("e44c3a89-380b-4d3c-a2de-3fe88c8b1196"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("29ecf203-8066-4efd-a810-8cd9d2c68d5b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8ac31ba7-8a58-4692-ae0a-cf02d6743574"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e25175a8-f9e9-41bc-864a-5eeea13c5860"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("9987e0b5-c220-4e3f-9a0e-6b9354326e3d"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d54fea16-b1af-4dcf-8ab9-6172f80769fe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("02b849df-5183-4e7d-bae4-03b27dc99a27"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e4726877-6f39-40ac-b501-6b99ccf4075c"));

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("774c66ff-c56b-4bca-aa33-4ab870b69c4c"), "Health tips and news", "Health" },
                    { new Guid("8eae2d60-414a-4c70-a644-0920606919de"), "Educational articles and resources", "Education" },
                    { new Guid("e29af721-d028-41c3-8d38-84e6527b4dee"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("8f80892e-ca32-4f1b-a8cd-22871d9dc17c"), "admin@example.com", null, "$2a$11$tZwdxvnzU0HM0j/WeVuQk.oJeUTZGRHJih9Knp0YcHsWblc5k/RfO", "Admin", "admin" },
                    { new Guid("cc3e5bdb-8f05-436d-b52d-6ea1c1a671b3"), "johndoe@example.com", null, "$2a$11$LGHvkTHCijEYsZupfrxwiO.PDz/WEfD6sBuc3dNDnlpQpX38HKYJu", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("131909b1-e68e-4406-b869-56bab3aa19ea"), new Guid("cc3e5bdb-8f05-436d-b52d-6ea1c1a671b3"), "This is an introductory post about finance.", new DateTime(2024, 11, 22, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(4790), "Introduction to Finance", new DateTime(2024, 11, 27, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(4803) },
                    { new Guid("419e9abc-c1a6-4906-bdb9-248930e91310"), new Guid("8f80892e-ca32-4f1b-a8cd-22871d9dc17c"), "Exploring advanced strategies in finance.", new DateTime(2024, 11, 12, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(4806), "Advanced Financial Strategies", new DateTime(2024, 11, 30, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(4808) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("d6d475a8-17ed-4dfe-8a74-00ef8ed66d9c"), null, "USA", new DateTime(2024, 12, 2, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(4664), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 12, 2, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(4671), new Guid("cc3e5bdb-8f05-436d-b52d-6ea1c1a671b3") },
                    { new Guid("f06c1cf3-0e06-4546-a655-dede99eb8728"), null, "Canada", new DateTime(2024, 12, 2, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(4680), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 12, 2, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(4681), new Guid("8f80892e-ca32-4f1b-a8cd-22871d9dc17c") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "PostId" },
                values: new object[,]
                {
                    { new Guid("2102a8fb-05ac-4682-a1f7-4cfe27a26c8d"), new Guid("cc3e5bdb-8f05-436d-b52d-6ea1c1a671b3"), "I found this article very helpful!", new DateTime(2024, 11, 29, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(5018), false, new Guid("419e9abc-c1a6-4906-bdb9-248930e91310") },
                    { new Guid("b2ea5cdc-8f8c-4228-9aa8-d5e4a73c1e9f"), new Guid("8f80892e-ca32-4f1b-a8cd-22871d9dc17c"), "Interesting perspective on finance.", new DateTime(2024, 11, 28, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(5015), false, new Guid("131909b1-e68e-4406-b869-56bab3aa19ea") },
                    { new Guid("d228ea83-93e5-4be3-a551-2aefb2f5de45"), new Guid("cc3e5bdb-8f05-436d-b52d-6ea1c1a671b3"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 11, 27, 21, 35, 46, 870, DateTimeKind.Utc).AddTicks(5011), false, new Guid("131909b1-e68e-4406-b869-56bab3aa19ea") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("8eae2d60-414a-4c70-a644-0920606919de"), new Guid("131909b1-e68e-4406-b869-56bab3aa19ea") },
                    { new Guid("e29af721-d028-41c3-8d38-84e6527b4dee"), new Guid("131909b1-e68e-4406-b869-56bab3aa19ea") },
                    { new Guid("774c66ff-c56b-4bca-aa33-4ab870b69c4c"), new Guid("419e9abc-c1a6-4906-bdb9-248930e91310") },
                    { new Guid("8eae2d60-414a-4c70-a644-0920606919de"), new Guid("419e9abc-c1a6-4906-bdb9-248930e91310") }
                });
        }
    }
}

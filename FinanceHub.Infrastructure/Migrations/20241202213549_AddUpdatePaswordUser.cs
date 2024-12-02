using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatePaswordUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

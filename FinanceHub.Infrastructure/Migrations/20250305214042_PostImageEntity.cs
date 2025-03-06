using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PostImageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("102d1f75-cfaa-47ed-bd59-56c8a60de875"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("58235f93-2675-40b8-a006-49cfd49a7ecb"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("d082a51b-d7a5-42a7-989b-f6536e6a2ee3"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("6ea8eed0-d8a7-41b6-ab85-f2a1bc409c91"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("88bbf1d7-1be8-4673-8367-2afc32168d02"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("8d525401-1d54-427c-bc6e-b995e8786e98"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("3801dd2e-36c1-429f-8e4a-c02a7ad629ad"), new Guid("44769ea3-28d8-481c-9842-f692827ef41f") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("45783676-e41f-4320-b587-6d49cc7f2922"), new Guid("44769ea3-28d8-481c-9842-f692827ef41f") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("45783676-e41f-4320-b587-6d49cc7f2922"), new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("83eba80b-b471-4dea-af24-f262728d7e90"), new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2b184702-18d5-44d1-8730-2a1ab3648010"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("c049e75d-ccd9-4c57-a507-75a16b397965"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3801dd2e-36c1-429f-8e4a-c02a7ad629ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45783676-e41f-4320-b587-6d49cc7f2922"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83eba80b-b471-4dea-af24-f262728d7e90"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("44769ea3-28d8-481c-9842-f692827ef41f"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4f349137-6acd-44e1-9ad0-c45dd2f6e6c1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fb0d98e9-19d6-4a71-a09b-2a72d08103fc"));

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("470953b1-e962-4e5f-bf4e-6e6c98dc7752"), "Educational articles and resources", "Education" },
                    { new Guid("6cbc0079-47f1-40b9-8e97-4d70adfa966d"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("f2bfa6f5-eacf-4842-9e83-04012e4224eb"), "Health tips and news", "Health" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("a426be89-8341-40ae-880e-88d835306448"), "admin@example.com", null, "$2a$11$jjeR6TeYkYrpDzYtMLFx3u9n5A14yINdcHcGhhWTmJ2PS1cRDIfzC", "Admin", "admin" },
                    { new Guid("b2d019d2-e66a-4b33-8cfe-e75b1c067734"), "johndoe@example.com", null, "$2a$11$o6JmxESnI9XjnciOhL0t3.7v9seABFN0KHFfm3uMzXWrECXQAB8bG", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("59abfdc7-830c-4965-9912-334d4720020d"), new Guid("a426be89-8341-40ae-880e-88d835306448"), "Exploring advanced strategies in finance.", new DateTime(2025, 2, 13, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8376), "Advanced Financial Strategies", new DateTime(2025, 3, 3, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8377) },
                    { new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132"), new Guid("b2d019d2-e66a-4b33-8cfe-e75b1c067734"), "This is an introductory post about finance.", new DateTime(2025, 2, 23, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8350), "Introduction to Finance", new DateTime(2025, 2, 28, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8372) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("860bcbd4-84dd-48bf-9686-ef7b108ea138"), null, "Canada", new DateTime(2025, 3, 5, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8038), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 3, 5, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8039), new Guid("a426be89-8341-40ae-880e-88d835306448") },
                    { new Guid("d5037723-bf34-4e96-bf48-2bae8f526243"), null, "USA", new DateTime(2025, 3, 5, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8015), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 3, 5, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8023), new Guid("b2d019d2-e66a-4b33-8cfe-e75b1c067734") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("2a8f6005-31a3-4b56-8efb-b6f7658f9640"), new Guid("a426be89-8341-40ae-880e-88d835306448"), "Interesting perspective on finance.", new DateTime(2025, 3, 1, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8662), false, null, new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132") },
                    { new Guid("b7995c93-8c6b-4cec-ab5f-f2f2cbc410f7"), new Guid("b2d019d2-e66a-4b33-8cfe-e75b1c067734"), "I found this article very helpful!", new DateTime(2025, 3, 2, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8665), false, null, new Guid("59abfdc7-830c-4965-9912-334d4720020d") },
                    { new Guid("ef33c2f1-3b94-48b4-b37d-b0a481e4ca80"), new Guid("b2d019d2-e66a-4b33-8cfe-e75b1c067734"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 2, 28, 21, 40, 39, 929, DateTimeKind.Utc).AddTicks(8657), false, null, new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6ab3e655-0efa-4022-8633-0da1a8a1e441"), new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132"), new Guid("a426be89-8341-40ae-880e-88d835306448") },
                    { new Guid("e73689ab-1ea9-4d53-9361-2b46ae44d8d8"), new Guid("59abfdc7-830c-4965-9912-334d4720020d"), new Guid("b2d019d2-e66a-4b33-8cfe-e75b1c067734") },
                    { new Guid("eb2d3bb9-49fe-498f-8ad4-28105ca3b060"), new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132"), new Guid("b2d019d2-e66a-4b33-8cfe-e75b1c067734") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("470953b1-e962-4e5f-bf4e-6e6c98dc7752"), new Guid("59abfdc7-830c-4965-9912-334d4720020d") },
                    { new Guid("f2bfa6f5-eacf-4842-9e83-04012e4224eb"), new Guid("59abfdc7-830c-4965-9912-334d4720020d") },
                    { new Guid("470953b1-e962-4e5f-bf4e-6e6c98dc7752"), new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132") },
                    { new Guid("6cbc0079-47f1-40b9-8e97-4d70adfa966d"), new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("2a8f6005-31a3-4b56-8efb-b6f7658f9640"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("b7995c93-8c6b-4cec-ab5f-f2f2cbc410f7"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("ef33c2f1-3b94-48b4-b37d-b0a481e4ca80"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("6ab3e655-0efa-4022-8633-0da1a8a1e441"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("e73689ab-1ea9-4d53-9361-2b46ae44d8d8"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("eb2d3bb9-49fe-498f-8ad4-28105ca3b060"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("470953b1-e962-4e5f-bf4e-6e6c98dc7752"), new Guid("59abfdc7-830c-4965-9912-334d4720020d") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("f2bfa6f5-eacf-4842-9e83-04012e4224eb"), new Guid("59abfdc7-830c-4965-9912-334d4720020d") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("470953b1-e962-4e5f-bf4e-6e6c98dc7752"), new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("6cbc0079-47f1-40b9-8e97-4d70adfa966d"), new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("860bcbd4-84dd-48bf-9686-ef7b108ea138"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("d5037723-bf34-4e96-bf48-2bae8f526243"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("470953b1-e962-4e5f-bf4e-6e6c98dc7752"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6cbc0079-47f1-40b9-8e97-4d70adfa966d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f2bfa6f5-eacf-4842-9e83-04012e4224eb"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("59abfdc7-830c-4965-9912-334d4720020d"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("75df5b0b-5a20-460a-99a1-52b4b977f132"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a426be89-8341-40ae-880e-88d835306448"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2d019d2-e66a-4b33-8cfe-e75b1c067734"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3801dd2e-36c1-429f-8e4a-c02a7ad629ad"), "Health tips and news", "Health" },
                    { new Guid("45783676-e41f-4320-b587-6d49cc7f2922"), "Educational articles and resources", "Education" },
                    { new Guid("83eba80b-b471-4dea-af24-f262728d7e90"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("4f349137-6acd-44e1-9ad0-c45dd2f6e6c1"), "admin@example.com", null, "$2a$11$PyVHSK0NSOVcOLyCp/WmTOUST5kMXDdoqStqIzLJvDI/cfyCq5UsW", "Admin", "admin" },
                    { new Guid("fb0d98e9-19d6-4a71-a09b-2a72d08103fc"), "johndoe@example.com", null, "$2a$11$Fzr18ShuWVozTJRj2r7mg.Xye2oSrrEFygHaMCxE4I9aIvJbkMgnW", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("44769ea3-28d8-481c-9842-f692827ef41f"), new Guid("4f349137-6acd-44e1-9ad0-c45dd2f6e6c1"), "Exploring advanced strategies in finance.", new DateTime(2025, 1, 29, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(6908), "Advanced Financial Strategies", new DateTime(2025, 2, 16, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(6909) },
                    { new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee"), new Guid("fb0d98e9-19d6-4a71-a09b-2a72d08103fc"), "This is an introductory post about finance.", new DateTime(2025, 2, 8, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(6871), "Introduction to Finance", new DateTime(2025, 2, 13, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(6887) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2b184702-18d5-44d1-8730-2a1ab3648010"), null, "USA", new DateTime(2025, 2, 18, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(6712), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 2, 18, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(6715), new Guid("fb0d98e9-19d6-4a71-a09b-2a72d08103fc") },
                    { new Guid("c049e75d-ccd9-4c57-a507-75a16b397965"), null, "Canada", new DateTime(2025, 2, 18, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(6724), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 2, 18, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(6724), new Guid("4f349137-6acd-44e1-9ad0-c45dd2f6e6c1") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("102d1f75-cfaa-47ed-bd59-56c8a60de875"), new Guid("fb0d98e9-19d6-4a71-a09b-2a72d08103fc"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 2, 13, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(7082), false, null, new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee") },
                    { new Guid("58235f93-2675-40b8-a006-49cfd49a7ecb"), new Guid("fb0d98e9-19d6-4a71-a09b-2a72d08103fc"), "I found this article very helpful!", new DateTime(2025, 2, 15, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(7086), false, null, new Guid("44769ea3-28d8-481c-9842-f692827ef41f") },
                    { new Guid("d082a51b-d7a5-42a7-989b-f6536e6a2ee3"), new Guid("4f349137-6acd-44e1-9ad0-c45dd2f6e6c1"), "Interesting perspective on finance.", new DateTime(2025, 2, 14, 12, 43, 3, 93, DateTimeKind.Utc).AddTicks(7084), false, null, new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6ea8eed0-d8a7-41b6-ab85-f2a1bc409c91"), new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee"), new Guid("fb0d98e9-19d6-4a71-a09b-2a72d08103fc") },
                    { new Guid("88bbf1d7-1be8-4673-8367-2afc32168d02"), new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee"), new Guid("4f349137-6acd-44e1-9ad0-c45dd2f6e6c1") },
                    { new Guid("8d525401-1d54-427c-bc6e-b995e8786e98"), new Guid("44769ea3-28d8-481c-9842-f692827ef41f"), new Guid("fb0d98e9-19d6-4a71-a09b-2a72d08103fc") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("3801dd2e-36c1-429f-8e4a-c02a7ad629ad"), new Guid("44769ea3-28d8-481c-9842-f692827ef41f") },
                    { new Guid("45783676-e41f-4320-b587-6d49cc7f2922"), new Guid("44769ea3-28d8-481c-9842-f692827ef41f") },
                    { new Guid("45783676-e41f-4320-b587-6d49cc7f2922"), new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee") },
                    { new Guid("83eba80b-b471-4dea-af24-f262728d7e90"), new Guid("6fa2c53c-2141-4006-b6a7-a3470fda76ee") }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostWithoutTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("71fc03fe-5e35-4bd4-8f8f-3b42aefd6913"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("8ba4b470-2abe-490d-ad06-3a7f0ceb2ae3"), "Educational articles and resources", "Education" },
                    { new Guid("999e4b29-932a-4344-a8da-7fb86916d314"), "Health tips and news", "Health" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("e7181379-58ee-471f-a16e-6380a7f4d5f2"), "johndoe@example.com", null, "$2a$11$XSAfyoZSC.WpKUjsrKhTd.22frZcqWQ3qzG5HoRaHBq/bUy2fiM1G", "User", "johndoe" },
                    { new Guid("fc62f35c-e195-4e04-9ed9-605a18f35e7a"), "admin@example.com", null, "$2a$11$Rx6ag/ZaTZIil0cNO77YteNRWTx5lbNz1mM7LUK7hYMRUOOqIUGem", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("71d711d5-c01c-4b3a-917a-466afb57533e"), new Guid("fc62f35c-e195-4e04-9ed9-605a18f35e7a"), "Exploring advanced strategies in finance.", new DateTime(2025, 2, 13, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5159), new DateTime(2025, 3, 3, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5160) },
                    { new Guid("f3c74e04-703f-49ab-a095-117b03e02199"), new Guid("e7181379-58ee-471f-a16e-6380a7f4d5f2"), "This is an introductory post about finance.", new DateTime(2025, 2, 23, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5137), new DateTime(2025, 2, 28, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5157) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("32dcf723-4ca8-412a-a7a5-a6b9f1397eef"), null, "Canada", new DateTime(2025, 3, 5, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5046), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 3, 5, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5047), new Guid("fc62f35c-e195-4e04-9ed9-605a18f35e7a") },
                    { new Guid("baf274e7-e550-43d1-bb87-3fdba2313e90"), null, "USA", new DateTime(2025, 3, 5, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5007), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 3, 5, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5013), new Guid("e7181379-58ee-471f-a16e-6380a7f4d5f2") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("27d24926-2bb2-4b22-b201-f10a5258185d"), new Guid("e7181379-58ee-471f-a16e-6380a7f4d5f2"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 2, 28, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5816), false, null, new Guid("f3c74e04-703f-49ab-a095-117b03e02199") },
                    { new Guid("942e5943-4ef6-4139-9081-960e6ca21fde"), new Guid("fc62f35c-e195-4e04-9ed9-605a18f35e7a"), "Interesting perspective on finance.", new DateTime(2025, 3, 1, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5820), false, null, new Guid("f3c74e04-703f-49ab-a095-117b03e02199") },
                    { new Guid("f13b10e4-6ac1-4949-8581-cbdc2fa83332"), new Guid("e7181379-58ee-471f-a16e-6380a7f4d5f2"), "I found this article very helpful!", new DateTime(2025, 3, 2, 21, 53, 43, 576, DateTimeKind.Utc).AddTicks(5823), false, null, new Guid("71d711d5-c01c-4b3a-917a-466afb57533e") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("060c2ab6-41d0-4c02-9e73-5314279dab1f"), new Guid("71d711d5-c01c-4b3a-917a-466afb57533e"), new Guid("e7181379-58ee-471f-a16e-6380a7f4d5f2") },
                    { new Guid("65a19543-f292-4238-b93e-7823b90389ae"), new Guid("f3c74e04-703f-49ab-a095-117b03e02199"), new Guid("e7181379-58ee-471f-a16e-6380a7f4d5f2") },
                    { new Guid("cbe01781-437d-456d-9fe3-c949cebc0b02"), new Guid("f3c74e04-703f-49ab-a095-117b03e02199"), new Guid("fc62f35c-e195-4e04-9ed9-605a18f35e7a") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("8ba4b470-2abe-490d-ad06-3a7f0ceb2ae3"), new Guid("71d711d5-c01c-4b3a-917a-466afb57533e") },
                    { new Guid("999e4b29-932a-4344-a8da-7fb86916d314"), new Guid("71d711d5-c01c-4b3a-917a-466afb57533e") },
                    { new Guid("71fc03fe-5e35-4bd4-8f8f-3b42aefd6913"), new Guid("f3c74e04-703f-49ab-a095-117b03e02199") },
                    { new Guid("8ba4b470-2abe-490d-ad06-3a7f0ceb2ae3"), new Guid("f3c74e04-703f-49ab-a095-117b03e02199") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("27d24926-2bb2-4b22-b201-f10a5258185d"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("942e5943-4ef6-4139-9081-960e6ca21fde"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f13b10e4-6ac1-4949-8581-cbdc2fa83332"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("060c2ab6-41d0-4c02-9e73-5314279dab1f"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("65a19543-f292-4238-b93e-7823b90389ae"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("cbe01781-437d-456d-9fe3-c949cebc0b02"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8ba4b470-2abe-490d-ad06-3a7f0ceb2ae3"), new Guid("71d711d5-c01c-4b3a-917a-466afb57533e") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("999e4b29-932a-4344-a8da-7fb86916d314"), new Guid("71d711d5-c01c-4b3a-917a-466afb57533e") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("71fc03fe-5e35-4bd4-8f8f-3b42aefd6913"), new Guid("f3c74e04-703f-49ab-a095-117b03e02199") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8ba4b470-2abe-490d-ad06-3a7f0ceb2ae3"), new Guid("f3c74e04-703f-49ab-a095-117b03e02199") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("32dcf723-4ca8-412a-a7a5-a6b9f1397eef"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("baf274e7-e550-43d1-bb87-3fdba2313e90"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("71fc03fe-5e35-4bd4-8f8f-3b42aefd6913"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8ba4b470-2abe-490d-ad06-3a7f0ceb2ae3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("999e4b29-932a-4344-a8da-7fb86916d314"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("71d711d5-c01c-4b3a-917a-466afb57533e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f3c74e04-703f-49ab-a095-117b03e02199"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e7181379-58ee-471f-a16e-6380a7f4d5f2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fc62f35c-e195-4e04-9ed9-605a18f35e7a"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostInclude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("32f71a81-c3b3-4507-ac9f-6fa491a03b7a"), "Health tips and news", "Health" },
                    { new Guid("86497c23-71e1-422b-9277-ec7d1447a171"), "Educational articles and resources", "Education" },
                    { new Guid("d59b4646-a0af-4e52-93d5-c32fbb7b0455"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("1723aa3a-e786-40a2-a11e-5405412087fb"), "admin@example.com", null, "$2a$11$mPjgd2aHQAoeQBaGUgihme6dRfFLoRzRGDAk7zmtiDhpCPb2jHAzy", "Admin", "admin" },
                    { new Guid("6bf0beb1-eced-445e-a21b-135a28e0935f"), "johndoe@example.com", null, "$2a$11$bDFpYF2U3PpGqh0VFXg7CefHN8BcYCsOY5m/v8ZickSwKrbsHQjWa", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4cd9fc93-2626-4a10-b21a-b452005c9575"), new Guid("1723aa3a-e786-40a2-a11e-5405412087fb"), "Exploring advanced strategies in finance.", new DateTime(2025, 2, 14, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(422), new DateTime(2025, 3, 4, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(424) },
                    { new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4"), new Guid("6bf0beb1-eced-445e-a21b-135a28e0935f"), "This is an introductory post about finance.", new DateTime(2025, 2, 24, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(406), new DateTime(2025, 3, 1, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(419) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("df42c95f-5c19-4c0b-ae7a-402bd681a436"), null, "Canada", new DateTime(2025, 3, 6, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(326), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 3, 6, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(327), new Guid("1723aa3a-e786-40a2-a11e-5405412087fb") },
                    { new Guid("fedf12a8-2cec-46c0-b2da-486e1c9d15cc"), null, "USA", new DateTime(2025, 3, 6, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(281), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 3, 6, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(289), new Guid("6bf0beb1-eced-445e-a21b-135a28e0935f") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("062649d0-7737-4227-a570-ef8830428b1c"), new Guid("1723aa3a-e786-40a2-a11e-5405412087fb"), "Interesting perspective on finance.", new DateTime(2025, 3, 2, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(683), false, null, new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4") },
                    { new Guid("4372cd1f-88d2-47c1-94fd-ea3efc6eb60f"), new Guid("6bf0beb1-eced-445e-a21b-135a28e0935f"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 3, 1, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(678), false, null, new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4") },
                    { new Guid("9b7587d8-a87f-4e56-8dd4-9ffac2b3645f"), new Guid("6bf0beb1-eced-445e-a21b-135a28e0935f"), "I found this article very helpful!", new DateTime(2025, 3, 3, 13, 5, 43, 184, DateTimeKind.Utc).AddTicks(688), false, null, new Guid("4cd9fc93-2626-4a10-b21a-b452005c9575") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1424a176-5dc5-4212-b940-9fe3a24f320b"), new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4"), new Guid("6bf0beb1-eced-445e-a21b-135a28e0935f") },
                    { new Guid("56c6e309-c6c6-4bc3-b021-82aaa4bc99d5"), new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4"), new Guid("1723aa3a-e786-40a2-a11e-5405412087fb") },
                    { new Guid("defcd80b-80f6-45cb-86c6-9f5ee67e2161"), new Guid("4cd9fc93-2626-4a10-b21a-b452005c9575"), new Guid("6bf0beb1-eced-445e-a21b-135a28e0935f") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("32f71a81-c3b3-4507-ac9f-6fa491a03b7a"), new Guid("4cd9fc93-2626-4a10-b21a-b452005c9575") },
                    { new Guid("86497c23-71e1-422b-9277-ec7d1447a171"), new Guid("4cd9fc93-2626-4a10-b21a-b452005c9575") },
                    { new Guid("86497c23-71e1-422b-9277-ec7d1447a171"), new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4") },
                    { new Guid("d59b4646-a0af-4e52-93d5-c32fbb7b0455"), new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostImages_Posts_PostId",
                table: "PostImages");

            migrationBuilder.DropIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("062649d0-7737-4227-a570-ef8830428b1c"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("4372cd1f-88d2-47c1-94fd-ea3efc6eb60f"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("9b7587d8-a87f-4e56-8dd4-9ffac2b3645f"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("1424a176-5dc5-4212-b940-9fe3a24f320b"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("56c6e309-c6c6-4bc3-b021-82aaa4bc99d5"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("defcd80b-80f6-45cb-86c6-9f5ee67e2161"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("32f71a81-c3b3-4507-ac9f-6fa491a03b7a"), new Guid("4cd9fc93-2626-4a10-b21a-b452005c9575") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("86497c23-71e1-422b-9277-ec7d1447a171"), new Guid("4cd9fc93-2626-4a10-b21a-b452005c9575") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("86497c23-71e1-422b-9277-ec7d1447a171"), new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("d59b4646-a0af-4e52-93d5-c32fbb7b0455"), new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("df42c95f-5c19-4c0b-ae7a-402bd681a436"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("fedf12a8-2cec-46c0-b2da-486e1c9d15cc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("32f71a81-c3b3-4507-ac9f-6fa491a03b7a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("86497c23-71e1-422b-9277-ec7d1447a171"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d59b4646-a0af-4e52-93d5-c32fbb7b0455"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4cd9fc93-2626-4a10-b21a-b452005c9575"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("de5b581c-1ed7-4dc7-b898-47b45a761ab4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1723aa3a-e786-40a2-a11e-5405412087fb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6bf0beb1-eced-445e-a21b-135a28e0935f"));

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
    }
}

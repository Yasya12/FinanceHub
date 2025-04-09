using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

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

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "Messages",
                newName: "MessageSent");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatId",
                table: "Messages",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRead",
                table: "Messages",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RecipientDeleted",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "RecipientId",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "RecipientUserName",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "SenderDeleted",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SenderUserName",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1c0e1e80-eae6-4287-aa8c-dfadab51d796"), "Health tips and news", "Health" },
                    { new Guid("6335c0a7-1109-4642-adc9-55ec65e62a82"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("be2dd418-b8b3-4902-853c-4ae820650827"), "Educational articles and resources", "Education" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("4e34770a-3344-423e-87f5-93270f26dbe6"), "admin@example.com", null, "$2a$11$HB/WAJEPusbgIGeBC/u1o.SeDV1Pz4/eTakUprco2GRsaooNpekQi", "Admin", "admin" },
                    { new Guid("ad642642-4115-43ff-82cf-05ea5839b277"), "johndoe@example.com", null, "$2a$11$Ju6ED706Bxw4XSdWnbk5AukmfctUehd9JVl70FLotyR4YSrKY6S02", "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0a261564-7fba-46f8-88ef-500d969034c9"), new Guid("4e34770a-3344-423e-87f5-93270f26dbe6"), "Exploring advanced strategies in finance.", new DateTime(2025, 3, 18, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5168), new DateTime(2025, 4, 5, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5168) },
                    { new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614"), new Guid("ad642642-4115-43ff-82cf-05ea5839b277"), "This is an introductory post about finance.", new DateTime(2025, 3, 28, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5155), new DateTime(2025, 4, 2, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5166) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("830f5b55-d39f-4f0f-9ea7-61c4d8ee75f7"), null, "Canada", new DateTime(2025, 4, 7, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5097), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 4, 7, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5097), new Guid("4e34770a-3344-423e-87f5-93270f26dbe6") },
                    { new Guid("93ffbe63-53b1-487f-9fb4-5abb796acd09"), null, "USA", new DateTime(2025, 4, 7, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5085), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 4, 7, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5089), new Guid("ad642642-4115-43ff-82cf-05ea5839b277") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("38271cf6-9f31-45e2-b1b3-c78d4c2e9c86"), new Guid("ad642642-4115-43ff-82cf-05ea5839b277"), "I found this article very helpful!", new DateTime(2025, 4, 4, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5315), false, null, new Guid("0a261564-7fba-46f8-88ef-500d969034c9") },
                    { new Guid("6726172f-1ded-4791-97de-a42209b9f500"), new Guid("ad642642-4115-43ff-82cf-05ea5839b277"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 4, 2, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5311), false, null, new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614") },
                    { new Guid("aaab5b1d-0593-4904-b1a8-4ec532dd3eee"), new Guid("4e34770a-3344-423e-87f5-93270f26dbe6"), "Interesting perspective on finance.", new DateTime(2025, 4, 3, 21, 7, 39, 182, DateTimeKind.Utc).AddTicks(5313), false, null, new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4cf3bb66-e693-4dd6-ad09-80e5ef86c51b"), new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614"), new Guid("4e34770a-3344-423e-87f5-93270f26dbe6") },
                    { new Guid("81c6943c-3297-4687-9fb7-a3c5b5bf1dc4"), new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614"), new Guid("ad642642-4115-43ff-82cf-05ea5839b277") },
                    { new Guid("a317be43-2b28-4ede-afe3-5ad69ad6371a"), new Guid("0a261564-7fba-46f8-88ef-500d969034c9"), new Guid("ad642642-4115-43ff-82cf-05ea5839b277") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("1c0e1e80-eae6-4287-aa8c-dfadab51d796"), new Guid("0a261564-7fba-46f8-88ef-500d969034c9") },
                    { new Guid("be2dd418-b8b3-4902-853c-4ae820650827"), new Guid("0a261564-7fba-46f8-88ef-500d969034c9") },
                    { new Guid("6335c0a7-1109-4642-adc9-55ec65e62a82"), new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614") },
                    { new Guid("be2dd418-b8b3-4902-853c-4ae820650827"), new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RecipientId",
                table: "Messages",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecipientId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("38271cf6-9f31-45e2-b1b3-c78d4c2e9c86"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6726172f-1ded-4791-97de-a42209b9f500"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("aaab5b1d-0593-4904-b1a8-4ec532dd3eee"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("4cf3bb66-e693-4dd6-ad09-80e5ef86c51b"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("81c6943c-3297-4687-9fb7-a3c5b5bf1dc4"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("a317be43-2b28-4ede-afe3-5ad69ad6371a"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("1c0e1e80-eae6-4287-aa8c-dfadab51d796"), new Guid("0a261564-7fba-46f8-88ef-500d969034c9") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("be2dd418-b8b3-4902-853c-4ae820650827"), new Guid("0a261564-7fba-46f8-88ef-500d969034c9") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("6335c0a7-1109-4642-adc9-55ec65e62a82"), new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("be2dd418-b8b3-4902-853c-4ae820650827"), new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("830f5b55-d39f-4f0f-9ea7-61c4d8ee75f7"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("93ffbe63-53b1-487f-9fb4-5abb796acd09"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c0e1e80-eae6-4287-aa8c-dfadab51d796"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6335c0a7-1109-4642-adc9-55ec65e62a82"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be2dd418-b8b3-4902-853c-4ae820650827"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("0a261564-7fba-46f8-88ef-500d969034c9"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("811411fd-52bf-4bf0-93eb-af263cbfe614"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e34770a-3344-423e-87f5-93270f26dbe6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ad642642-4115-43ff-82cf-05ea5839b277"));

            migrationBuilder.DropColumn(
                name: "DateRead",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecipientDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecipientUserName",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderUserName",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "MessageSent",
                table: "Messages",
                newName: "SentAt");

            migrationBuilder.AlterColumn<Guid>(
                name: "ChatId",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

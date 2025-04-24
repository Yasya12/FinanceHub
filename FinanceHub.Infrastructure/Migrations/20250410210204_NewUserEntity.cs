using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

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

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Users",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6b695c17-f515-419d-b844-8cdc79b76f2d"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("8a8cc765-ca45-4a06-b592-849da1f14dc5"), "Educational articles and resources", "Education" },
                    { new Guid("ae6798c5-4dcb-4e02-97b3-3544beb8d32b"), "Health tips and news", "Health" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "Email", "GoogleId", "LastActive", "PasswordHash", "ProfilePictureUrl", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("89a173fe-8c3a-4e23-85b6-814a0bbf7720"), null, "England", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$PdBQPfe1POZsJs8Y9cQIIuYKrE0LwYPE6e.Mp8kmRn2F8kGIwpnje", null, "Admin", "admin" },
                    { new Guid("cf9827dd-b0a6-49d1-9c21-a30bcb0ee7e0"), "Passionate about smart money management and personal growth. Tracking goals, budgeting wisely, and always learning something new about finance.", "Ukraine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa@1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$Cu5KwehjUzMYcRIduLx6y.ugouInTJITiggRCg5fPvWrEO.u/YPc.", null, "User", "Lisa" },
                    { new Guid("ef733c46-60ea-486b-a693-e7f8ba4124a1"), null, "Ukraine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$qgTIOQNt00pEUs9qoy25duqrufxK3C20LfrkJIzlVVsxYpGLETtwy", null, "User", "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("cc525251-1838-42a5-b9da-4a036c150925"), new Guid("ef733c46-60ea-486b-a693-e7f8ba4124a1"), "This is an introductory post about finance.", new DateTime(2025, 3, 31, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(513), new DateTime(2025, 4, 5, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(528) },
                    { new Guid("e2be4e78-38e0-4384-8958-ed2a0349336e"), new Guid("89a173fe-8c3a-4e23-85b6-814a0bbf7720"), "Exploring advanced strategies in finance.", new DateTime(2025, 3, 21, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(531), new DateTime(2025, 4, 8, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(533) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("0454ed3a-660a-4d9b-8f4d-8995b01cb642"), null, "USA", new DateTime(2025, 4, 10, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(461), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 4, 10, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(464), new Guid("ef733c46-60ea-486b-a693-e7f8ba4124a1") },
                    { new Guid("1c97e177-3b2a-4c7e-9b64-99ea919b4ab2"), null, "Canada", new DateTime(2025, 4, 10, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(473), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 4, 10, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(473), new Guid("89a173fe-8c3a-4e23-85b6-814a0bbf7720") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("0fadbcb1-097b-4f85-acae-542bd02a1de2"), new Guid("ef733c46-60ea-486b-a693-e7f8ba4124a1"), "I found this article very helpful!", new DateTime(2025, 4, 7, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(785), false, null, new Guid("e2be4e78-38e0-4384-8958-ed2a0349336e") },
                    { new Guid("625b27fe-7b6e-46ff-9ffa-2c8735956890"), new Guid("ef733c46-60ea-486b-a693-e7f8ba4124a1"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 4, 5, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(782), false, null, new Guid("cc525251-1838-42a5-b9da-4a036c150925") },
                    { new Guid("f471bced-413f-447e-82ef-9a637b41a3aa"), new Guid("89a173fe-8c3a-4e23-85b6-814a0bbf7720"), "Interesting perspective on finance.", new DateTime(2025, 4, 6, 21, 2, 4, 211, DateTimeKind.Utc).AddTicks(784), false, null, new Guid("cc525251-1838-42a5-b9da-4a036c150925") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("12d1c41c-a1f2-47e6-85b9-df387a59c934"), new Guid("cc525251-1838-42a5-b9da-4a036c150925"), new Guid("89a173fe-8c3a-4e23-85b6-814a0bbf7720") },
                    { new Guid("6c31f8df-12c3-4547-b659-a12e362e2554"), new Guid("cc525251-1838-42a5-b9da-4a036c150925"), new Guid("ef733c46-60ea-486b-a693-e7f8ba4124a1") },
                    { new Guid("a4398996-e5e6-4399-9de6-88803278e37f"), new Guid("e2be4e78-38e0-4384-8958-ed2a0349336e"), new Guid("ef733c46-60ea-486b-a693-e7f8ba4124a1") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("6b695c17-f515-419d-b844-8cdc79b76f2d"), new Guid("cc525251-1838-42a5-b9da-4a036c150925") },
                    { new Guid("8a8cc765-ca45-4a06-b592-849da1f14dc5"), new Guid("cc525251-1838-42a5-b9da-4a036c150925") },
                    { new Guid("8a8cc765-ca45-4a06-b592-849da1f14dc5"), new Guid("e2be4e78-38e0-4384-8958-ed2a0349336e") },
                    { new Guid("ae6798c5-4dcb-4e02-97b3-3544beb8d32b"), new Guid("e2be4e78-38e0-4384-8958-ed2a0349336e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("0fadbcb1-097b-4f85-acae-542bd02a1de2"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("625b27fe-7b6e-46ff-9ffa-2c8735956890"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f471bced-413f-447e-82ef-9a637b41a3aa"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("12d1c41c-a1f2-47e6-85b9-df387a59c934"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("6c31f8df-12c3-4547-b659-a12e362e2554"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("a4398996-e5e6-4399-9de6-88803278e37f"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("6b695c17-f515-419d-b844-8cdc79b76f2d"), new Guid("cc525251-1838-42a5-b9da-4a036c150925") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8a8cc765-ca45-4a06-b592-849da1f14dc5"), new Guid("cc525251-1838-42a5-b9da-4a036c150925") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8a8cc765-ca45-4a06-b592-849da1f14dc5"), new Guid("e2be4e78-38e0-4384-8958-ed2a0349336e") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("ae6798c5-4dcb-4e02-97b3-3544beb8d32b"), new Guid("e2be4e78-38e0-4384-8958-ed2a0349336e") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("0454ed3a-660a-4d9b-8f4d-8995b01cb642"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("1c97e177-3b2a-4c7e-9b64-99ea919b4ab2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf9827dd-b0a6-49d1-9c21-a30bcb0ee7e0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b695c17-f515-419d-b844-8cdc79b76f2d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8a8cc765-ca45-4a06-b592-849da1f14dc5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ae6798c5-4dcb-4e02-97b3-3544beb8d32b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("cc525251-1838-42a5-b9da-4a036c150925"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e2be4e78-38e0-4384-8958-ed2a0349336e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("89a173fe-8c3a-4e23-85b6-814a0bbf7720"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef733c46-60ea-486b-a693-e7f8ba4124a1"));

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "Users");

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
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("4621b6b0-cb9e-4b6b-bab3-d7e489df70f4"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("8c1fe985-32be-498d-a1b9-4dcff7408128"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("aa0425c6-9954-4bc0-8767-af32d8b06bb8"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("9e8fc937-e340-44a6-bfaa-a2d8d05eb101"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("d8dc2fdb-6627-42ed-b3d0-3900dcfac950"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("dcefe575-55df-434d-966c-188f66571228"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("2aa35fa3-47dc-4ad5-83d7-c6514cfbbc1e"), new Guid("4f60d2e2-6571-4055-b306-8607e05ad79b") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("5eb1f688-ca20-4312-9bcd-96a0efeee726"), new Guid("4f60d2e2-6571-4055-b306-8607e05ad79b") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("17259606-5644-4b88-a84d-b0d379eeee4b"), new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("5eb1f688-ca20-4312-9bcd-96a0efeee726"), new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("55ef6de5-8aa2-43ed-ab0b-9bd10bde24c0"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("63689d23-d462-48fc-9f16-66c60ca7a58c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17259606-5644-4b88-a84d-b0d379eeee4b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2aa35fa3-47dc-4ad5-83d7-c6514cfbbc1e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5eb1f688-ca20-4312-9bcd-96a0efeee726"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("4f60d2e2-6571-4055-b306-8607e05ad79b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1aa18d4a-a545-46f6-beed-ff60b9d88708"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c8747ee2-f8e9-4d45-90a8-12fca4cf649d"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCommentId",
                table: "Comments",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentCommentId",
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

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("17259606-5644-4b88-a84d-b0d379eeee4b"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("2aa35fa3-47dc-4ad5-83d7-c6514cfbbc1e"), "Health tips and news", "Health" },
                    { new Guid("5eb1f688-ca20-4312-9bcd-96a0efeee726"), "Educational articles and resources", "Education" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("1aa18d4a-a545-46f6-beed-ff60b9d88708"), "johndoe@example.com", null, "$2a$11$GKmOIYcd4Oh3ZP2fby4gv.RM7FDur0foLCb06Xvq02pcGgOKHmg5e", "User", "johndoe" },
                    { new Guid("c8747ee2-f8e9-4d45-90a8-12fca4cf649d"), "admin@example.com", null, "$2a$11$hcdCtnWlrmhckp1NJXokyuCVGsPLhMT5LsfdOdzHfhlwVqYTwJG7W", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("4f60d2e2-6571-4055-b306-8607e05ad79b"), new Guid("c8747ee2-f8e9-4d45-90a8-12fca4cf649d"), "Exploring advanced strategies in finance.", new DateTime(2024, 11, 18, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5436), "Advanced Financial Strategies", new DateTime(2024, 12, 6, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5436) },
                    { new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd"), new Guid("1aa18d4a-a545-46f6-beed-ff60b9d88708"), "This is an introductory post about finance.", new DateTime(2024, 11, 28, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5421), "Introduction to Finance", new DateTime(2024, 12, 3, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5433) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("55ef6de5-8aa2-43ed-ab0b-9bd10bde24c0"), null, "USA", new DateTime(2024, 12, 8, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5378), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 12, 8, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5381), new Guid("1aa18d4a-a545-46f6-beed-ff60b9d88708") },
                    { new Guid("63689d23-d462-48fc-9f16-66c60ca7a58c"), null, "Canada", new DateTime(2024, 12, 8, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5387), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 12, 8, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5387), new Guid("c8747ee2-f8e9-4d45-90a8-12fca4cf649d") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "PostId" },
                values: new object[,]
                {
                    { new Guid("4621b6b0-cb9e-4b6b-bab3-d7e489df70f4"), new Guid("1aa18d4a-a545-46f6-beed-ff60b9d88708"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 12, 3, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5587), false, new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd") },
                    { new Guid("8c1fe985-32be-498d-a1b9-4dcff7408128"), new Guid("1aa18d4a-a545-46f6-beed-ff60b9d88708"), "I found this article very helpful!", new DateTime(2024, 12, 5, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5592), false, new Guid("4f60d2e2-6571-4055-b306-8607e05ad79b") },
                    { new Guid("aa0425c6-9954-4bc0-8767-af32d8b06bb8"), new Guid("c8747ee2-f8e9-4d45-90a8-12fca4cf649d"), "Interesting perspective on finance.", new DateTime(2024, 12, 4, 17, 10, 12, 957, DateTimeKind.Utc).AddTicks(5591), false, new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9e8fc937-e340-44a6-bfaa-a2d8d05eb101"), new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd"), new Guid("1aa18d4a-a545-46f6-beed-ff60b9d88708") },
                    { new Guid("d8dc2fdb-6627-42ed-b3d0-3900dcfac950"), new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd"), new Guid("c8747ee2-f8e9-4d45-90a8-12fca4cf649d") },
                    { new Guid("dcefe575-55df-434d-966c-188f66571228"), new Guid("4f60d2e2-6571-4055-b306-8607e05ad79b"), new Guid("1aa18d4a-a545-46f6-beed-ff60b9d88708") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("2aa35fa3-47dc-4ad5-83d7-c6514cfbbc1e"), new Guid("4f60d2e2-6571-4055-b306-8607e05ad79b") },
                    { new Guid("5eb1f688-ca20-4312-9bcd-96a0efeee726"), new Guid("4f60d2e2-6571-4055-b306-8607e05ad79b") },
                    { new Guid("17259606-5644-4b88-a84d-b0d379eeee4b"), new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd") },
                    { new Guid("5eb1f688-ca20-4312-9bcd-96a0efeee726"), new Guid("bd22aebe-fa53-4043-a400-3a4e1b4a9bdd") }
                });
        }
    }
}

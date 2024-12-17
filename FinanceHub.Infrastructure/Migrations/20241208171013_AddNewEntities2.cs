using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3b7aef6a-94a2-42f6-a001-a1f46005ae3e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("3ddfae8a-abae-4270-9de8-44cb4c91531c"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("7c6c3839-3ad2-4348-816f-a0bbc1fcfdc0"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("284c1429-9340-468c-98dd-654fc83b8d2b"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("338f6be7-2ddc-45ef-a172-0635f0deba89"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("5c676bad-abd2-4e06-ac04-7322d01f278e"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba"), new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("26cda588-7e99-4d90-9a13-e704bc891b18"), new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba"), new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("981796df-9b65-4d86-ae7d-5810bd10b1b7"), new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a468340d-f683-4715-b565-b37bde86792d"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("dfdd9e73-1ae4-4c2c-b8df-6d51c65c93ca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("26cda588-7e99-4d90-9a13-e704bc891b18"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("981796df-9b65-4d86-ae7d-5810bd10b1b7"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2350f49a-e51f-4623-953f-3692c6186b95"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ba0df017-3298-4113-988c-9bc5b709776c"));

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriberId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscribedToId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_SubscribedToId",
                        column: x => x.SubscribedToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatParticipants_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_ChatId",
                table: "ChatParticipants",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_UserId",
                table: "ChatParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscribedToId",
                table: "Subscriptions",
                column: "SubscribedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriberId",
                table: "Subscriptions",
                column: "SubscriberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatParticipants");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Chats");

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba"), "Educational articles and resources", "Education" },
                    { new Guid("26cda588-7e99-4d90-9a13-e704bc891b18"), "Health tips and news", "Health" },
                    { new Guid("981796df-9b65-4d86-ae7d-5810bd10b1b7"), "Posts related to the latest technology trends", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("2350f49a-e51f-4623-953f-3692c6186b95"), "johndoe@example.com", null, "$2a$11$TmqPqDdjsorNj6fMiAgO7uodr1q0aq/35/dIKXdNZT3fC.HFSTOIa", "User", "johndoe" },
                    { new Guid("ba0df017-3298-4113-988c-9bc5b709776c"), "admin@example.com", null, "$2a$11$wLBsNYEknmhSylTnEqzW7uCsm/pVHHEwKVSt8P46xXitel7dtrVKa", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6"), new Guid("ba0df017-3298-4113-988c-9bc5b709776c"), "Exploring advanced strategies in finance.", new DateTime(2024, 11, 18, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9159), "Advanced Financial Strategies", new DateTime(2024, 12, 6, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9160) },
                    { new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"), new Guid("2350f49a-e51f-4623-953f-3692c6186b95"), "This is an introductory post about finance.", new DateTime(2024, 11, 28, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9145), "Introduction to Finance", new DateTime(2024, 12, 3, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9158) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("a468340d-f683-4715-b565-b37bde86792d"), null, "Canada", new DateTime(2024, 12, 8, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9112), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2024, 12, 8, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9113), new Guid("ba0df017-3298-4113-988c-9bc5b709776c") },
                    { new Guid("dfdd9e73-1ae4-4c2c-b8df-6d51c65c93ca"), null, "USA", new DateTime(2024, 12, 8, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9104), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2024, 12, 8, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9107), new Guid("2350f49a-e51f-4623-953f-3692c6186b95") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "PostId" },
                values: new object[,]
                {
                    { new Guid("3b7aef6a-94a2-42f6-a001-a1f46005ae3e"), new Guid("ba0df017-3298-4113-988c-9bc5b709776c"), "Interesting perspective on finance.", new DateTime(2024, 12, 4, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9296), false, new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8") },
                    { new Guid("3ddfae8a-abae-4270-9de8-44cb4c91531c"), new Guid("2350f49a-e51f-4623-953f-3692c6186b95"), "Great introduction! Looking forward to learning more.", new DateTime(2024, 12, 3, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9294), false, new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8") },
                    { new Guid("7c6c3839-3ad2-4348-816f-a0bbc1fcfdc0"), new Guid("2350f49a-e51f-4623-953f-3692c6186b95"), "I found this article very helpful!", new DateTime(2024, 12, 5, 17, 7, 1, 492, DateTimeKind.Utc).AddTicks(9297), false, new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("284c1429-9340-468c-98dd-654fc83b8d2b"), new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6"), new Guid("2350f49a-e51f-4623-953f-3692c6186b95") },
                    { new Guid("338f6be7-2ddc-45ef-a172-0635f0deba89"), new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"), new Guid("ba0df017-3298-4113-988c-9bc5b709776c") },
                    { new Guid("5c676bad-abd2-4e06-ac04-7322d01f278e"), new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8"), new Guid("2350f49a-e51f-4623-953f-3692c6186b95") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba"), new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6") },
                    { new Guid("26cda588-7e99-4d90-9a13-e704bc891b18"), new Guid("d781348d-1f6f-46b6-9f9a-be191735d6f6") },
                    { new Guid("1415d166-8f95-4cda-83a9-b509d038a8ba"), new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8") },
                    { new Guid("981796df-9b65-4d86-ae7d-5810bd10b1b7"), new Guid("f8f45665-c68b-4b92-932e-04d89c1d0df8") }
                });
        }
    }
}

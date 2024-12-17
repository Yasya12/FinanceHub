using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

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
    }
}

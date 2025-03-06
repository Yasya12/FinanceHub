using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfileNullEntityPos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("804cb1f3-6244-4326-8945-4c35ff917543"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("c37de9c7-c888-44a4-a60b-79b5fa8b177b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("fabf5a1a-117d-43f2-bce7-c336e5da3a1d"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("62d8b646-0e40-4145-89aa-bda90e660d13"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("810e45c2-00d7-4fc2-a477-32cdc9decbb7"));

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: new Guid("b0ac3947-77fc-44ad-adc4-09a95bdc8597"));

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("8449d5d1-0164-4b28-bd2c-e5cc657a0ee2"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("460929ba-a82f-46d1-ab8b-a8e85f987346"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") });

            migrationBuilder.DeleteData(
                table: "PostCategories",
                keyColumns: new[] { "CategoryId", "PostId" },
                keyValues: new object[] { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2fc82168-6f82-4c4f-9533-6c5c7896fbc5"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("9c6bf666-8de7-4b4b-ac69-7fdfa6c38cdf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("460929ba-a82f-46d1-ab8b-a8e85f987346"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8449d5d1-0164-4b28-bd2c-e5cc657a0ee2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Profiles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Profiles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Profiles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Profiles",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("460929ba-a82f-46d1-ab8b-a8e85f987346"), "Posts related to the latest technology trends", "Technology" },
                    { new Guid("8449d5d1-0164-4b28-bd2c-e5cc657a0ee2"), "Health tips and news", "Health" },
                    { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), "Educational articles and resources", "Education" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "GoogleId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"), "johndoe@example.com", null, "$2a$11$vOYpttYWU6QvWuw3KyTowu0K/A8PHOe3PNMcfh7186XD1sFtnYJoO", "User", "johndoe" },
                    { new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30"), "admin@example.com", null, "$2a$11$UDNZ7Hj.HkiqeBkF.SuVyeFpLNjFqslSOuMnI68ORZ5lzyvktKGky", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc"), new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30"), "Exploring advanced strategies in finance.", new DateTime(2025, 1, 29, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3521), "Advanced Financial Strategies", new DateTime(2025, 2, 16, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3522) },
                    { new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"), "This is an introductory post about finance.", new DateTime(2025, 2, 8, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3502), "Introduction to Finance", new DateTime(2025, 2, 13, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3518) }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Country", "CreatedAt", "DateOfBirth", "PhoneNumber", "ProfilePictureUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("2fc82168-6f82-4c4f-9533-6c5c7896fbc5"), null, "Canada", new DateTime(2025, 2, 18, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3439), new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "+9876543210", null, new DateTime(2025, 2, 18, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3440), new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30") },
                    { new Guid("9c6bf666-8de7-4b4b-ac69-7fdfa6c38cdf"), null, "USA", new DateTime(2025, 2, 18, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3404), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "+1234567890", null, new DateTime(2025, 2, 18, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3409), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("804cb1f3-6244-4326-8945-4c35ff917543"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"), "Great introduction! Looking forward to learning more.", new DateTime(2025, 2, 13, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3817), false, null, new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") },
                    { new Guid("c37de9c7-c888-44a4-a60b-79b5fa8b177b"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f"), "I found this article very helpful!", new DateTime(2025, 2, 15, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3825), false, null, new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") },
                    { new Guid("fabf5a1a-117d-43f2-bce7-c336e5da3a1d"), new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30"), "Interesting perspective on finance.", new DateTime(2025, 2, 14, 12, 33, 47, 152, DateTimeKind.Utc).AddTicks(3822), false, null, new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("62d8b646-0e40-4145-89aa-bda90e660d13"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415"), new Guid("f0a77459-ddb2-489d-9036-8b8707c0fd30") },
                    { new Guid("810e45c2-00d7-4fc2-a477-32cdc9decbb7"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f") },
                    { new Guid("b0ac3947-77fc-44ad-adc4-09a95bdc8597"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc"), new Guid("b2522c58-967c-4a0e-86ca-dba3bfd30c6f") }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { new Guid("8449d5d1-0164-4b28-bd2c-e5cc657a0ee2"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") },
                    { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), new Guid("6d173fd1-f19e-4d0f-aa05-7b4a37ca63bc") },
                    { new Guid("460929ba-a82f-46d1-ab8b-a8e85f987346"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") },
                    { new Guid("a27b8bc1-f3f7-4265-95a5-5dc78b614e1e"), new Guid("9ad4264d-3782-45ce-a16e-99fa858ec415") }
                });
        }
    }
}

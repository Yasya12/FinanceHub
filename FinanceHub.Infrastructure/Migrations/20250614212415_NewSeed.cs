using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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
                name: "Groups",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Hubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MainPhotoUrl = table.Column<string>(type: "text", nullable: true),
                    BackgroundPhotoUrl = table.Column<string>(type: "text", nullable: true),
                    PostPermission = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GoogleId = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastActive = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    ConnectionId = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    GroupName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_Connections_Groups_GroupName",
                        column: x => x.GroupName,
                        principalTable: "Groups",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
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
                name: "Followings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowingUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    FollowingHubId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Followings_Hubs_FollowingHubId",
                        column: x => x.FollowingHubId,
                        principalTable: "Hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Followings_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Followings_Users_FollowingUserId",
                        column: x => x.FollowingUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HubJoinRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HubId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    RequestedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubJoinRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HubJoinRequests_Hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "Hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HubJoinRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HubMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HubId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HubMembers_Hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "Hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HubMembers_Users_UserId",
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
                    SenderUserName = table.Column<string>(type: "text", nullable: false),
                    RecipientUserName = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DateRead = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SenderDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RecipientDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HubId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Hubs_HubId",
                        column: x => x.HubId,
                        principalTable: "Hubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TriggeredBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: true),
                    HubId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_HubJoinRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "HubJoinRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_Users_TriggeredBy",
                        column: x => x.TriggeredBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsModified = table.Column<bool>(type: "boolean", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_PostImages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("10b10de2-fcf7-4c25-a5ba-4c6bd6e3f261"), null, "Moderator", "MODERATOR" },
                    { new Guid("5c528ff1-5647-457d-ada2-592983e41677"), null, "Member", "MEMBER" },
                    { new Guid("5c8d67f5-91f7-4e5f-8ace-e4e0313b002c"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Hubs",
                columns: new[] { "Id", "BackgroundPhotoUrl", "Description", "MainPhotoUrl", "Name", "PostPermission" },
                values: new object[,]
                {
                    { new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), null, "Cпільнота для активних трейдерів.", null, "Криптотрейдинг 24/7", "public" },
                    { new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), null, "Спільнота для тих, хто робить перші кроки у світі інвестицій.", null, "Інвестиції для початківців", "public" },
                    { new Guid("77983140-1aae-49f0-9d71-bdbc6560e838"), null, "Глибокий аналіз компаній, секторів та ринкових трендів. Ділимося звітами та прогнозами.", null, "Аналіз фондового ринку", "moderated" },
                    { new Guid("7810c753-2758-492d-a723-e4ba53344133"), null, "Все про купівлю, продаж та оренду нерухомості в Україні та за кордоном.", null, "Інвестиції в нерухомість", "public" },
                    { new Guid("bbde15f8-f63c-4b86-a0e7-0f91d7344c78"), null, "Поради та лайфхаки про те, як ефективно управляти грошима і досягати фінансових цілей.", null, "Особистий бюджет та заощадження", "public" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Country", "CreatedAt", "Email", "EmailConfirmed", "GoogleId", "LastActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6f52e78b-9776-4ba7-8e98-8a6d9082d9f2"), 0, "Passionate about smart money management and personal growth. Tracking goals, budgeting wisely, and always learning something new about finance.", "84444e42-40a4-4dd5-8e2e-edccf7f19ab0", "Україна", new DateTime(2025, 5, 30, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(5605), "lisa@1", false, null, new DateTime(2025, 6, 14, 9, 24, 14, 914, DateTimeKind.Utc).AddTicks(5611), false, null, null, null, "$2a$11$SlF5KvpSUMGtSJr1hpjx.OrX5wltzNaVXImgVutS28SiHujb8ccHW", null, false, null, null, false, "Ліза" },
                    { new Guid("92721bf5-f5c1-4681-97db-1e7f45557497"), 0, "Досвідчений трейдер, ділюся аналітикою та ідеями.", "1a575f6f-1870-4d0d-ac57-2736cdc80583", "Польща", new DateTime(2025, 4, 30, 21, 24, 14, 411, DateTimeKind.Utc).AddTicks(6663), "maks.t@gmail.com", false, null, new DateTime(2025, 6, 14, 16, 24, 14, 411, DateTimeKind.Utc).AddTicks(6669), false, null, null, null, "$2a$11$6VqsO5d1x/PxPFw/M5DEIuM7XjP/1D2rkvjZJSl1rrIBhuw0CwgdG", null, false, null, null, false, "трейдер_макс" },
                    { new Guid("9bc9f329-b54f-47f3-809a-2baa1b967a91"), 0, "Цікаво дізнатися більше про фінанси.", "21b9c504-91ea-4e85-9a3b-9867f2a29da7", "Україна", new DateTime(2025, 4, 25, 21, 24, 14, 15, DateTimeKind.Utc).AddTicks(434), "oleksii@gmail.com", false, null, new DateTime(2025, 6, 12, 21, 24, 14, 15, DateTimeKind.Utc).AddTicks(445), false, null, null, null, "$2a$11$E1eq8/YoFpYn56TnqkKFteapNDyyUGU/Eivu.0w/8HMABGPadU05i", null, false, null, null, false, "олексій" },
                    { new Guid("c0fceb80-1eed-4cb2-83d1-76518570cf7a"), 0, "Твоя комфортна фінансова соціальна мережа.", "e46e4aa7-acd1-4758-bc37-eb36ddf5e797", "Україна", new DateTime(2025, 4, 25, 21, 24, 14, 276, DateTimeKind.Utc).AddTicks(4551), "finhub@gmail.com", false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null, "$2a$11$XLZmvga4Od0B0nFWBia3SuFrF3SIHSlwxhlMxrF9kk.AJG0k8adeS", null, false, null, null, false, "finhub" },
                    { new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d"), 0, "Фінансовий аналітик. Розбираю звітності компаній та макроекономічні тренди.", "85551de4-1bb4-49f2-a16b-9b8935ea03f1", "Німеччина", new DateTime(2025, 5, 25, 21, 24, 14, 662, DateTimeKind.Utc).AddTicks(4190), "andriy.a@emgmailil.com", false, null, new DateTime(2025, 6, 11, 21, 24, 14, 662, DateTimeKind.Utc).AddTicks(4195), false, null, null, null, "$2a$11$N9f7bWwIp3nDYcwLLHp3seTzjJm9oeAdUfta58.ZDM317sbzQlVXe", null, false, null, null, false, "аналітик_андрій" },
                    { new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc"), 0, "Люблю інвестиції і фінанси.", "74221be3-100d-42a6-96f1-aacb07767bb9", "Україна", new DateTime(2025, 4, 25, 21, 24, 14, 147, DateTimeKind.Utc).AddTicks(6761), "olena.p@gmail.com", false, null, new DateTime(2025, 6, 12, 21, 24, 14, 147, DateTimeKind.Utc).AddTicks(6897), false, null, null, null, "$2a$11$8dw5twzrcKT6TU5GSqkgEeGw5E4x.PVV6kp7LDPCxId48Op.Gvcfi", null, false, null, null, false, "олена_інвест" },
                    { new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d"), 0, "Веду блог про особисті фінанси, бюджетування та заощадження.", "8e1931fe-146e-49ee-b0f6-daf0880c0c26", "Україна", new DateTime(2025, 5, 30, 21, 24, 14, 788, DateTimeKind.Utc).AddTicks(3143), "yulia.f@gmail.com", false, null, new DateTime(2025, 6, 14, 9, 24, 14, 788, DateTimeKind.Utc).AddTicks(3150), false, null, null, null, "$2a$11$qXUk00RRA9fjzMAiH5SMp.LyJCLU5/ZiiB83Ny9.06AL1vi3zYX/C", null, false, null, null, false, "фінанси_юлія" },
                    { new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14"), 0, "Все про блокчейн, NFT та криптовалюти. Слідкуйте за оновленнями!", "9e5af364-d83d-4869-bcb1-68da64b9d57b", "Україна", new DateTime(2025, 5, 15, 21, 24, 14, 536, DateTimeKind.Utc).AddTicks(9551), "kate.c@gmail.com", false, null, new DateTime(2025, 6, 14, 20, 24, 14, 536, DateTimeKind.Utc).AddTicks(9558), false, null, null, null, "$2a$11$yUhUaUlCF1ziL9ix16.5Q.JdCAvBB6hALagtoChVEYfdqQ10NYXji", null, false, null, null, false, "крипто_катя" }
                });

            migrationBuilder.InsertData(
                table: "Followings",
                columns: new[] { "Id", "CreatedAt", "FollowerId", "FollowingHubId", "FollowingUserId" },
                values: new object[,]
                {
                    { new Guid("3a31f6e3-996f-4d9e-987a-4a265de720d9"), new DateTime(2025, 6, 14, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7009), new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc"), null, new Guid("92721bf5-f5c1-4681-97db-1e7f45557497") },
                    { new Guid("7dfa792d-a0d0-44c8-a2a6-6c4e266700a7"), new DateTime(2025, 6, 14, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7016), new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14"), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), null },
                    { new Guid("90a1f1df-cf89-486d-9611-16551909aeb4"), new DateTime(2025, 6, 14, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7013), new Guid("92721bf5-f5c1-4681-97db-1e7f45557497"), null, new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc") },
                    { new Guid("ac802bf2-d39c-4fec-a9fc-5f8440ca5c8a"), new DateTime(2025, 6, 14, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7014), new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d"), null, new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc") }
                });

            migrationBuilder.InsertData(
                table: "HubJoinRequests",
                columns: new[] { "Id", "Content", "Description", "HubId", "RequestedAt", "Status", "UserId" },
                values: new object[] { new Guid("743f3e37-c7ac-4852-8e8a-337d7c15517c"), "Привіт, маю досвід у трейдингу, хочу приєднатися до спільноти.", null, new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), new DateTime(2025, 6, 13, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7417), "Pending", new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d") });

            migrationBuilder.InsertData(
                table: "HubMembers",
                columns: new[] { "Id", "Description", "HubId", "IsApproved", "JoinedAt", "Role", "UserId" },
                values: new object[,]
                {
                    { new Guid("05e62932-ccd7-4d46-a123-ebf0230f5924"), null, new Guid("7810c753-2758-492d-a723-e4ba53344133"), true, new DateTime(2025, 5, 28, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6842), "Member", new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d") },
                    { new Guid("1c3f2667-7381-4ec5-a728-fd582cb0dd71"), null, new Guid("bbde15f8-f63c-4b86-a0e7-0f91d7344c78"), true, new DateTime(2025, 5, 15, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6827), "Admin", new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d") },
                    { new Guid("4f9615f1-da15-4cc9-8ce9-0ed7d51b58db"), null, new Guid("77983140-1aae-49f0-9d71-bdbc6560e838"), true, new DateTime(2025, 5, 30, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6834), "Member", new Guid("92721bf5-f5c1-4681-97db-1e7f45557497") },
                    { new Guid("63f9a7e7-c52f-4840-b44c-7781fc7009c9"), null, new Guid("7810c753-2758-492d-a723-e4ba53344133"), true, new DateTime(2025, 5, 26, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6840), "Admin", new Guid("92721bf5-f5c1-4681-97db-1e7f45557497") },
                    { new Guid("8bbfbc1f-b835-4d98-adc8-bc597bfc4c68"), null, new Guid("77983140-1aae-49f0-9d71-bdbc6560e838"), true, new DateTime(2025, 5, 31, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6838), "Member", new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc") },
                    { new Guid("9f8b95ec-28c3-47c0-9692-1b10fc3f8b38"), null, new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), true, new DateTime(2025, 6, 4, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6822), "Member", new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d") },
                    { new Guid("a1bb5002-b42f-44ae-aa29-9361c1166d66"), null, new Guid("77983140-1aae-49f0-9d71-bdbc6560e838"), true, new DateTime(2025, 5, 23, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6832), "Admin", new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d") },
                    { new Guid("b09a13bf-9b38-4d5e-a44a-16bbc742ca88"), null, new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), true, new DateTime(2025, 5, 5, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6818), "Admin", new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc") },
                    { new Guid("baa49208-3418-4e72-9e24-a4b366cc659c"), null, new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), true, new DateTime(2025, 5, 27, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6825), "Member", new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14") },
                    { new Guid("cf79a435-6e90-4baa-9c29-d4ec1f40cb3e"), null, new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), true, new DateTime(2025, 5, 25, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6824), "Admin", new Guid("92721bf5-f5c1-4681-97db-1e7f45557497") },
                    { new Guid("e638f1b1-1004-4ddb-a03c-dfd758a98c18"), null, new Guid("bbde15f8-f63c-4b86-a0e7-0f91d7344c78"), true, new DateTime(2025, 5, 20, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(6830), "Member", new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "HubId", "IsRead", "PostId", "RequestId", "TriggeredBy", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("b0cd692d-2474-44d3-bba9-2f8bfdbe7cb7"), "олена_інвест почала стежити за вами.", new DateTime(2025, 5, 25, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7456), null, true, null, null, new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc"), "follow", new Guid("92721bf5-f5c1-4681-97db-1e7f45557497") },
                    { new Guid("e1342ce7-ecac-4421-a74f-d09bdef5d91b"), "трейдер_макс вподобав ваш пост.", new DateTime(2025, 6, 13, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7452), null, false, new Guid("0d2999a8-7501-40eb-ae47-3c832a845a61"), null, new Guid("92721bf5-f5c1-4681-97db-1e7f45557497"), "like", new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "HubId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00c21421-57fb-4d5c-9c0b-8d7a874145c9"), new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d"), "Інфляція в єврозоні сповільнюється, але повільніше, ніж очікувалося. Це може змусити ЄЦБ тримати ставки високими довше.", new DateTime(2025, 6, 9, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7178), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0966922d-4a6b-4d52-9cc2-7f9e78858d92"), new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc"), "Для початківців ETF – чудовий старт. Купуючи один інструмент, ви одразу інвестуєте в сотні компаній. Наприклад, в індекс S&P 500.", new DateTime(2025, 6, 4, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7126), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d2999a8-7501-40eb-ae47-3c832a845a61"), new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc"), "Друзі, як диверсифікуєте свій портфель? Скільки відсотків тримаєте в акціях, а скільки в облігаціях?", new DateTime(2025, 6, 2, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7123), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2945ed78-e5e1-4ed4-b8d6-c6c9d45f784d"), new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14"), "HODL – це не просто мем, це стратегія. В довгостроковій перспективі віра в технологію винагороджується.", new DateTime(2025, 6, 7, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7143), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36ccf556-af1a-4ab0-abee-b002d5149395"), new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc"), "Хто що думає про акції Microsoft на довгострок? Здається, їхній фокус на AI дасть хороші плоди.", new DateTime(2025, 6, 9, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7131), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3834e9eb-de7a-4bfc-bf42-5d9409488fa4"), new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d"), "Alphabet ($GOOGL) — це машина для друку грошей. Монополія в пошуку та доходи від YouTube/Android дають їм змогу фінансувати будь-які 'інші ставки'. Поки їхній рекламний бізнес сильний, акції залишатимуться фундаментально міцними.", new DateTime(2025, 6, 11, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7233), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3aa55377-f7c5-4df8-8c0b-ceb902fe2b84"), new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d"), "Сектор напівпровідників виглядає перегрітим. P/E коефіцієнти деяких компаній, як-от Nvidia, просто захмарні.", new DateTime(2025, 6, 6, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7176), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3dd6a9b8-3d89-4b80-af1f-85684ea13a9a"), new Guid("92721bf5-f5c1-4681-97db-1e7f45557497"), "Найважче в трейдингу – це дисципліна. Вміння чекати на свій сетап і не піддаватися FOMO – ключ до успіху.", new DateTime(2025, 6, 8, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7135), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d1222e9-6f36-4434-bf19-8ac25ef086a6"), new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14"), "Не забувайте переводити крипту з бірж на холодні гаманці. 'Not your keys, not your coins!' – золоте правило.", new DateTime(2025, 6, 10, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7145), new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b89992d-d917-4d3a-b29c-b461c183e57b"), new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc"), "Сьогодні вперше отримала дивіденди. Невелика сума, але як же приємно розуміти, що твої гроші працюють!", new DateTime(2025, 6, 6, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7130), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c80990c-b46f-46d8-94af-b55efa872713"), new Guid("92721bf5-f5c1-4681-97db-1e7f45557497"), "На графіку EUR/USD формується 'голова і плечі'. Схоже, насувається корекція. Будьте обережні.", new DateTime(2025, 6, 11, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7137), new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94c52d3d-2b77-4070-8a26-cfeacd7ba2f5"), new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d"), "Згідно зі звітом Goldman Sachs, ринки, що розвиваються, можуть показати кращу динаміку в наступному році. Погоджуєтесь?", new DateTime(2025, 6, 10, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7179), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b12b235-d873-4234-94a3-e4acc8e60074"), new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d"), "Найкраща інвестиція – це інвестиція в себе. Курси, книги, здоров'я – це те, що завжди окупиться.", new DateTime(2025, 6, 8, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7172), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a8ff694e-868f-4f1a-914c-c4e633f615b5"), new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d"), "Microsoft ($MSFT) продовжує вражати. Їхній сегмент 'Intelligent Cloud' з Azure зростає шаленими темпами. Це вже не просто 'Windows і Office', а справжній хмарний гігант.", new DateTime(2025, 6, 10, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7230), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b639f0ae-19b8-44e8-ac01-c49f16e59ab1"), new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d"), "Спробувала правило 50/30/20 для бюджетування (50% – потреби, 30% – бажання, 20% – заощадження). Дуже дисциплінує!", new DateTime(2025, 6, 3, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7165), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b937fb2c-16f3-4b23-ad9d-800a2bad9361"), new Guid("92721bf5-f5c1-4681-97db-1e7f45557497"), "Ринок сьогодні дуже волатильний. Фіксую частину прибутку, краще синиця в руках.", new DateTime(2025, 6, 7, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7133), new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bad3b84f-724f-4af4-867e-3be5ae952571"), new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14"), "Попри всі регуляторні виклики, Binance залишається найбільшою біржею за обсягом торгів. Їхня екосистема з BNB Chain, Launchpad та іншими сервісами все ще домінує на ринку.", new DateTime(2025, 6, 12, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7235), new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb3e9caf-72ca-49a5-8799-b45b46d2ca55"), new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14"), "Що думаєте про перспективи Solana (SOL)? Технологія вражає, але чи зможе вона конкурувати з Ethereum?", new DateTime(2025, 6, 5, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7139), new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cebd0027-084d-4b05-9187-435938c25ae7"), new Guid("c0fceb80-1eed-4cb2-83d1-76518570cf7a"), "Вітаємо на FinanceHub! Ми оновили правила спільноти. Будь ласка, ознайомтеся.", new DateTime(2025, 5, 30, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7228), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e46c1463-c330-4ea0-bcce-954f9cf49284"), new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d"), "Де ви зберігаєте свою фінансову подушку? Депозит, ОВДП чи просто на картці? Шукаю найнадійніший варіант.", new DateTime(2025, 6, 5, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7170), new Guid("55865bcd-48d6-45f8-a028-77caf9d2e7ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4ab35ca-a0ce-47db-bfee-1f56d55e1540"), new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d"), "Багато хто питає, з чого почати інвестувати. Відповідь проста: почніть заощаджувати. Неможливо інвестувати гроші, яких у вас немає. Створіть 'фонд для інвестицій', відкладаючи хоча б 10% доходу.", new DateTime(2025, 6, 13, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7237), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb6e6ffa-d646-459a-b8b6-786ba44b0db2"), new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d"), "Щоб не робити імпульсивних покупок, завжди чекаю 24 години перед тим, як щось купити онлайн. Часто бажання зникає.", new DateTime(2025, 6, 11, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7173), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f7c8cadb-6f04-4eb0-8e2b-b954eaacefe6"), new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d"), "Ніколи не інвестуйте в бізнес, який ви не розумієте. Це просте правило Воррена Баффета врятувало мені багато грошей.", new DateTime(2025, 6, 12, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7181), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fd24df51-46c3-42ae-b766-8b5cc381aa96"), new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14"), "Ринок NFT зараз переживає не найкращі часи, але це гарна можливість придивитися до фундаментально сильних проєктів.", new DateTime(2025, 6, 12, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7163), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[,]
                {
                    { new Guid("1190517d-9e50-4296-ad1c-7c81c31fdfc6"), new Guid("92721bf5-f5c1-4681-97db-1e7f45557497"), "Дякую за детальний аналіз!", new DateTime(2025, 6, 14, 15, 24, 14, 914, DateTimeKind.Utc).AddTicks(7345), false, null, new Guid("8b89992d-d917-4d3a-b29c-b461c183e57b") },
                    { new Guid("e8a0e462-a9b1-4aea-89bd-ac8d0f239133"), new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d"), "Дуже корисна стаття, дякую! Особливо для новачків.", new DateTime(2025, 6, 5, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7335), false, null, new Guid("0d2999a8-7501-40eb-ae47-3c832a845a61") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0efde790-517f-4ee9-9eec-fef3b2b04ef1"), new Guid("0d2999a8-7501-40eb-ae47-3c832a845a61"), new Guid("92721bf5-f5c1-4681-97db-1e7f45557497") },
                    { new Guid("3c3d075e-8f9b-414b-8961-98238c6d27f0"), new Guid("b937fb2c-16f3-4b23-ad9d-800a2bad9361"), new Guid("f753893e-7141-44e9-bb0b-50cc31385b0d") },
                    { new Guid("8533cea6-edd6-4cc4-9ce2-028a77c83e3a"), new Guid("36ccf556-af1a-4ab0-abee-b002d5149395"), new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc") },
                    { new Guid("f2f10449-ee30-4355-87a5-c278bd38aa75"), new Guid("8b89992d-d917-4d3a-b29c-b461c183e57b"), new Guid("fb58c252-c3a6-47cb-ad91-2efd64910a14") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "HubId", "IsRead", "PostId", "RequestId", "TriggeredBy", "Type", "UserId" },
                values: new object[] { new Guid("8ef60ca9-ee1f-4ea9-8a33-ce4cd4a1a92b"), "аналітик_андрій хоче приєднатися до вашого хабу 'Криптотрейдинг 24/7'.", new DateTime(2025, 6, 13, 21, 24, 14, 914, DateTimeKind.Utc).AddTicks(7459), new Guid("1d5320e6-358f-411b-8d67-d5534b8a7d12"), false, null, new Guid("743f3e37-c7ac-4852-8e8a-337d7c15517c"), new Guid("dfe0f55d-bff6-4fd6-a9bf-21b93e03654d"), "joinRequest", new Guid("92721bf5-f5c1-4681-97db-1e7f45557497") });

            migrationBuilder.InsertData(
                table: "PostImages",
                columns: new[] { "Id", "ImageUrl", "PostId" },
                values: new object[,]
                {
                    { new Guid("76e924fc-61a2-4e32-87a3-ac479d673648"), "https://finhubimagesstorage.blob.core.windows.net/finhubimagesstorage/posts/post1.webp", new Guid("e4ab35ca-a0ce-47db-bfee-1f56d55e1540") },
                    { new Guid("98054baa-c268-4d7b-94b3-d1855bedba47"), "https://finhubimagesstorage.blob.core.windows.net/finhubimagesstorage/posts/post3.jpg", new Guid("a8ff694e-868f-4f1a-914c-c4e633f615b5") },
                    { new Guid("e3255522-bacc-44db-90c3-0f5a4dadfe48"), "https://finhubimagesstorage.blob.core.windows.net/finhubimagesstorage/posts/poat4.webp", new Guid("3834e9eb-de7a-4bfc-bf42-5d9409488fa4") },
                    { new Guid("e8ef6654-3d28-4816-a4d8-37c636af958f"), "https://finhubimagesstorage.blob.core.windows.net/finhubimagesstorage/posts/post2.webp", new Guid("bad3b84f-724f-4af4-867e-3be5ae952571") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "IsModified", "ParentId", "PostId" },
                values: new object[] { new Guid("4c323a31-056a-4a77-88f9-8e1bc49164f3"), new Guid("f560a591-5e20-4c81-8c33-f510b57bf0dc"), "Рада, що було корисно!", new DateTime(2025, 6, 5, 23, 24, 14, 914, DateTimeKind.Utc).AddTicks(7343), false, new Guid("e8a0e462-a9b1-4aea-89bd-ac8d0f239133"), new Guid("36ccf556-af1a-4ab0-abee-b002d5149395") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_ChatId",
                table: "ChatParticipants",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_UserId",
                table: "ChatParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_GroupName",
                table: "Connections",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowerId",
                table: "Followings",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowingHubId",
                table: "Followings",
                column: "FollowingHubId");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowingUserId",
                table: "Followings",
                column: "FollowingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HubJoinRequests_HubId",
                table: "HubJoinRequests",
                column: "HubId");

            migrationBuilder.CreateIndex(
                name: "IX_HubJoinRequests_UserId",
                table: "HubJoinRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HubMembers_HubId_UserId",
                table: "HubMembers",
                columns: new[] { "HubId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HubMembers_UserId",
                table: "HubMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RequestId",
                table: "Notifications",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TriggeredBy",
                table: "Notifications",
                column: "TriggeredBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_HubId",
                table: "Posts",
                column: "HubId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscribedToId",
                table: "Subscriptions",
                column: "SubscribedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriberId",
                table: "Subscriptions",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChatParticipants");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Followings");

            migrationBuilder.DropTable(
                name: "HubMembers");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "HubJoinRequests");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Hubs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

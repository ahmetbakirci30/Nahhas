using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nahhas.Shared.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CoverPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusCount = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    AdditionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViewsCount = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    LikesCount = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    SharesCount = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    DownloadsCount = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VideoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Status_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Active", "AdditionDate", "CoverPath", "LastModified", "Name", "StatusCount" },
                values: new object[,]
                {
                    { new Guid("3df42c31-ae20-4f90-b3d5-88eda4b43123"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk0", 0m },
                    { new Guid("995cc707-fdb7-4cb8-b061-a8b07cf5382d"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk1", 0m },
                    { new Guid("bc64a4b9-7d58-41a2-b135-779bc5f08b34"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk2", 0m },
                    { new Guid("d76acd47-f978-4dae-bd22-eccfe0e8fccc"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk3", 0m },
                    { new Guid("7a4ec1f9-9f7c-42c4-841a-7e7001a38eeb"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk4", 0m },
                    { new Guid("57eea60b-b850-4249-bce1-a31b4eddc0c2"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk5", 0m },
                    { new Guid("a70f13d0-d014-437a-be32-b64a6f8bea13"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk6", 0m },
                    { new Guid("04fd3992-5114-446a-8e6b-744f961e7cb1"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk7", 0m },
                    { new Guid("32a68bf3-6ba5-46d6-8e78-ae160fe542bf"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk8", 0m },
                    { new Guid("a6364963-5d0a-4739-b9e8-0a82c1052c1e"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk9", 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("5f9776a4-5143-40a8-8511-9268d80546bd"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3df42c31-ae20-4f90-b3d5-88eda4b43123"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m },
                    { new Guid("87ee2357-c187-495e-b8db-56d1eb9c5402"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6364963-5d0a-4739-b9e8-0a82c1052c1e"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("bcd849c3-2416-4b6b-a5ea-c68c3788760c"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("32a68bf3-6ba5-46d6-8e78-ae160fe542bf"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer8", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("7f93d7d4-780d-4397-8a01-f5d56a496904"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("32a68bf3-6ba5-46d6-8e78-ae160fe542bf"), "My 8th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("13db8e80-bf56-4e6a-b29b-c08286da6e7d"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("32a68bf3-6ba5-46d6-8e78-ae160fe542bf"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("2d399b56-e8e8-4c14-a2d3-ec7125878c9b"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04fd3992-5114-446a-8e6b-744f961e7cb1"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer7", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("c6c4bbf0-f707-46e7-9686-d118d68fb42c"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04fd3992-5114-446a-8e6b-744f961e7cb1"), "My 7th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("0dee24fa-5193-4edd-b6ee-8560b771d1ca"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04fd3992-5114-446a-8e6b-744f961e7cb1"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("3cd5ec4c-3d55-43cd-bb48-fde7d7ee90bd"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a70f13d0-d014-437a-be32-b64a6f8bea13"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer6", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("58cdcf35-018d-411c-bc64-58be070b07c8"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a70f13d0-d014-437a-be32-b64a6f8bea13"), "My 6th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("68f1140f-ff0a-4160-8474-a92862a84d1c"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a70f13d0-d014-437a-be32-b64a6f8bea13"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("b9a4afc5-9292-44e1-9612-b66701132cfd"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("57eea60b-b850-4249-bce1-a31b4eddc0c2"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer5", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("aae62f60-76ac-422f-bca4-32436089a281"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("57eea60b-b850-4249-bce1-a31b4eddc0c2"), "My 5th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("ffb876bc-4fd5-444b-8ed7-ab6ab0d40e46"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("57eea60b-b850-4249-bce1-a31b4eddc0c2"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("505f80fe-bf0d-4788-aea5-77dfeb55473b"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a4ec1f9-9f7c-42c4-841a-7e7001a38eeb"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer4", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("ac54a66f-67f2-40c2-84f1-12e230496383"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a4ec1f9-9f7c-42c4-841a-7e7001a38eeb"), "My 4th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("ad11e9e3-86b5-401b-aec4-2cdd87814272"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a4ec1f9-9f7c-42c4-841a-7e7001a38eeb"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("313f273f-d621-4ae0-aa6f-4c4224558dd5"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d76acd47-f978-4dae-bd22-eccfe0e8fccc"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer3", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("2e484998-35ae-414c-9b60-e8a83dc61254"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d76acd47-f978-4dae-bd22-eccfe0e8fccc"), "My 3th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("42543e78-9184-47c9-b516-67c22c623660"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d76acd47-f978-4dae-bd22-eccfe0e8fccc"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("8ad39a36-ba70-4616-8614-1e7c79e1c174"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bc64a4b9-7d58-41a2-b135-779bc5f08b34"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer2", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("ed66e9f6-9dfb-4913-b982-98cc83d5ebcb"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bc64a4b9-7d58-41a2-b135-779bc5f08b34"), "My 2th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("f519695f-6d2b-4b53-b456-4972282141c0"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bc64a4b9-7d58-41a2-b135-779bc5f08b34"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("845e982d-63a8-4147-a9b6-17803daab14f"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("995cc707-fdb7-4cb8-b061-a8b07cf5382d"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer1", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("08e1a09c-1462-42dc-bb68-c408a9ce28fc"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("995cc707-fdb7-4cb8-b061-a8b07cf5382d"), "My 1th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("6f1c1417-c013-43fb-b720-049b15d1cfdb"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("995cc707-fdb7-4cb8-b061-a8b07cf5382d"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("d6966898-c8c9-487d-905c-52a399d7b2dd"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3df42c31-ae20-4f90-b3d5-88eda4b43123"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer0", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("1e67789d-bd9c-418e-9d79-64df05f58918"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3df42c31-ae20-4f90-b3d5-88eda4b43123"), "My 0th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m },
                    { new Guid("0cd292b0-debc-4f7e-8ba9-1731f93d8bae"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6364963-5d0a-4739-b9e8-0a82c1052c1e"), "My 9th Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("90fe957d-f0a4-4dba-8712-753504d7c147"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a6364963-5d0a-4739-b9e8-0a82c1052c1e"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Sevgililer9", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Status_CategoryId",
                table: "Status",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

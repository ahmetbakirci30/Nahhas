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
                    { new Guid("22ea1815-a784-4c6a-9dfc-c1968f9682d8"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk00", 0m },
                    { new Guid("b7fba040-6b10-47bc-9156-ad0f14dcc59b"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk11", 0m },
                    { new Guid("e4c9ff42-062a-41fe-b224-42ec0cd6eaa8"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk22", 0m },
                    { new Guid("1938172f-3f01-491a-81c2-d766e421ed79"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk33", 0m },
                    { new Guid("3bdfc502-ab52-4860-b6a7-77f473ef91e3"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk44", 0m },
                    { new Guid("07943d46-e463-494d-97ab-9bc81c623394"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk55", 0m },
                    { new Guid("022cca00-53b3-429d-8ce7-c39c049589e1"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk66", 0m },
                    { new Guid("27dfda8a-4672-44d8-8cb3-7a0228595bc8"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk77", 0m },
                    { new Guid("125664d7-5517-4fdb-821c-45a7bead61b2"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk88", 0m },
                    { new Guid("ed969ad4-a203-48d8-bd6f-40bdcec5c531"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aşk99", 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("422846b3-9082-4a03-9cec-f93cb47d0a65"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22ea1815-a784-4c6a-9dfc-c1968f9682d8"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m },
                    { new Guid("37661303-c6ec-4265-9217-f4033760e990"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed969ad4-a203-48d8-bd6f-40bdcec5c531"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("4f1896e9-e38b-4c2f-abec-6d1dfa274de2"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("125664d7-5517-4fdb-821c-45a7bead61b2"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk8", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("59c4ab57-123b-42c1-a3fc-0644a45a6943"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("125664d7-5517-4fdb-821c-45a7bead61b2"), "My 8. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("90d509f5-9863-44d9-919b-6a7753ad2f9e"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("125664d7-5517-4fdb-821c-45a7bead61b2"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("a89ac403-6127-42a3-91a3-dcfb38d08181"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("27dfda8a-4672-44d8-8cb3-7a0228595bc8"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk7", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("db124b9f-2519-4517-beaa-63d032b2b76e"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("27dfda8a-4672-44d8-8cb3-7a0228595bc8"), "My 7. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("fc8cd28e-7f2a-4bac-941a-a7d691e10b7c"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("27dfda8a-4672-44d8-8cb3-7a0228595bc8"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("88f30ada-66e7-4c94-8f34-8285607c488c"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("022cca00-53b3-429d-8ce7-c39c049589e1"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk6", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("bf675447-6638-4df6-9a56-aacfadfe1f65"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("022cca00-53b3-429d-8ce7-c39c049589e1"), "My 6. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("027fab0c-29be-49c6-a948-224b1e3a04e9"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("022cca00-53b3-429d-8ce7-c39c049589e1"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("63d61a48-ea03-454e-be43-51b91350f297"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07943d46-e463-494d-97ab-9bc81c623394"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk5", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("f0919e7f-e095-466f-9931-7411aa536881"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07943d46-e463-494d-97ab-9bc81c623394"), "My 5. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("ebe4451c-88cc-4739-9b0a-633d11b7bea0"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07943d46-e463-494d-97ab-9bc81c623394"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("289d3ab1-06ba-4c03-9647-db3b4559563d"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3bdfc502-ab52-4860-b6a7-77f473ef91e3"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk4", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("ed9f8e09-4522-4ffe-b3a8-7b4872bc7ddc"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3bdfc502-ab52-4860-b6a7-77f473ef91e3"), "My 4. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("61c3a8cc-7558-42d4-acfa-7dabe2d2e266"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3bdfc502-ab52-4860-b6a7-77f473ef91e3"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("5aed5313-39ef-4bd5-9f89-95410bb9152c"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1938172f-3f01-491a-81c2-d766e421ed79"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk3", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("3b8448de-17dd-4e24-b35b-9b6277cd644d"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1938172f-3f01-491a-81c2-d766e421ed79"), "My 3. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("47b62055-ce7c-426a-82a0-84a4a1f0a057"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1938172f-3f01-491a-81c2-d766e421ed79"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("e29f5e81-b85a-429a-a871-2b379a6f13e0"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e4c9ff42-062a-41fe-b224-42ec0cd6eaa8"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk2", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("0505f08c-c583-4084-8a1c-7d5603814e18"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e4c9ff42-062a-41fe-b224-42ec0cd6eaa8"), "My 2. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("cffda42c-9e7b-4d91-962e-3f9035bba011"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e4c9ff42-062a-41fe-b224-42ec0cd6eaa8"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("e5df096f-cbac-439d-810e-7003f90df768"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b7fba040-6b10-47bc-9156-ad0f14dcc59b"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk1", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("a912e314-8929-4190-babc-132ba7b7f9f3"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b7fba040-6b10-47bc-9156-ad0f14dcc59b"), "My 1. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("92927a74-9a2b-455b-9d36-cea3580d4202"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b7fba040-6b10-47bc-9156-ad0f14dcc59b"), "Image", 0m, "https://localhost:44308/statuses/images/a.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("3fdeb62f-0651-4aa6-a5fc-057b7461ade1"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22ea1815-a784-4c6a-9dfc-c1968f9682d8"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk0", "https://localhost:44308/statuses/videos/a.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("e3c5cd89-edbf-4921-a074-be31250576ad"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("22ea1815-a784-4c6a-9dfc-c1968f9682d8"), "My 0. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m },
                    { new Guid("f16241e9-e251-4caa-8741-8c154c082973"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed969ad4-a203-48d8-bd6f-40bdcec5c531"), "My 9. Status.", "Quote", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("4045a98a-b289-436e-9512-e21db9b31d0b"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ed969ad4-a203-48d8-bd6f-40bdcec5c531"), "https://localhost:44308/statuses/images/a.png", "Video", 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 0m, "Aşk9", "https://localhost:44308/statuses/videos/a.mp4", 0m });

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

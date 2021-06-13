using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nahhas.Library.Migrations
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
                    CoverPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCount = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    AdditionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    AdditionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    { new Guid("2bb6ed74-970f-4b88-9f50-9a46aeb05f06"), true, new DateTime(2021, 6, 13, 20, 50, 4, 173, DateTimeKind.Utc).AddTicks(7974), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 173, DateTimeKind.Utc).AddTicks(8748), "0th Love", 0m },
                    { new Guid("bfd100d8-e04d-48c9-8c85-3517ade8a4d0"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3342), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3344), "1th Love", 0m },
                    { new Guid("2ae9104e-9557-49dc-b505-60ef9f992718"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3516), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3517), "2th Love", 0m },
                    { new Guid("67b3b238-43e2-4474-8cc1-e2051581d072"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3604), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3605), "3th Love", 0m },
                    { new Guid("c6d2d0f7-c8ce-42e0-a13d-9f40de6bac4d"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3744), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3745), "4th Love", 0m },
                    { new Guid("b36fc3eb-c009-4cff-8c83-3133cefadeed"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3840), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3841), "5th Love", 0m },
                    { new Guid("41c356c6-183d-4d65-94f3-8a0afc75088a"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3929), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3930), "6th Love", 0m },
                    { new Guid("f275ea2b-2017-4669-9d3e-c4056020d5f3"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4046), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4048), "7th Love", 0m },
                    { new Guid("ffa09755-ab22-4f4c-997c-02f23ee65e38"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4135), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4136), "8th Love", 0m },
                    { new Guid("2be86752-e929-4533-9b06-a3a8ebeca32f"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4306), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4308), "9th Love", 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("68530729-797b-4bf0-9ffb-813d4352ed8b"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(2308), new Guid("2bb6ed74-970f-4b88-9f50-9a46aeb05f06"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(2311), 0m, 0m, 0m },
                    { new Guid("518671bb-d2f8-4b58-b9ed-e78a96f4749c"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4357), new Guid("2be86752-e929-4533-9b06-a3a8ebeca32f"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4358), 0m, 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("a18e40aa-83f8-448d-a65c-168565f5f835"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4160), new Guid("ffa09755-ab22-4f4c-997c-02f23ee65e38"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4161), 0m, 0m, "8th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("482d1d04-412e-47d7-a6e2-1837f7c4b9bf"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4206), new Guid("ffa09755-ab22-4f4c-997c-02f23ee65e38"), "8th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4207), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("558568f3-9bc1-486f-bb44-d38334a4dfde"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4183), new Guid("ffa09755-ab22-4f4c-997c-02f23ee65e38"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4184), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("d5c39059-60c2-4404-82e4-049ff57254ad"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4069), new Guid("f275ea2b-2017-4669-9d3e-c4056020d5f3"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4070), 0m, 0m, "7th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("79fa2e2e-df3b-4d55-8c52-14428813ec66"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4112), new Guid("f275ea2b-2017-4669-9d3e-c4056020d5f3"), "7th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4113), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("726dc643-5986-427c-b3e5-30f96a886079"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4090), new Guid("f275ea2b-2017-4669-9d3e-c4056020d5f3"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4091), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("405665e0-71cf-4204-9fb6-9c96ec1c99b4"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3951), new Guid("41c356c6-183d-4d65-94f3-8a0afc75088a"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3952), 0m, 0m, "6th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("4eac6584-a117-4d4f-ba94-f86cf673f3e2"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4023), new Guid("41c356c6-183d-4d65-94f3-8a0afc75088a"), "6th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4024), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("6e674da7-0edf-4b4c-be99-6672394396df"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3972), new Guid("41c356c6-183d-4d65-94f3-8a0afc75088a"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3973), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("6a5904c4-56fb-498c-9de6-bfe1df6ce9f6"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3862), new Guid("b36fc3eb-c009-4cff-8c83-3133cefadeed"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3863), 0m, 0m, "5th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("e9009548-a9a6-4b83-8c52-2397281d0dc6"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3905), new Guid("b36fc3eb-c009-4cff-8c83-3133cefadeed"), "5th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3906), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("3fde3da4-696a-42be-904a-0826eda5b94d"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3883), new Guid("b36fc3eb-c009-4cff-8c83-3133cefadeed"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3885), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("96eb92be-25c0-4fcd-a140-8f0e7b09329b"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3772), new Guid("c6d2d0f7-c8ce-42e0-a13d-9f40de6bac4d"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3773), 0m, 0m, "4th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("32886cc8-04a7-4962-a581-80bb33166c7a"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3816), new Guid("c6d2d0f7-c8ce-42e0-a13d-9f40de6bac4d"), "4th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3818), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("b2d1dfa9-2b8e-4504-bbfe-08d5c9e8798c"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3794), new Guid("c6d2d0f7-c8ce-42e0-a13d-9f40de6bac4d"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3795), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("365ee8a9-c9fc-464e-b733-4dc5df21bfa0"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3675), new Guid("67b3b238-43e2-4474-8cc1-e2051581d072"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3676), 0m, 0m, "3th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("3bf2e138-2496-4b90-8c7c-0e3e42422f69"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3721), new Guid("67b3b238-43e2-4474-8cc1-e2051581d072"), "3th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3721), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("6a956424-afe0-4491-844a-d8946b8725b2"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3700), new Guid("67b3b238-43e2-4474-8cc1-e2051581d072"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3701), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("51d6d0c4-b0f6-4823-a58e-5b3ef4da38ed"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3539), new Guid("2ae9104e-9557-49dc-b505-60ef9f992718"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3540), 0m, 0m, "2th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("dfd53def-b1aa-4698-9071-a248078c1e02"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3583), new Guid("2ae9104e-9557-49dc-b505-60ef9f992718"), "2th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3584), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("d521c987-2dfc-4f46-a2a5-314f4cb53ab1"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3561), new Guid("2ae9104e-9557-49dc-b505-60ef9f992718"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3562), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("761f7954-98f0-4921-8598-4f2ce0e42a0f"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3429), new Guid("bfd100d8-e04d-48c9-8c85-3517ade8a4d0"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3430), 0m, 0m, "1th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("1d50f4a0-1b83-4960-8dfe-3699796fd077"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3483), new Guid("bfd100d8-e04d-48c9-8c85-3517ade8a4d0"), "1th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3484), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Discriminator", "DownloadsCount", "ImagePath", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[] { new Guid("0b933dc0-6cd7-4e71-83c9-4a0b7ceacb7b"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3457), new Guid("bfd100d8-e04d-48c9-8c85-3517ade8a4d0"), "Image", 0m, "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3458), 0m, 0m, 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("94352c7b-b5b9-424b-8550-f2c5d7569ebb"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(1426), new Guid("2bb6ed74-970f-4b88-9f50-9a46aeb05f06"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(1431), 0m, 0m, "0th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "Content", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "ViewsCount" },
                values: new object[,]
                {
                    { new Guid("422cbc64-aaa9-437b-92a6-f3a5138a9a19"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3161), new Guid("2bb6ed74-970f-4b88-9f50-9a46aeb05f06"), "0th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(3165), 0m, 0m, 0m },
                    { new Guid("1c7de042-6c56-4d62-a7c9-4eead1f9502b"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4378), new Guid("2be86752-e929-4533-9b06-a3a8ebeca32f"), "9th Quote.", "Quote", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4379), 0m, 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Active", "AdditionDate", "CategoryId", "CoverPath", "Discriminator", "DownloadsCount", "LastModified", "LikesCount", "SharesCount", "Title", "VideoPath", "ViewsCount" },
                values: new object[] { new Guid("ec073a8d-0e3a-475c-9883-ff9b1f66660c"), true, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4335), new Guid("2be86752-e929-4533-9b06-a3a8ebeca32f"), "https://nahhasapi20210611231706.azurewebsites.net/statuses/images/2021-6-11-21-5-20-31-14542525338141bbbf215cecf7561b11.png", "Video", 0m, new DateTime(2021, 6, 13, 20, 50, 4, 175, DateTimeKind.Utc).AddTicks(4336), 0m, 0m, "9th Video", "https://nahhasapi20210611231706.azurewebsites.net/statuses/videos/2021-6-11-21-5-5-108-8668c83aeb6b49e3905939b375c9c11d.mp4", 0m });

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

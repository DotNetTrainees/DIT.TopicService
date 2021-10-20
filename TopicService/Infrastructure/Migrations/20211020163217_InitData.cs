using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicService.Infrastructure.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: false),
                    ReplyCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: false),
                    TopicId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Date", "ReplyCount", "Text", "Title", "UserId" },
                values: new object[] { new Guid("217fb2d7-af87-4d08-9921-108155d7a048"), new DateTime(2021, 10, 20, 19, 32, 12, 880, DateTimeKind.Local).AddTicks(8634), 0, "test_text", "test_title", new Guid("9ccf8317-3109-47d3-b0f8-704a55849f2a") });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_TopicId",
                table: "Replies",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}

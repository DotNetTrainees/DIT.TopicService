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
                    UserId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
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
                    TopicId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
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
                values: new object[] { new Guid("62defcec-c6d0-4f90-a980-f463a845a6ec"), new DateTime(2021, 10, 17, 2, 6, 1, 740, DateTimeKind.Local).AddTicks(5106), 0, "test_text", "test_title", "test_user" });

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

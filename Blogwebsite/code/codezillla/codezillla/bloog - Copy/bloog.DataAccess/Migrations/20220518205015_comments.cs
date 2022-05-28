using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloog.DataAccess.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CommentId",
                table: "AspNetUsers",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Comment_CommentId",
                table: "AspNetUsers",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Comment_CommentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CommentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "AspNetUsers");
        }
    }
}

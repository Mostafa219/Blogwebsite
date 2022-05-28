using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloog.DataAccess.Migrations
{
    public partial class replies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comment_CommentId",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_CommentId",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Replies");

            migrationBuilder.AddColumn<string>(
                name: "CommentId1",
                table: "Replies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId1",
                table: "Replies",
                column: "CommentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comment_CommentId1",
                table: "Replies",
                column: "CommentId1",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comment_CommentId1",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_CommentId1",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "CommentId1",
                table: "Replies");

            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "Replies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_CommentId",
                table: "Replies",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comment_CommentId",
                table: "Replies",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

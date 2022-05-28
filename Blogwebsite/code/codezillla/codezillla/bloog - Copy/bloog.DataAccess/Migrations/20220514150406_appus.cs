using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloog.DataAccess.Migrations
{
    public partial class appus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BlogsInfo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BlogsInfo_ApplicationUserId",
                table: "BlogsInfo",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogsInfo_AspNetUsers_ApplicationUserId",
                table: "BlogsInfo",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogsInfo_AspNetUsers_ApplicationUserId",
                table: "BlogsInfo");

            migrationBuilder.DropIndex(
                name: "IX_BlogsInfo_ApplicationUserId",
                table: "BlogsInfo");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BlogsInfo");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloog.DataAccess.Migrations
{
    public partial class Lik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "BlogsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "BlogsInfo");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Blogs");
        }
    }
}

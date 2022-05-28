using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bloog.DataAccess.Migrations
{
    public partial class replies_comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Wed",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wed",
                table: "Comment");
        }
    }
}

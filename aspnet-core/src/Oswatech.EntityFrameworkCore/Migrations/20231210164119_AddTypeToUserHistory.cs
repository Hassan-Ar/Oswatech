using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oswatech.Migrations
{
    public partial class AddTypeToUserHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "UserHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserHistory");
        }
    }
}

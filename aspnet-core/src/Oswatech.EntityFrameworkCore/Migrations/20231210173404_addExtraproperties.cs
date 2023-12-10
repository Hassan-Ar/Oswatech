using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oswatech.Migrations
{
    public partial class addExtraproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasWIFI",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasMarket",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasGarage",
                table: "Buildings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasWIFI",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "HasMarket",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "HasGarage",
                table: "Buildings");
        }
    }
}

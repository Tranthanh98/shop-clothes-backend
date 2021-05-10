using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class UpdateModelProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHotSale",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHotSale",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Products");
        }
    }
}

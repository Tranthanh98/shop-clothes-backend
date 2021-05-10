using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class DeleteProductSizeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductSizeId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductSizeId",
                table: "Products",
                type: "int",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class UpdateTypeProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeProducts_Products_ProductId",
                table: "TypeProducts");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Type_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProducts_Products_ProductId",
                table: "TypeProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Type_TypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProducts_Products_ProductId",
                table: "TypeProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypeId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProducts_Products_ProductId",
                table: "TypeProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class DataSeeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_ProductTypes_ParentId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProduct_Products_ProductId",
                table: "TypeProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProduct_ProductTypes_TypeId",
                table: "TypeProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProduct",
                table: "TypeProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "TypeProduct",
                newName: "TypeProducts");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_TypeProduct_ProductId",
                table: "TypeProducts",
                newName: "IX_TypeProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_ParentId",
                table: "Type",
                newName: "IX_Type_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts",
                columns: new[] { "TypeId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Type_ParentId",
                table: "Type",
                column: "ParentId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProducts_Products_ProductId",
                table: "TypeProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProducts_Type_TypeId",
                table: "TypeProducts",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Type_Type_ParentId",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProducts_Products_ProductId",
                table: "TypeProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProducts_Type_TypeId",
                table: "TypeProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeProducts",
                table: "TypeProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.RenameTable(
                name: "TypeProducts",
                newName: "TypeProduct");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "ProductTypes");

            migrationBuilder.RenameIndex(
                name: "IX_TypeProducts_ProductId",
                table: "TypeProduct",
                newName: "IX_TypeProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Type_ParentId",
                table: "ProductTypes",
                newName: "IX_ProductTypes_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeProduct",
                table: "TypeProduct",
                columns: new[] { "TypeId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_ProductTypes_ParentId",
                table: "ProductTypes",
                column: "ParentId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProduct_Products_ProductId",
                table: "TypeProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProduct_ProductTypes_TypeId",
                table: "TypeProduct",
                column: "TypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

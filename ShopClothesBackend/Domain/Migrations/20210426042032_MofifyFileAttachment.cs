using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class MofifyFileAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_Products_ProductTitleId",
                table: "FileAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FileAttachments_ProductTitleId",
                table: "FileAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTitleId",
                table: "FileAttachments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductImageId",
                table: "FileAttachments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_ProductTitleId",
                table: "FileAttachments",
                column: "ProductTitleId",
                unique: true,
                filter: "[ProductTitleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_Products_ProductTitleId",
                table: "FileAttachments",
                column: "ProductTitleId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileAttachments_Products_ProductTitleId",
                table: "FileAttachments");

            migrationBuilder.DropIndex(
                name: "IX_FileAttachments_ProductTitleId",
                table: "FileAttachments");

            migrationBuilder.AlterColumn<int>(
                name: "ProductTitleId",
                table: "FileAttachments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductImageId",
                table: "FileAttachments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileAttachments_ProductTitleId",
                table: "FileAttachments",
                column: "ProductTitleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileAttachments_Products_ProductTitleId",
                table: "FileAttachments",
                column: "ProductTitleId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

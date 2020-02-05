using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class FreshDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThirdCategories_Categories_CategoryId",
                table: "ThirdCategories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ThirdCategories",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ThirdCategories_CategoryId",
                table: "ThirdCategories",
                newName: "IX_ThirdCategories_categoryId");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "ThirdCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdCategories_Categories_categoryId",
                table: "ThirdCategories",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThirdCategories_Categories_categoryId",
                table: "ThirdCategories");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "ThirdCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ThirdCategories_categoryId",
                table: "ThirdCategories",
                newName: "IX_ThirdCategories_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ThirdCategories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdCategories_Categories_CategoryId",
                table: "ThirdCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

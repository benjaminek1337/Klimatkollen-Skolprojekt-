using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class NewFreshDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThirdCategories_Categories_CategoryId",
                table: "ThirdCategories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ThirdCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThirdCategories_Categories_CategoryId",
                table: "ThirdCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThirdCategories_Categories_CategoryId",
                table: "ThirdCategories");

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

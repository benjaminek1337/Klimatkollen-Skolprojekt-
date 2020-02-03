using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class MainCategoryInCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoriesId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoriesId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoriesId",
                table: "Categories",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoriesId",
                table: "Categories",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class MainCategoryInCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainCategoryId",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_MainCategories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_MainCategories_MainCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_MainCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MainCategoryId",
                table: "Categories");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class refreshDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilters_MainCategories_mainCategoryId",
                table: "UserFilters");

            migrationBuilder.DropIndex(
                name: "IX_UserFilters_mainCategoryId",
                table: "UserFilters");

            migrationBuilder.DropColumn(
                name: "mainCategoryId",
                table: "UserFilters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mainCategoryId",
                table: "UserFilters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserFilters_mainCategoryId",
                table: "UserFilters",
                column: "mainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilters_MainCategories_mainCategoryId",
                table: "UserFilters",
                column: "mainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

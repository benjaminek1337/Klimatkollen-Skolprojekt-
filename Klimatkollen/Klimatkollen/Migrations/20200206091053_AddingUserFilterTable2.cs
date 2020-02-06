using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class AddingUserFilterTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilters_MainCategories_MainCategoryId",
                table: "UserFilters");

            migrationBuilder.RenameColumn(
                name: "MainCategoryId",
                table: "UserFilters",
                newName: "mainCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFilters_MainCategoryId",
                table: "UserFilters",
                newName: "IX_UserFilters_mainCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "mainCategoryId",
                table: "UserFilters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilters_MainCategories_mainCategoryId",
                table: "UserFilters",
                column: "mainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilters_MainCategories_mainCategoryId",
                table: "UserFilters");

            migrationBuilder.RenameColumn(
                name: "mainCategoryId",
                table: "UserFilters",
                newName: "MainCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFilters_mainCategoryId",
                table: "UserFilters",
                newName: "IX_UserFilters_MainCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "MainCategoryId",
                table: "UserFilters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilters_MainCategories_MainCategoryId",
                table: "UserFilters",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

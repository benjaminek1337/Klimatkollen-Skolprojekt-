using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class AddingUserFilterTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilters_Categories_CategoryId",
                table: "UserFilters");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "UserFilters",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFilters_CategoryId",
                table: "UserFilters",
                newName: "IX_UserFilters_categoryId");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "UserFilters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilters_Categories_categoryId",
                table: "UserFilters",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilters_Categories_categoryId",
                table: "UserFilters");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "UserFilters",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFilters_categoryId",
                table: "UserFilters",
                newName: "IX_UserFilters_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "UserFilters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilters_Categories_CategoryId",
                table: "UserFilters",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

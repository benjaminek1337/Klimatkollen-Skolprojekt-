using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class FreshDb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Categories_categoryId",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Measurements",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_categoryId",
                table: "Measurements",
                newName: "IX_Measurements_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Measurements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Categories_CategoryId",
                table: "Measurements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Categories_CategoryId",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Measurements",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_CategoryId",
                table: "Measurements",
                newName: "IX_Measurements_categoryId");

            migrationBuilder.AlterColumn<int>(
                name: "categoryId",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Categories_categoryId",
                table: "Measurements",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

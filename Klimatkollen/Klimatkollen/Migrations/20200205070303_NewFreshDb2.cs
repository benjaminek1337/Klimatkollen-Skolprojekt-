using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class NewFreshDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_ThirdCategories_ThirdCategoryId",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "ThirdCategoryId",
                table: "Measurements",
                newName: "thirdCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_ThirdCategoryId",
                table: "Measurements",
                newName: "IX_Measurements_thirdCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "thirdCategoryId",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_ThirdCategories_thirdCategoryId",
                table: "Measurements",
                column: "thirdCategoryId",
                principalTable: "ThirdCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_ThirdCategories_thirdCategoryId",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "thirdCategoryId",
                table: "Measurements",
                newName: "ThirdCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_thirdCategoryId",
                table: "Measurements",
                newName: "IX_Measurements_ThirdCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "ThirdCategoryId",
                table: "Measurements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_ThirdCategories_ThirdCategoryId",
                table: "Measurements",
                column: "ThirdCategoryId",
                principalTable: "ThirdCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

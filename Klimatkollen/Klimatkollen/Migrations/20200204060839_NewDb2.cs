using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class NewDb2 : Migration
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

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "thirdCategoryId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "thirdCategoryId",
                value: 0);

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

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1,
                column: "ThirdCategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThirdCategoryId",
                value: null);

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

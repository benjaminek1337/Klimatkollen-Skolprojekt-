using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class UpdateMeasurementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_ThirdCategories_thirdCategoryId",
                table: "Measurements");

            migrationBuilder.AlterColumn<int>(
                name: "thirdCategoryId",
                table: "Measurements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_ThirdCategories_thirdCategoryId",
                table: "Measurements",
                column: "thirdCategoryId",
                principalTable: "ThirdCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_ThirdCategories_thirdCategoryId",
                table: "Measurements");

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
    }
}

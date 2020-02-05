using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class FreshDb8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_MainCategories_MainCategoryId",
                table: "Observations");

            migrationBuilder.RenameColumn(
                name: "MainCategoryId",
                table: "Observations",
                newName: "maincategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_MainCategoryId",
                table: "Observations",
                newName: "IX_Observations_maincategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "maincategoryId",
                table: "Observations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_MainCategories_maincategoryId",
                table: "Observations",
                column: "maincategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_MainCategories_maincategoryId",
                table: "Observations");

            migrationBuilder.RenameColumn(
                name: "maincategoryId",
                table: "Observations",
                newName: "MainCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_maincategoryId",
                table: "Observations",
                newName: "IX_Observations_MainCategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "MainCategoryId",
                table: "Observations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_MainCategories_MainCategoryId",
                table: "Observations",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

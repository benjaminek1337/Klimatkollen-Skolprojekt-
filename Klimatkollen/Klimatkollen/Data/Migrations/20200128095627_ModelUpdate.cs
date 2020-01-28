using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Data.Migrations
{
    public partial class ModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_measurementCategoriesId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Categories_CategoryId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Measurements_measurementId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Persons_personId",
                table: "Observations");

            migrationBuilder.RenameColumn(
                name: "measurementCategoriesId",
                table: "Categories",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_measurementCategoriesId",
                table: "Categories",
                newName: "IX_Categories_CategoriesId");

            migrationBuilder.AlterColumn<int>(
                name: "personId",
                table: "Observations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "measurementId",
                table: "Observations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoriesId",
                table: "Categories",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Categories_CategoryId",
                table: "Measurements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Measurements_measurementId",
                table: "Observations",
                column: "measurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Persons_personId",
                table: "Observations",
                column: "personId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoriesId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Categories_CategoryId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Measurements_measurementId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Persons_personId",
                table: "Observations");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Categories",
                newName: "measurementCategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_CategoriesId",
                table: "Categories",
                newName: "IX_Categories_measurementCategoriesId");

            migrationBuilder.AlterColumn<int>(
                name: "personId",
                table: "Observations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "measurementId",
                table: "Observations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Measurements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_measurementCategoriesId",
                table: "Categories",
                column: "measurementCategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Categories_CategoryId",
                table: "Measurements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Measurements_measurementId",
                table: "Observations",
                column: "measurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Persons_personId",
                table: "Observations",
                column: "personId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

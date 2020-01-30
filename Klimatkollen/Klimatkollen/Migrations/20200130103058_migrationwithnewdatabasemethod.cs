using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class migrationwithnewdatabasemethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_MainCategory_MainCategoryId",
                table: "Observations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainCategory",
                table: "MainCategory");

            migrationBuilder.RenameTable(
                name: "MainCategory",
                newName: "MainCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainCategories",
                table: "MainCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_MainCategories_MainCategoryId",
                table: "Observations",
                column: "MainCategoryId",
                principalTable: "MainCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_MainCategories_MainCategoryId",
                table: "Observations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainCategories",
                table: "MainCategories");

            migrationBuilder.RenameTable(
                name: "MainCategories",
                newName: "MainCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainCategory",
                table: "MainCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_MainCategory_MainCategoryId",
                table: "Observations",
                column: "MainCategoryId",
                principalTable: "MainCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

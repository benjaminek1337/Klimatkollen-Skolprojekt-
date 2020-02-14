using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class refreshDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Measurements_categoryId",
                table: "Measurements",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Categories_categoryId",
                table: "Measurements",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Categories_categoryId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_categoryId",
                table: "Measurements");
        }
    }
}

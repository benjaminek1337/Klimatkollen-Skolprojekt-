using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class FreshDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Measurements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_CategoryId",
                table: "Measurements",
                column: "CategoryId");

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

            migrationBuilder.DropIndex(
                name: "IX_Measurements_CategoryId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Measurements");
        }
    }
}

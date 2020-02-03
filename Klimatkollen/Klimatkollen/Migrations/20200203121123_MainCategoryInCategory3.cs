using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class MainCategoryInCategory3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "Measurements",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Measurements");
        }
    }
}

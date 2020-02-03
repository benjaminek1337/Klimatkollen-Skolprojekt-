using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class MainCategoryInCategory6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "thirdCategoryId",
                table: "Measurements",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "thirdCategoryId",
                table: "Measurements");
        }
    }
}

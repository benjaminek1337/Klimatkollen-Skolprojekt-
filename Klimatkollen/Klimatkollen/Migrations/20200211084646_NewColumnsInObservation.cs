using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class NewColumnsInObservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdministrativeArea",
                table: "Observations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Observations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdministrativeArea",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "Observations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Data.Migrations
{
    public partial class UpdatedPersonClassAgai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Persons");
        }
    }
}

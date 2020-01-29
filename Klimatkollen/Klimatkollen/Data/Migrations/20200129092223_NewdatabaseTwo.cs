using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Data.Migrations
{
    public partial class NewdatabaseTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Persons");
        }
    }
}

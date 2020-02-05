using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class FreshDb11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Measurements_MeasurementId",
                table: "Observations");

            migrationBuilder.RenameColumn(
                name: "MeasurementId",
                table: "Observations",
                newName: "measurementID");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_MeasurementId",
                table: "Observations",
                newName: "IX_Observations_measurementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Measurements_measurementID",
                table: "Observations",
                column: "measurementID",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Measurements_measurementID",
                table: "Observations");

            migrationBuilder.RenameColumn(
                name: "measurementID",
                table: "Observations",
                newName: "MeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_measurementID",
                table: "Observations",
                newName: "IX_Observations_MeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Measurements_MeasurementId",
                table: "Observations",
                column: "MeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

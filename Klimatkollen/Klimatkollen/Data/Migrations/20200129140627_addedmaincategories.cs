using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Data.Migrations
{
    public partial class addedmaincategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Measurements_measurementId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Persons_personId",
                table: "Observations");

            migrationBuilder.RenameColumn(
                name: "personId",
                table: "Observations",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "measurementId",
                table: "Observations",
                newName: "MeasurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_personId",
                table: "Observations",
                newName: "IX_Observations_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_measurementId",
                table: "Observations",
                newName: "IX_Observations_MeasurementId");

            migrationBuilder.AddColumn<int>(
                name: "MainCategoryId",
                table: "Observations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observations_MainCategoryId",
                table: "Observations",
                column: "MainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_MainCategory_MainCategoryId",
                table: "Observations",
                column: "MainCategoryId",
                principalTable: "MainCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Measurements_MeasurementId",
                table: "Observations",
                column: "MeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Observations_Persons_PersonId",
                table: "Observations",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observations_MainCategory_MainCategoryId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Measurements_MeasurementId",
                table: "Observations");

            migrationBuilder.DropForeignKey(
                name: "FK_Observations_Persons_PersonId",
                table: "Observations");

            migrationBuilder.DropTable(
                name: "MainCategory");

            migrationBuilder.DropIndex(
                name: "IX_Observations_MainCategoryId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "MainCategoryId",
                table: "Observations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Observations",
                newName: "personId");

            migrationBuilder.RenameColumn(
                name: "MeasurementId",
                table: "Observations",
                newName: "measurementId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_PersonId",
                table: "Observations",
                newName: "IX_Observations_personId");

            migrationBuilder.RenameIndex(
                name: "IX_Observations_MeasurementId",
                table: "Observations",
                newName: "IX_Observations_measurementId");

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
    }
}

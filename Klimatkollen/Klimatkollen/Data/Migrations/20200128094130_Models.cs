using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unit = table.Column<string>(nullable: true),
                    measurementCategoriesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_measurementCategoriesId",
                        column: x => x.measurementCategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    personId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    measurementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Measurements_measurementId",
                        column: x => x.measurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Observations_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_measurementCategoriesId",
                table: "Categories",
                column: "measurementCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_CategoryId",
                table: "Measurements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_measurementId",
                table: "Observations",
                column: "measurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_personId",
                table: "Observations",
                column: "personId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

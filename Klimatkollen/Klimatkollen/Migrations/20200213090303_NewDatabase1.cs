using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class NewDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unit = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    MainCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    AdministrativeArea = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    maincategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observations_MainCategories_maincategoryId",
                        column: x => x.maincategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTrackedLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrackedLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrackedLocations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThirdCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unit = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    categoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdCategories_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFilters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true),
                    categoryId = table.Column<int>(nullable: false),
                    FilterName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFilters_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFilters_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    observationId = table.Column<int>(nullable: false),
                    thirdCategoryId = table.Column<int>(nullable: true),
                    categoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurements_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measurements_Observations_observationId",
                        column: x => x.observationId,
                        principalTable: "Observations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Measurements_ThirdCategories_thirdCategoryId",
                        column: x => x.thirdCategoryId,
                        principalTable: "ThirdCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "MainCategoryId", "Type", "Unit" },
                values: new object[,]
                {
                    { 1, null, "Vind", "m/s" },
                    { 2, null, "Temperatur", "Celcius" },
                    { 3, null, "Väder", "Väder" },
                    { 4, null, "Groda", "Djur" },
                    { 5, null, "Vildsvin", "Djur" },
                    { 6, null, "Ripa", "Päls" },
                    { 7, null, "Fjällräv", "Päls" },
                    { 8, null, "Träd", "Annat" },
                    { 9, null, "Hare", "Päls" },
                    { 10, null, null, "Annat" }
                });

            migrationBuilder.InsertData(
                table: "MainCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Miljö" },
                    { 2, "Djur" },
                    { 3, "Annat" }
                });

            migrationBuilder.InsertData(
                table: "ThirdCategories",
                columns: new[] { "Id", "Type", "Unit", "categoryId" },
                values: new object[,]
                {
                    { 9, "Vindhastighet", "m/s", 1 },
                    { 6, "Sommarpäls", "Päls", 9 },
                    { 5, "Vinterpäls", "Päls", 9 },
                    { 17, "Snö", "Miljö", 7 },
                    { 16, "Barmark", "Miljö", 7 },
                    { 4, "Sommarpäls", "Päls", 7 },
                    { 3, "Vinterpäls", "Päls", 7 },
                    { 15, "Snö", "Miljö", 6 },
                    { 18, "Barmark", "Miljö", 9 },
                    { 14, "Barmark", "Miljö", 6 },
                    { 1, "Vinterpäls", "Päls", 6 },
                    { 13, "Snödjup", "cm", 3 },
                    { 12, "Luftfuktighet", "%", 3 },
                    { 11, "PH-värde", "p/h", 3 },
                    { 8, "Lufttemperatur", "Celcius", 2 },
                    { 7, "Vattentemperatur", "Celcius", 2 },
                    { 10, "Vindriktning", "grader", 1 },
                    { 2, "Sommarpäls", "Päls", 6 },
                    { 19, "Snö", "Miljö", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategoryId",
                table: "Categories",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_categoryId",
                table: "Measurements",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_observationId",
                table: "Measurements",
                column: "observationId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_thirdCategoryId",
                table: "Measurements",
                column: "thirdCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_PersonId",
                table: "Observations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_maincategoryId",
                table: "Observations",
                column: "maincategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdCategories_categoryId",
                table: "ThirdCategories",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFilters_PersonId",
                table: "UserFilters",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFilters_categoryId",
                table: "UserFilters",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrackedLocations_PersonId",
                table: "UserTrackedLocations",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "UserFilters");

            migrationBuilder.DropTable(
                name: "UserTrackedLocations");

            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "ThirdCategories");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "MainCategories");
        }
    }
}

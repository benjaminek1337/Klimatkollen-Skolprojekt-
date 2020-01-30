using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class freshSeedtesfour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Categories_CategoryId",
                table: "Measurements");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Measurements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoriesId", "Type", "Unit" },
                values: new object[,]
                {
                    { 2, null, "VindStyrka", "m/s" },
                    { 3, null, "Vindriktning", "grader" }
                });

            migrationBuilder.InsertData(
                table: "MainCategory",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Miljö" },
                    { 2, "Djur" },
                    { 3, "Annat" }
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "CategoryId", "Value" },
                values: new object[,]
                {
                    { 1, null, "14" },
                    { 2, null, "134" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Email", "FirstName", "Lastname", "UserName" },
                values: new object[,]
                {
                    { 1, "Uia@gmail.com", null, null, null },
                    { 2, "Udalliaa@gmail.com", null, null, null },
                    { 3, "Lisantia@gmail.com", null, null, null }
                });

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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MainCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Categories_CategoryId",
                table: "Measurements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

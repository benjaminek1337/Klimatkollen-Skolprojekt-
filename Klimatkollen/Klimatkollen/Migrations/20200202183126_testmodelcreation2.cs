using Microsoft.EntityFrameworkCore.Migrations;

namespace Klimatkollen.Migrations
{
    public partial class testmodelcreation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MainCategories",
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoriesId", "Type", "Unit" },
                values: new object[] { 1, null, "Vind", null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoriesId", "Type", "Unit" },
                values: new object[] { 1, "Vindstyrka", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoriesId", "Type", "Unit" },
                values: new object[] { null, "VindStyrka", "m/s" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoriesId", "Type", "Unit" },
                values: new object[] { 3, null, "Vindriktning", "grader" });

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
                table: "Measurements",
                columns: new[] { "Id", "CategoryId", "Value" },
                values: new object[,]
                {
                    { 1, null, "14" },
                    { 2, null, "134" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Email", "FirstName", "IdentityId", "Lastname", "UserName" },
                values: new object[,]
                {
                    { 1, "Uia@gmail.com", null, null, null, null },
                    { 2, "Udalliaa@gmail.com", null, null, null, null },
                    { 3, "Lisantia@gmail.com", null, null, null, null }
                });
        }
    }
}

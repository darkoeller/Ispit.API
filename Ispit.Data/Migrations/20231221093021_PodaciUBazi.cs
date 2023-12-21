using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Data.Migrations
{
    public partial class PodaciUBazi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoLists",
                columns: new[] { "Id", "Description", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, "Nađi večeru", false, "Trgovina" },
                    { 2, "Kako pobjeći bez traga", false, "Bijeg" },
                    { 3, "Što raditi poslije spavanja", false, "U suton" },
                    { 4, "Zaboraviti noćne more", false, "Snovi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TodoLists",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

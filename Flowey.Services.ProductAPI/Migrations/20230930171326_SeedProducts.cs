using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flowey.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Цветы", "Розы колючие", "", "Розы", 100.0 },
                    { 2, "Цветы", "Кросивый", "", "Лилии", 150.0 },
                    { 3, "Комнатные растения", "Комнатные растения", "", "Фикус", 500.0 },
                    { 4, "Комнатные растения", "Домашнее с большими листьями", "", "Монстера", 1500.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}

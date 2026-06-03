using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eticaret.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedSlidersAndNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreateDate", "Description", "Image", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seçili laptoplarda geçerli %15 öğrenci indirimini kaçırmayın.", "kampanya1.jpg", true, "Öğrenci İndirimleri Başladı!" },
                    { 2, new DateTime(2026, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tüm oyuncu ekipmanlarında net %10 indirim bu hafta sonuna özel.", "kampanya2.jpg", true, "Hafta Sonu Fırsatları" }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "Image", "Link", "Title" },
                values: new object[,]
                {
                    { 1, "Monster, Asus ve MSI'da dev indirimleri kaçırma!", "slide1.jpg", "/Products", "Yılın En İyi Oyuncu Laptopları" },
                    { 2, "PlayStation 5 ve Xbox Series X stoklarda.", "slide2.jpg", "/Products", "Yeni Nesil Konsollar Geldi" },
                    { 3, "Kulaklık, klavye ve fare setlerinde %20 indirim.", "slide3.jpg", "/Products", "Ekipmanını Tamamla" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

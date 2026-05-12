using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eticaret.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductSeedImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 2, "asus.webp", "Asus ROG Strix Laptop", 45000m, "ASUS-ROG" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 2, "masaustupc.webp", "Masaüstü Oyuncu Bilgisayarı", 35000m, "PC-GAMING" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 2, "monitor-2.webp", "27 İnç Kavisli Monitör", 12000m, "MON27" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 1, "klavye.webp", "Mekanik Oyuncu Klavyesi", 3000m, "KEY-MECH" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 1, "gaming beyaz oyuncu mouse.webp", "Beyaz Oyuncu Mouse", 1500m, "MSE-W" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 1, "kulaklik.webp", "7.1 Surround Kulaklık", 2500m, "HS-71" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { "sony-ps5.webp", "Sony PlayStation 5", 30000m, "PS5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { "oykonsolu2.webp", "Oyun Konsolu X", 18000m, "CON-X" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { "oyunkonsolaksesuar.webp", "DualSense Kumanda", 3500m, "DS5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 2, "monstr.webp", "Monster Tulpar Notebook", 42000m, "MT-7" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { "mouse.webp", "Standart Siyah Mouse", 500m, "MS-STD" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { "mouse 2.webp", "Mavi Seritli Mouse", 600m, "MS-B" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 1, null, "iPhone 15 Pro", 75000m, "IP15P" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 1, null, "iPhone 14", 50000m, "IP14" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 1, null, "Samsung Galaxy S24", 60000m, "SGS24" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 2, null, "MacBook Air M2", 45000m, "MBA2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 2, null, "MacBook Pro M3", 95000m, "MBP3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 2, null, "Samsung Galaxy Book 3", 40000m, "SGB3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { null, "iPad Pro", 42000m, "IPP" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { null, "Samsung Galaxy Tab S9", 28000m, "SGT9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { null, "Apple Watch Series 9", 18000m, "AW9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Image", "Name", "Price", "ProductCode" },
                values: new object[] { 1, null, "Samsung Galaxy Watch 6", 10000m, "SGW6" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { null, "AirPods Pro 2", 9500m, "AP2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Image", "Name", "Price", "ProductCode" },
                values: new object[] { null, "Samsung Galaxy Buds 2 Pro", 5500m, "SGB2P" });
        }
    }
}

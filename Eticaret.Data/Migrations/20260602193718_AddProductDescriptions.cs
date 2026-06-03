using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eticaret.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Intel Core i7 işlemci, 16GB RAM, 512GB SSD ve NVIDIA GeForce RTX 4060 ekran kartı ile üstün oyun performansı sunar.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "AMD Ryzen 5, 16GB RAM, 1TB NVMe SSD ve RTX 4060 Ti ekran kartı barındıran canavar gibi oyuncu bilgisayarı.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "165Hz yenileme hızı, 1ms tepki süresi ve 2K çözünürlük ile akıcı ve sürükleyici bir görsel deneyim sağlar.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "RGB aydınlatmalı, kırmızı anahtarlı (Red Switch) ve anti-ghosting özellikli profesyonel oyuncu klavyesi.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Ultra hafif tasarımı, 12000 DPI optik sensörü ve RGB aydınlatması ile hızlı ve hassas nişan alma sağlar.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Gürültü engelleyici mikrofonu ve 7.1 sanal surround ses teknolojisi ile düşmanlarınızın yerini anında tespit edin.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "4K 120Hz oyun desteği, ultra hızlı SSD ve yeni nesil dokunsal geribildirimli DualSense kumandası ile oyunun merkezine geçin.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Yeni nesil grafik gücü, geriye dönük uyumluluk ve hızlı devam etme özellikleri sunan güçlü oyun konsolu.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Dokunsal geri bildirim, dinamik uyarlanabilir tetikleyiciler ve dahili bir mikrofon ile daha derinlemesine bir oyun deneyimi sunar.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Intel Core i9 işlemci, 32GB DDR5 RAM, 1TB SSD ve RTX 4070 ekran kartı ile sınırsız performans ve oyun keyfi.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Günlük kullanım için ideal, ergonomik ve tak-çalıştır özellikli sade siyah optik mouse.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: "Şık mavi şerit tasarımı, ayarlanabilir DPI özellikleri ve rahat tutuşu ile hem ofis hem günlük kullanım için idealdir.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "Description",
                value: null);
        }
    }
}

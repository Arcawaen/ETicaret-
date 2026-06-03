using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eticaret.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDummyOrdersAndLines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AppUserId", "BillingAddress", "CustomerId", "DeliveryAddress", "OrderDate", "OrderNumber", "OrderState", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 2, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), "ORD-20260215-01", 3, 48000m },
                    { 2, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 2, 28, 10, 15, 0, 0, DateTimeKind.Unspecified), "ORD-20260228-02", 3, 6000m },
                    { 3, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 3, 12, 18, 45, 0, 0, DateTimeKind.Unspecified), "ORD-20260312-03", 3, 12000m },
                    { 4, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 3, 20, 11, 20, 0, 0, DateTimeKind.Unspecified), "ORD-20260320-04", 3, 45000m },
                    { 5, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 4, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20260405-05", 3, 17500m },
                    { 6, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 4, 18, 16, 10, 0, 0, DateTimeKind.Unspecified), "ORD-20260418-06", 3, 35000m },
                    { 7, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 5, 2, 13, 5, 0, 0, DateTimeKind.Unspecified), "ORD-20260502-07", 3, 9000m },
                    { 8, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 5, 15, 15, 40, 0, 0, DateTimeKind.Unspecified), "ORD-20260515-08", 3, 42000m },
                    { 9, 1, "Kayseri / Kocasinan", "1", "Kayseri / Kocasinan", new DateTime(2026, 5, 28, 12, 50, 0, 0, DateTimeKind.Unspecified), "ORD-20260528-09", 1, 7500m }
                });

            migrationBuilder.InsertData(
                table: "OrderLine",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 45000m },
                    { 2, 1, 4, 1, 3000m },
                    { 3, 2, 4, 2, 3000m },
                    { 4, 3, 3, 1, 12000m },
                    { 5, 4, 1, 1, 45000m },
                    { 6, 5, 9, 5, 3500m },
                    { 7, 6, 2, 1, 35000m },
                    { 8, 7, 4, 3, 3000m },
                    { 9, 8, 10, 1, 42000m },
                    { 10, 9, 6, 3, 2500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderLine",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}

using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Eticaret.Data.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order { Id = 1, OrderNumber = "ORD-20260215-01", TotalPrice = 48000, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 2, 15, 14, 30, 0), OrderState = EnumOrderState.Completed },
                new Order { Id = 2, OrderNumber = "ORD-20260228-02", TotalPrice = 6000, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 2, 28, 10, 15, 0), OrderState = EnumOrderState.Completed },
                new Order { Id = 3, OrderNumber = "ORD-20260312-03", TotalPrice = 12000, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 3, 12, 18, 45, 0), OrderState = EnumOrderState.Completed },
                new Order { Id = 4, OrderNumber = "ORD-20260320-04", TotalPrice = 45000, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 3, 20, 11, 20, 0), OrderState = EnumOrderState.Completed },
                new Order { Id = 5, OrderNumber = "ORD-20260405-05", TotalPrice = 17500, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 4, 5, 9, 0, 0), OrderState = EnumOrderState.Completed },
                new Order { Id = 6, OrderNumber = "ORD-20260418-06", TotalPrice = 35000, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 4, 18, 16, 10, 0), OrderState = EnumOrderState.Completed },
                new Order { Id = 7, OrderNumber = "ORD-20260502-07", TotalPrice = 9000, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 5, 2, 13, 5, 0), OrderState = EnumOrderState.Completed },
                new Order { Id = 8, OrderNumber = "ORD-20260515-08", TotalPrice = 42000, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 5, 15, 15, 40, 0), OrderState = EnumOrderState.Completed },
                new Order { Id = 9, OrderNumber = "ORD-20260528-09", TotalPrice = 7500, AppUserId = 1, CustomerId = "1", BillingAddress = "Kayseri / Kocasinan", DeliveryAddress = "Kayseri / Kocasinan", OrderDate = new DateTime(2026, 5, 28, 12, 50, 0), OrderState = EnumOrderState.Approved }
            );
        }
    }
}

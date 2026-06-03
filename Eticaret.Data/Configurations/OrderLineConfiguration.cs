using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Data.Configurations
{
    internal class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasData(
                // Order 1: ROG Laptop (45000) + Mech Keyboard (3000) = 48000
                new OrderLine { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 45000 },
                new OrderLine { Id = 2, OrderId = 1, ProductId = 4, Quantity = 1, UnitPrice = 3000 },

                // Order 2: Mech Keyboard (3000) x 2 = 6000
                new OrderLine { Id = 3, OrderId = 2, ProductId = 4, Quantity = 2, UnitPrice = 3000 },

                // Order 3: 27 Inch Monitor (12000) = 12000
                new OrderLine { Id = 4, OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 12000 },

                // Order 4: Asus ROG Laptop (45000) = 45000
                new OrderLine { Id = 5, OrderId = 4, ProductId = 1, Quantity = 1, UnitPrice = 45000 },

                // Order 5: DualSense Controller (3500) x 5 = 17500
                new OrderLine { Id = 6, OrderId = 5, ProductId = 9, Quantity = 5, UnitPrice = 3500 },

                // Order 6: Gaming Desktop (35000) = 35000
                new OrderLine { Id = 7, OrderId = 6, ProductId = 2, Quantity = 1, UnitPrice = 35000 },

                // Order 7: Mech Keyboard (3000) x 3 = 9000
                new OrderLine { Id = 8, OrderId = 7, ProductId = 4, Quantity = 3, UnitPrice = 3000 },

                // Order 8: Monster Tulpar Notebook (42000) = 42000
                new OrderLine { Id = 9, OrderId = 8, ProductId = 10, Quantity = 1, UnitPrice = 42000 },

                // Order 9: 7.1 Headset (2500) x 3 = 7500
                new OrderLine { Id = 10, OrderId = 9, ProductId = 6, Quantity = 3, UnitPrice = 2500 }
            );
        }
    }
}

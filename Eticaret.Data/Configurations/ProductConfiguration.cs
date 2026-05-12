using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.Image).HasMaxLength(255);
            builder.HasData(
                new Product { Id = 1, Name = "Asus ROG Strix Laptop", Price = 45000, Stock = 50, CategoryId = 2, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "ASUS-ROG", Image = "asus.webp" },
                new Product { Id = 2, Name = "Masaüstü Oyuncu Bilgisayarı", Price = 35000, Stock = 30, CategoryId = 2, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "PC-GAMING", Image = "masaustupc.webp" },
                new Product { Id = 3, Name = "27 İnç Kavisli Monitör", Price = 12000, Stock = 40, CategoryId = 2, BrandId = 2, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MON27", Image = "monitor-2.webp" },
                new Product { Id = 4, Name = "Mekanik Oyuncu Klavyesi", Price = 3000, Stock = 20, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "KEY-MECH", Image = "klavye.webp" },
                new Product { Id = 5, Name = "Beyaz Oyuncu Mouse", Price = 1500, Stock = 10, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MSE-W", Image = "gaming beyaz oyuncu mouse.webp" },
                new Product { Id = 6, Name = "7.1 Surround Kulaklık", Price = 2500, Stock = 25, CategoryId = 1, BrandId = 2, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "HS-71", Image = "kulaklik.webp" },
                new Product { Id = 7, Name = "Sony PlayStation 5", Price = 30000, Stock = 15, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = false, CreateDate = new DateTime(2024, 1, 1), ProductCode = "PS5", Image = "sony-ps5.webp" },
                new Product { Id = 8, Name = "Oyun Konsolu X", Price = 18000, Stock = 18, CategoryId = 1, BrandId = 2, IsActive = true, IsHome = false, CreateDate = new DateTime(2024, 1, 1), ProductCode = "CON-X", Image = "oykonsolu2.webp" },
                new Product { Id = 9, Name = "DualSense Kumanda", Price = 3500, Stock = 60, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "DS5", Image = "oyunkonsolaksesuar.webp" },
                new Product { Id = 10, Name = "Monster Tulpar Notebook", Price = 42000, Stock = 45, CategoryId = 2, BrandId = 2, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MT-7", Image = "monstr.webp" },
                new Product { Id = 11, Name = "Standart Siyah Mouse", Price = 500, Stock = 100, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = false, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MS-STD", Image = "mouse.webp" },
                new Product { Id = 12, Name = "Mavi Seritli Mouse", Price = 600, Stock = 80, CategoryId = 1, BrandId = 2, IsActive = true, IsHome = false, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MS-B", Image = "mouse 2.webp" }
            );
            
        }
    
    }
}

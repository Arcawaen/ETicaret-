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
                new Product { Id = 1, Name = "Asus ROG Strix Laptop", Price = 45000, Stock = 50, CategoryId = 2, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "ASUS-ROG", Image = "asus.webp", Description = "Intel Core i7 işlemci, 16GB RAM, 512GB SSD ve NVIDIA GeForce RTX 4060 ekran kartı ile üstün oyun performansı sunar." },
                new Product { Id = 2, Name = "Masaüstü Oyuncu Bilgisayarı", Price = 35000, Stock = 30, CategoryId = 2, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "PC-GAMING", Image = "masaustupc.webp", Description = "AMD Ryzen 5, 16GB RAM, 1TB NVMe SSD ve RTX 4060 Ti ekran kartı barındıran canavar gibi oyuncu bilgisayarı." },
                new Product { Id = 3, Name = "27 İnç Kavisli Monitör", Price = 12000, Stock = 40, CategoryId = 2, BrandId = 2, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MON27", Image = "monitor-2.webp", Description = "165Hz yenileme hızı, 1ms tepki süresi ve 2K çözünürlük ile akıcı ve sürükleyici bir görsel deneyim sağlar." },
                new Product { Id = 4, Name = "Mekanik Oyuncu Klavyesi", Price = 3000, Stock = 20, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "KEY-MECH", Image = "klavye.webp", Description = "RGB aydınlatmalı, kırmızı anahtarlı (Red Switch) ve anti-ghosting özellikli profesyonel oyuncu klavyesi." },
                new Product { Id = 5, Name = "Beyaz Oyuncu Mouse", Price = 1500, Stock = 10, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MSE-W", Image = "gaming beyaz oyuncu mouse.webp", Description = "Ultra hafif tasarımı, 12000 DPI optik sensörü ve RGB aydınlatması ile hızlı ve hassas nişan alma sağlar." },
                new Product { Id = 6, Name = "7.1 Surround Kulaklık", Price = 2500, Stock = 25, CategoryId = 1, BrandId = 2, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "HS-71", Image = "kulaklik.webp", Description = "Gürültü engelleyici mikrofonu ve 7.1 sanal surround ses teknolojisi ile düşmanlarınızın yerini anında tespit edin." },
                new Product { Id = 7, Name = "Sony PlayStation 5", Price = 30000, Stock = 15, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = false, CreateDate = new DateTime(2024, 1, 1), ProductCode = "PS5", Image = "sony-ps5.webp", Description = "4K 120Hz oyun desteği, ultra hızlı SSD ve yeni nesil dokunsal geribildirimli DualSense kumandası ile oyunun merkezine geçin." },
                new Product { Id = 8, Name = "Oyun Konsolu X", Price = 18000, Stock = 18, CategoryId = 1, BrandId = 2, IsActive = true, IsHome = false, CreateDate = new DateTime(2024, 1, 1), ProductCode = "CON-X", Image = "oykonsolu2.webp", Description = "Yeni nesil grafik gücü, geriye dönük uyumluluk ve hızlı devam etme özellikleri sunan güçlü oyun konsolu." },
                new Product { Id = 9, Name = "DualSense Kumanda", Price = 3500, Stock = 60, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "DS5", Image = "oyunkonsolaksesuar.webp", Description = "Dokunsal geri bildirim, dinamik uyarlanabilir tetikleyiciler ve dahili bir mikrofon ile daha derinlemesine bir oyun deneyimi sunar." },
                new Product { Id = 10, Name = "Monster Tulpar Notebook", Price = 42000, Stock = 45, CategoryId = 2, BrandId = 2, IsActive = true, IsHome = true, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MT-7", Image = "monstr.webp", Description = "Intel Core i9 işlemci, 32GB DDR5 RAM, 1TB SSD ve RTX 4070 ekran kartı ile sınırsız performans ve oyun keyfi." },
                new Product { Id = 11, Name = "Standart Siyah Mouse", Price = 500, Stock = 100, CategoryId = 1, BrandId = 1, IsActive = true, IsHome = false, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MS-STD", Image = "mouse.webp", Description = "Günlük kullanım için ideal, ergonomik ve tak-çalıştır özellikli sade siyah optik mouse." },
                new Product { Id = 12, Name = "Mavi Seritli Mouse", Price = 600, Stock = 80, CategoryId = 1, BrandId = 2, IsActive = true, IsHome = false, CreateDate = new DateTime(2024, 1, 1), ProductCode = "MS-B", Image = "mouse 2.webp", Description = "Şık mavi şerit tasarımı, ayarlanabilir DPI özellikleri ve rahat tutuşu ile hem ofis hem günlük kullanım için idealdir." }
            );
            
        }
    
    }
}

using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Eticaret.Data.Configurations
{
    internal class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Image).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(255);

            builder.HasData(
                new News { Id = 1, Name = "Öğrenci İndirimleri Başladı!", Description = "Seçili laptoplarda geçerli %15 öğrenci indirimini kaçırmayın.", Image = "kampanya1.jpg", IsActive = true, CreateDate = new DateTime(2026, 6, 2) },
                new News { Id = 2, Name = "Hafta Sonu Fırsatları", Description = "Tüm oyuncu ekipmanlarında net %10 indirim bu hafta sonuna özel.", Image = "kampanya2.jpg", IsActive = true, CreateDate = new DateTime(2026, 6, 2) }
            );
        }
    
    }
}

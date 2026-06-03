using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Data.Configurations
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(250);
            builder.Property(x => x.Image).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Link).HasMaxLength(255);

            builder.HasData(
                new Slider { Id = 1, Title = "Yılın En İyi Oyuncu Laptopları", Description = "Monster, Asus ve MSI'da dev indirimleri kaçırma!", Image = "slide1.jpg", Link = "/Products" },
                new Slider { Id = 2, Title = "Yeni Nesil Konsollar Geldi", Description = "PlayStation 5 ve Xbox Series X stoklarda.", Image = "slide2.jpg", Link = "/Products" },
                new Slider { Id = 3, Title = "Ekipmanını Tamamla", Description = "Kulaklık, klavye ve fare setlerinde %20 indirim.", Image = "slide3.jpg", Link = "/Products" }
            );
        }
    
    }
}

    using Eticaret.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Eticaret.Data.Configurations
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Logo).HasMaxLength(50);
            
            builder.HasData(
                new Brand { Id = 1, Name = "Apple", IsActive = true, OrderNo = 1 },
                new Brand { Id = 2, Name = "Samsung", IsActive = true, OrderNo = 2 }
            );

        }
    }
}

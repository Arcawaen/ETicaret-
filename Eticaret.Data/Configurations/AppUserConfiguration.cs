using Eticaret.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eticaret.Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(x => x.Phone).HasColumnType("varchar(20)").HasMaxLength(20);
            builder.Property(x => x.Password).IsRequired().HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(x => x.UserName).HasColumnType("varchar(50)").HasMaxLength(50);
            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    // EKSİK OLAN SATIR BURASI:
                    UserName = "admin",

                    Name = "Admin",
                    Surname = "Admin",
                    Email = "admin@gmail.com",
                    IsActive = true,
                    IsAdmin = true,
                    Password = "Admin",
                    CreateDate = new DateTime(2024, 1, 1),
                    UserGuid = Guid.Parse("00000000-0000-0000-0000-000000000001")
                }

            );


        }
    }
}

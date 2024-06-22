using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSaleRepository.Persistance.Entities;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            _ = builder.ToTable(nameof(UserEntity));
            _ = builder.Property(x => x.Fullname).IsUnicode(true).IsRequired().HasMaxLength(50);
            _ = builder.Property(x => x.Email).IsUnicode(true).IsRequired().HasMaxLength(50);
            _ = builder.Property(x => x.Phone).IsUnicode(true).IsRequired().HasMaxLength(10);
            _ = builder.Property(x => x.Address).IsUnicode(true).IsRequired().HasMaxLength(1000);
            _ = builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
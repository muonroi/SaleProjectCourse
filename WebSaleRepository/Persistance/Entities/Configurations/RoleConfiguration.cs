using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSaleRepository.Persistance.Entities;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            _ = builder.ToTable(nameof(RoleEntity));
            _ = builder.Property(x => x.Name).IsUnicode(true).IsRequired().HasMaxLength(50);
            _ = builder.Property(x => x.Description).IsUnicode(true).IsRequired().HasMaxLength(1000);
            _ = builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            _ = builder.ToTable(nameof(OrderEntity));

            _ = builder.Property(x => x.Name).IsUnicode(true).IsRequired().HasMaxLength(50);

            _ = builder.Property(x => x.Address).IsUnicode(true).IsRequired().HasMaxLength(500);

            _ = builder.Property(x => x.Email).IsRequired().HasMaxLength(50);

            _ = builder.Property(x => x.Phone).IsRequired().HasMaxLength(10);

            _ = builder.Property(x => x.Id).UseIdentityColumn();

        }
    }
}
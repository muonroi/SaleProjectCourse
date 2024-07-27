using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetailEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailEntity> builder)
        {
            _ = builder.ToTable(nameof(OrderDetailEntity));

            _ = builder.HasOne(x => x.Order)
                .WithMany(o => o.OrderDetailEntities)
                .HasForeignKey(x => x.OrderId);

            _ = builder.HasOne(x => x.Product)
                .WithMany(p => p.OrderDetailEntities)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
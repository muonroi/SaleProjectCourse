using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetailEntity>
    {
        public void Configure(EntityTypeBuilder<CartDetailEntity> builder)
        {
            _ = builder.ToTable(nameof(CartDetailEntity));

            _ = builder.HasOne(x => x.Cart)
           .WithMany(o => o.CartDetail)
           .HasForeignKey(x => x.CartId);

            _ = builder.HasOne(x => x.Product)
                .WithMany(p => p.CartDetail)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

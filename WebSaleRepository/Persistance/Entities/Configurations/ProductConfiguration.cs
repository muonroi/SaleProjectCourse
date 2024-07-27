using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            _ = builder.ToTable(nameof(ProductEntity));
            _ = builder.Property(x => x.Name).IsUnicode(true).IsRequired().HasMaxLength(50);
            _ = builder.Property(x => x.Price).IsRequired();
            _ = builder.Property(x => x.Description).IsUnicode(true).IsRequired().HasMaxLength(1000);
            _ = builder.Property(x => x.Image).IsRequired().HasMaxLength(1000);
            _ = builder.Property(x => x.Id).UseIdentityColumn();
            _ = builder.Property(x => x.CategoryId).IsRequired();
            _ = builder.HasIndex(x => x.Name)
                    .HasName("IX_ProductEntity_Name");
        }
    }
}
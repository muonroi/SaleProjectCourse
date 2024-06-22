using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSaleRepository.Persistance.Entities;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            _ = builder.ToTable(nameof(CategoryEntity));

            _ = builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            _ = builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

            _ = builder.Property(x => x.Id).UseIdentityColumn();

            _ = builder
                .HasMany(e => e.Products)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();

            _ = builder.HasIndex(x => x.Name)
                    .HasName("IX_CategoryEntity_Name");
        }
    }
}
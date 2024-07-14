using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            _ = builder.ToTable(nameof(AccountEntity));

            _ = builder.Property(e => e.Id).ValueGeneratedOnAdd();

            _ = builder.HasKey(x => new { x.Username, x.Id });

            _ = builder.Property(x => x.Username).IsRequired().HasMaxLength(50);

            _ = builder.Property(x => x.Password)
                .IsRequired().IsUnicode(false);

            _ = builder.Property(x => x.RoleId).IsRequired().HasMaxLength(50);

            _ = builder.HasOne(x => x.RoleEntity)
                .WithMany(x => x.Account)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            _ = builder
                .HasOne(e => e.UserEntity)
                .WithOne(e => e.AccountEntity)
                .HasForeignKey<UserEntity>(e => e.Username)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
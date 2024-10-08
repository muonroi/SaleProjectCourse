﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebSaleRepository.Persistance.Entities.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            _ = builder.ToTable(nameof(RoleEntity));
            _ = builder.Ignore(x => x.Id);
            _ = builder.HasKey(x => x.Name);
            _ = builder.Property(x => x.Name).IsUnicode(true).IsRequired().HasMaxLength(50);
            _ = builder.Property(x => x.Description).IsUnicode(true).IsRequired().HasMaxLength(1000);
        }
    }
}
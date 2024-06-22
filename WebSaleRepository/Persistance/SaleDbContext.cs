using Microsoft.EntityFrameworkCore;
using WebSaleRepository.Persistance.Entities;
using WebSaleRepository.Persistance.Entities.Configurations;

namespace WebSaleRepository.Persistance
{
    public class SaleDbContext : DbContext
    {
        public SaleDbContext(DbContextOptions<SaleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new AccountConfiguration());
            _ = modelBuilder.ApplyConfiguration(new UserConfiguration());
            _ = modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            _ = modelBuilder.ApplyConfiguration(new OrderConfiguration());
            _ = modelBuilder.ApplyConfiguration(new ProductConfiguration());
            _ = modelBuilder.ApplyConfiguration(new RoleConfiguration());
            _ = modelBuilder.ApplyConfiguration(new CartConfiguration());
            _ = modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            _ = modelBuilder.ApplyConfiguration(new CartDetailConfiguration());

            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductEntity> ProductEntities { get; set; }

        public DbSet<CategoryEntity> CategoryEntities { get; set; }

        public DbSet<OrderEntity> OrderEntities { get; set; }

        public DbSet<CartEntity> CartEntities { get; set; }

        public DbSet<RoleEntity> RoleEntities { get; set; }

        public DbSet<UserEntity> UserEntities { get; set; }

        public DbSet<AccountEntity> AccountEntities { get; set; }

        public DbSet<OrderDetailEntity> OrderDetailEntities { get; set; }

        public DbSet<CartDetailEntity> CartDetailEntities { get; set; }
    }
}
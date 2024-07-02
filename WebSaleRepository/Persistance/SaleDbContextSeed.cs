using Microsoft.EntityFrameworkCore;
using WebSaleRepository.Helper;
using WebSaleRepository.Persistance.Entities;

namespace WebSaleRepository.Persistance
{
    public static class SaleDbContextSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            string saltAdmin = CipherPlantextHelper.GenerateSalt();
            string saltuser = CipherPlantextHelper.GenerateSalt();

            _ = modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity
                {
                    Id = 1231,
                    Name = "Smartphone",
                    Description = "A high-performance smartphone for professionals",
                    Price = 699.99m,
                    Stock = 100,
                    Size = 6.5,
                    Color = "Black",
                    Image = "smartphone.jpg",
                    StarNumber = 4,
                    CategoryId = 21232
                },
            new ProductEntity
            {
                Id = 2232,
                Name = "Laptop",
                Description = "A high-performance laptop for professionals",
                Price = 1299.99m,
                Stock = 50,
                Size = 15.6,
                Color = "Silver",
                Image = "laptop.jpg",
                StarNumber = 5,
                CategoryId = 12321
            });
            _ = modelBuilder.Entity<CategoryEntity>().HasData(
              new CategoryEntity
              {
                  Id = 12321,
                  Name = "Electronics",
                  Description = "Electronic products category",
              },
              new CategoryEntity
              {
                  Id = 21232,
                  Name = "Clothing",
                  Description = "Clothing category",
              }
            );
            _ = modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity
                {
                    Id = 12312,
                    Name = "Admin",
                    Description = "Admin role",
                },
                new RoleEntity
                {
                    Id = 1232,
                    Name = "User",
                    Description = "User role",
                });
            _ = modelBuilder.Entity<AccountEntity>().HasData(
                new AccountEntity()
                {
                    Username = "admin",
                    Salt = saltAdmin,
                    Password = CipherPlantextHelper.Encrypt("123456789", saltAdmin),
                    RoleId = 12312
                },
                new AccountEntity()
                {
                    Username = "user",
                    Salt = saltuser,
                    Password = CipherPlantextHelper.Encrypt("123456789", saltuser),
                    RoleId = 1232
                });
            _ = modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = 231211,
                    Fullname = "admin",
                    Email = "admin@co.com",
                    Phone = "123456789",
                    Address = "1234 Admin St",
                    Username = "admin",
                },
                new UserEntity
                {
                    Id = 223123,
                    Fullname = "user",
                    Email = "user@co.com",
                    Phone = "987654321",
                    Address = "4321 User St",
                    Username = "user",
                });
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSaleRepository.Persistance;

namespace WebSaleRepository.Persistence.Migrations
{
    [DbContext(typeof(SaleDbContext))]
    [Migration("20240506141447_initDb")]
    partial class initDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.AccountEntity", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.HasIndex("RoleId");

                    b.ToTable("AccountEntity");

                    b.HasData(
                        new
                        {
                            Username = "admin",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Password = "$2b$10$gtmoef9JXZ9kiDDEt97.xOTR8SY6.gmVqKU/gFJkH69b.q2cYJUlu",
                            RoleId = 12312L,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Username = "user",
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = false,
                            IsDelete = false,
                            Password = "$2b$10$/hmQnaB.74AnywP6rRPpje8LKcav4g8Fsuvn8eKe0K50lC6/Zv9be",
                            RoleId = 1232L,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.CartEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("CartEntity");
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.CategoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("IX_CategoryEntity_Name");

                    b.ToTable("CategoryEntity");

                    b.HasData(
                        new
                        {
                            Id = 12321L,
                            CreateDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5601),
                            DeletedDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5618),
                            Description = "Electronic products category",
                            IdNo = new Guid("2e6e5b8b-3e55-479e-87c8-e5a29481b68a"),
                            IsActive = true,
                            IsDelete = false,
                            Name = "Electronics",
                            UpdateDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5616)
                        },
                        new
                        {
                            Id = 21232L,
                            CreateDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6058),
                            DeletedDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6063),
                            Description = "Clothing category",
                            IdNo = new Guid("3e2f01f7-6c69-402a-ad17-52196bf8c930"),
                            IsActive = true,
                            IsDelete = false,
                            Name = "Clothing",
                            UpdateDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6061)
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.OrderEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(true);

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderEntity");
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.ProductEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<int>("StarNumber")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .HasName("IX_ProductEntity_Name");

                    b.ToTable("ProductEntity");

                    b.HasData(
                        new
                        {
                            Id = 1231L,
                            CategoryId = 21232L,
                            Color = "Black",
                            CreateDate = new DateTime(2024, 5, 6, 21, 14, 47, 16, DateTimeKind.Local).AddTicks(3567),
                            DeletedDate = new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(3710),
                            Description = "A high-performance smartphone for professionals",
                            IdNo = new Guid("fd923159-0a62-4143-a550-9251c2d401b1"),
                            Image = "smartphone.jpg",
                            IsActive = true,
                            IsDelete = false,
                            Name = "Smartphone",
                            Price = 699.99m,
                            Size = 6.5,
                            StarNumber = 4,
                            Stock = 100,
                            UpdateDate = new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(3472)
                        },
                        new
                        {
                            Id = 2232L,
                            CategoryId = 12321L,
                            Color = "Silver",
                            CreateDate = new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6232),
                            DeletedDate = new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6238),
                            Description = "A high-performance laptop for professionals",
                            IdNo = new Guid("0cb03c32-c62d-4e5e-a8d1-da97a398662a"),
                            Image = "laptop.jpg",
                            IsActive = true,
                            IsDelete = false,
                            Name = "Laptop",
                            Price = 1299.99m,
                            Size = 15.6,
                            StarNumber = 5,
                            Stock = 50,
                            UpdateDate = new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6236)
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.RoleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleEntity");

                    b.HasData(
                        new
                        {
                            Id = 12312L,
                            CreateDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6414),
                            DeletedDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6418),
                            Description = "Admin role",
                            IdNo = new Guid("5cfc1200-9dcd-45ab-9a59-6226dec4a566"),
                            IsActive = true,
                            IsDelete = false,
                            Name = "Admin",
                            UpdateDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6417)
                        },
                        new
                        {
                            Id = 1232L,
                            CreateDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6733),
                            DeletedDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6737),
                            Description = "User role",
                            IdNo = new Guid("728a6f8f-b6c4-43a6-94d5-8f0c122fd6cb"),
                            IsActive = true,
                            IsDelete = false,
                            Name = "User",
                            UpdateDate = new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6736)
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(true);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserEntity");

                    b.HasData(
                        new
                        {
                            Id = 231211L,
                            Address = "1234 Admin St",
                            CreateDate = new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(4977),
                            DeletedDate = new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(5018),
                            Email = "admin@co.com",
                            Fullname = "admin",
                            IdNo = new Guid("2c3faee8-0f7c-4a42-8c30-d15a7480f34c"),
                            IsActive = true,
                            IsDelete = false,
                            Phone = "123456789",
                            UpdateDate = new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(5016),
                            Username = "admin"
                        },
                        new
                        {
                            Id = 223123L,
                            Address = "4321 User St",
                            CreateDate = new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6275),
                            DeletedDate = new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6280),
                            Email = "user@co.com",
                            Fullname = "user",
                            IdNo = new Guid("c866e05f-05dc-4d41-8060-138476c7d0af"),
                            IsActive = true,
                            IsDelete = false,
                            Phone = "987654321",
                            UpdateDate = new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6279),
                            Username = "user"
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.AccountEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistence.Entities.RoleEntity", "RoleEntity")
                        .WithMany("Account")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.CartEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistence.Entities.OrderEntity", "Order")
                        .WithOne("CartEntity")
                        .HasForeignKey("WebSaleRepository.Persistence.Entities.CartEntity", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.ProductEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistence.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSaleRepository.Persistence.Entities.UserEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistence.Entities.AccountEntity", "AccountEntity")
                        .WithOne("UserEntity")
                        .HasForeignKey("WebSaleRepository.Persistence.Entities.UserEntity", "Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

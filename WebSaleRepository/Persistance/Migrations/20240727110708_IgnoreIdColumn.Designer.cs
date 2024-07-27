﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebSaleRepository.Persistance;

namespace WebSaleRepository.Persistance.Migrations
{
    [DbContext(typeof(SaleDbContext))]
    [Migration("20240727110708_IgnoreIdColumn")]
    partial class IgnoreIdColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.AccountEntity", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

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

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
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
                            AccountStatus = 0,
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(7268),
                            IdNo = new Guid("35a8bef3-f63e-4ffa-8420-98b22e556b48"),
                            IsActive = true,
                            IsDelete = false,
                            Password = "$2b$10$Y.FTUIboK3Y/WbrNFWn9cev9SygSwi2zHI0f3IVnQniU5FBduApBq",
                            RoleId = 12312L,
                            Salt = "$2b$10$Y.FTUIboK3Y/WbrNFWn9ce"
                        },
                        new
                        {
                            Username = "user",
                            AccountStatus = 0,
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 736, DateTimeKind.Utc).AddTicks(990),
                            IdNo = new Guid("95118159-e214-4ec7-b1cf-c039cdb3fd0e"),
                            IsActive = true,
                            IsDelete = false,
                            Password = "$2b$10$PbLzssp81W/p7ppAork9I.obAHBPCDIUdj6Ci5Y6DYR9LoDnkXD6.",
                            RoleId = 1232L,
                            Salt = "$2b$10$PbLzssp81W/p7ppAork9I."
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.CartDetailEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartDetailEntity");
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.CartEntity", b =>
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

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdNo")
                        .HasColumnName("IdNo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnName("is_deleted")
                        .HasColumnType("bit");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("CartEntity");
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.CategoryEntity", b =>
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

                    b.Property<DateTime?>("DeletedDate")
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

                    b.Property<DateTime?>("UpdateDate")
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
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(5451),
                            Description = "Electronic products category",
                            IdNo = new Guid("4383cef4-36ed-4d7c-b2fb-acdeddc7b388"),
                            IsActive = true,
                            IsDelete = false,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 21232L,
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(5933),
                            Description = "Clothing category",
                            IdNo = new Guid("447ec622-32d4-46e7-998b-ce67e637e643"),
                            IsActive = true,
                            IsDelete = false,
                            Name = "Clothing"
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.OrderDetailEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
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

                    b.Property<DateTime?>("DeletedDate")
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

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetailEntity");
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.OrderEntity", b =>
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

                    b.Property<DateTime?>("DeletedDate")
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

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderEntity");
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.ProductEntity", b =>
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

                    b.Property<DateTime?>("DeletedDate")
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

                    b.Property<DateTime?>("UpdateDate")
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
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 652, DateTimeKind.Utc).AddTicks(4370),
                            Description = "A high-performance smartphone for professionals",
                            IdNo = new Guid("8004b4f8-88ec-44d0-879c-041a57bbbe28"),
                            Image = "smartphone.jpg",
                            IsActive = true,
                            IsDelete = false,
                            Name = "Smartphone",
                            Price = 699.99m,
                            Size = 6.5,
                            StarNumber = 4,
                            Stock = 100
                        },
                        new
                        {
                            Id = 2232L,
                            CategoryId = 12321L,
                            Color = "Silver",
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 652, DateTimeKind.Utc).AddTicks(6694),
                            Description = "A high-performance laptop for professionals",
                            IdNo = new Guid("8b8914d8-99bc-4391-84af-cb895b801b67"),
                            Image = "laptop.jpg",
                            IsActive = true,
                            IsDelete = false,
                            Name = "Laptop",
                            Price = 1299.99m,
                            Size = 15.6,
                            StarNumber = 5,
                            Stock = 50
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.RoleEntity", b =>
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

                    b.Property<DateTime?>("DeletedDate")
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

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleEntity");

                    b.HasData(
                        new
                        {
                            Id = 12312L,
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(6400),
                            Description = "Admin role",
                            IdNo = new Guid("a4a0560a-46bd-4c5c-8dda-09990488b3f8"),
                            IsActive = true,
                            IsDelete = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 1232L,
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(6754),
                            Description = "User role",
                            IdNo = new Guid("8bee9321-84eb-4e53-be01-df7799a54f7f"),
                            IsActive = true,
                            IsDelete = false,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.UserEntity", b =>
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

                    b.Property<DateTime?>("DeletedDate")
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

                    b.Property<DateTime?>("UpdateDate")
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
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 814, DateTimeKind.Utc).AddTicks(8262),
                            Email = "admin@co.com",
                            Fullname = "admin",
                            IdNo = new Guid("be940e2b-8de3-45f2-9f0a-ef4cf652694e"),
                            IsActive = true,
                            IsDelete = false,
                            Phone = "123456789",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 223123L,
                            Address = "4321 User St",
                            CreateDate = new DateTime(2024, 7, 27, 11, 7, 7, 814, DateTimeKind.Utc).AddTicks(9368),
                            Email = "user@co.com",
                            Fullname = "user",
                            IdNo = new Guid("192007d0-55d9-4977-8e1e-6dae5705eda0"),
                            IsActive = true,
                            IsDelete = false,
                            Phone = "987654321",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.AccountEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistance.Entities.RoleEntity", "RoleEntity")
                        .WithMany("Account")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.CartDetailEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistance.Entities.CartEntity", "Cart")
                        .WithMany("CartDetail")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSaleRepository.Persistance.Entities.ProductEntity", "Product")
                        .WithMany("CartDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.OrderDetailEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistance.Entities.OrderEntity", "Order")
                        .WithMany("OrderDetailEntities")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebSaleRepository.Persistance.Entities.ProductEntity", "Product")
                        .WithMany("OrderDetailEntities")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.ProductEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistance.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebSaleRepository.Persistance.Entities.UserEntity", b =>
                {
                    b.HasOne("WebSaleRepository.Persistance.Entities.AccountEntity", "AccountEntity")
                        .WithOne("UserEntity")
                        .HasForeignKey("WebSaleRepository.Persistance.Entities.UserEntity", "Username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebSaleRepository.Persistance.Migrations
{
    public partial class InitCardAndOrderDeatail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_CartEntity_OrderEntity_OrderId",
                table: "CartEntity");

            _ = migrationBuilder.DropIndex(
                name: "IX_CartEntity_OrderId",
                table: "CartEntity");

            _ = migrationBuilder.DropColumn(
                name: "CartId",
                table: "OrderEntity");

            _ = migrationBuilder.DropColumn(
                name: "Note",
                table: "OrderEntity");

            _ = migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "OrderEntity");

            _ = migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderEntity");

            _ = migrationBuilder.DropColumn(
                name: "Total",
                table: "OrderEntity");

            _ = migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CartEntity");

            _ = migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CartEntity");

            _ = migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CartEntity");

            _ = migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CartEntity",
                nullable: false,
                defaultValue: 0L);

            _ = migrationBuilder.CreateTable(
                name: "CartDetailEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNo = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    CartId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_CartDetailEntity", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_CartDetailEntity_CartEntity_CartId",
                        column: x => x.CartId,
                        principalTable: "CartEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_CartDetailEntity_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "OrderDetailEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNo = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_OrderDetailEntity", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_OrderDetailEntity_OrderEntity_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_OrderDetailEntity_ProductEntity_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$7uTbocVDTc8PGlzQ.xgD9eGP1kqli5MN9BzUVlf4NzaOC071K3MiG", "$2b$10$7uTbocVDTc8PGlzQ.xgD9e" });

            _ = migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$DLNdLEj.HadE2m39IRM5vOEBWBJFylTD5D3Y7VgpIqtwpbIw9sd7e", "$2b$10$DLNdLEj.HadE2m39IRM5vO" });

            _ = migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 196, DateTimeKind.Utc).AddTicks(609), new Guid("1df4301c-92fd-4cf3-b7b6-81af2e59a219") });

            _ = migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 196, DateTimeKind.Utc).AddTicks(1340), new Guid("be58ae78-ea0d-4f9f-bec7-7ef464bbda10") });

            _ = migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 194, DateTimeKind.Utc).AddTicks(5797), new Guid("fd8fe63c-26e2-43a5-bc08-5db7d94160d4") });

            _ = migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 194, DateTimeKind.Utc).AddTicks(8855), new Guid("14330c9d-5997-4678-aa77-f2c226dbffbc") });

            _ = migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 196, DateTimeKind.Utc).AddTicks(2582), new Guid("7a37b386-a610-4922-9b26-6243a3d443cc") });

            _ = migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 196, DateTimeKind.Utc).AddTicks(1997), new Guid("0e7d3e77-fc71-467a-9dcb-858e30d15742") });

            _ = migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 433, DateTimeKind.Utc).AddTicks(9345), new Guid("34564d21-d4b6-4bbf-bdee-d785be738434") });

            _ = migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 433, DateTimeKind.Utc).AddTicks(8084), new Guid("efa61d4e-afa3-48fe-98e7-4a717b3f7b2e") });

            _ = migrationBuilder.CreateIndex(
                name: "IX_CartDetailEntity_CartId",
                table: "CartDetailEntity",
                column: "CartId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_CartDetailEntity_ProductId",
                table: "CartDetailEntity",
                column: "ProductId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_OrderDetailEntity_OrderId",
                table: "OrderDetailEntity",
                column: "OrderId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_OrderDetailEntity_ProductId",
                table: "OrderDetailEntity",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "CartDetailEntity");

            _ = migrationBuilder.DropTable(
                name: "OrderDetailEntity");

            _ = migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartEntity");

            _ = migrationBuilder.AddColumn<long>(
                name: "CartId",
                table: "OrderEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            _ = migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "OrderEntity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            _ = migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "OrderEntity",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "OrderEntity",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "OrderEntity",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            _ = migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "CartEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            _ = migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "CartEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            _ = migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CartEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$CDLrWyeVWIxm5Wjak364NugVVW3P4VmwOw1cVZzX47iwKy0dLBp7m", "$2b$10$CDLrWyeVWIxm5Wjak364Nu" });

            _ = migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$mJTvVE5jgNwJlUr2aBGBhOLOPfdlc6x5ZcWfnLg0CU3zcX7K5E97.", "$2b$10$mJTvVE5jgNwJlUr2aBGBhO" });

            _ = migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 978, DateTimeKind.Utc).AddTicks(2290), new Guid("003beb5c-1712-4a3f-8545-4808eb6ac42a") });

            _ = migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 978, DateTimeKind.Utc).AddTicks(2856), new Guid("1d2c1766-db5a-46ff-ac1a-f25ec9867e41") });

            _ = migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 976, DateTimeKind.Utc).AddTicks(8974), new Guid("2f213058-7349-487d-a410-0ea3f1fe9bbe") });

            _ = migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 977, DateTimeKind.Utc).AddTicks(1744), new Guid("7232c781-c5ef-43e9-bf9d-e5841a3274bf") });

            _ = migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 978, DateTimeKind.Utc).AddTicks(3608), new Guid("84bcd26d-7fbc-497b-b765-30fec345f932") });

            _ = migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 978, DateTimeKind.Utc).AddTicks(3258), new Guid("75e93ca3-bdc5-4848-96ee-a7e526605776") });

            _ = migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 8, 165, DateTimeKind.Utc).AddTicks(7897), new Guid("3874b0bc-d7ca-42b3-bd94-88a5e510328d") });

            _ = migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 8, 165, DateTimeKind.Utc).AddTicks(6799), new Guid("b64b56ea-de30-48c6-99ef-1479e3391413") });

            _ = migrationBuilder.CreateIndex(
                name: "IX_CartEntity_OrderId",
                table: "CartEntity",
                column: "OrderId",
                unique: true);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_CartEntity_OrderEntity_OrderId",
                table: "CartEntity",
                column: "OrderId",
                principalTable: "OrderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

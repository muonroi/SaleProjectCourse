using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebSaleRepository.Persistence.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "CategoryEntity",
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
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_CategoryEntity", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "OrderEntity",
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
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CartId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_OrderEntity", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "RoleEntity",
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
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_RoleEntity", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "ProductEntity",
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
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Size = table.Column<double>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 1000, nullable: false),
                    StarNumber = table.Column<int>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ProductEntity", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_ProductEntity_CategoryEntity_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "CartEntity",
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
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_CartEntity", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_CartEntity_OrderEntity_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AccountEntity",
                columns: table => new
                {
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(unicode: false, nullable: false),
                    RoleId = table.Column<long>(maxLength: 50, nullable: false),
                    CreatedAt = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    is_deleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AccountEntity", x => x.Username);
                    _ = table.ForeignKey(
                        name: "FK_AccountEntity_RoleEntity_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "UserEntity",
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
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    Address = table.Column<string>(maxLength: 1000, nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_UserEntity", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_UserEntity_AccountEntity_Username",
                        column: x => x.Username,
                        principalTable: "AccountEntity",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.InsertData(
                table: "CategoryEntity",
                columns: new[] { "Id", "CreateBy", "CreateDate", "CreatedAt", "DeletedAt", "DeletedBy", "DeletedDate", "Description", "IdNo", "IsActive", "is_deleted", "Name", "UpdateBy", "UpdateDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 12321L, null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5601), null, null, null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5618), "Electronic products category", new Guid("2e6e5b8b-3e55-479e-87c8-e5a29481b68a"), true, false, "Electronics", null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5616), null },
                    { 21232L, null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6058), null, null, null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6063), "Clothing category", new Guid("3e2f01f7-6c69-402a-ad17-52196bf8c930"), true, false, "Clothing", null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6061), null }
                });

            _ = migrationBuilder.InsertData(
                table: "RoleEntity",
                columns: new[] { "Id", "CreateBy", "CreateDate", "CreatedAt", "DeletedAt", "DeletedBy", "DeletedDate", "Description", "IdNo", "IsActive", "is_deleted", "Name", "UpdateBy", "UpdateDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 12312L, null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6414), null, null, null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6418), "Admin role", new Guid("5cfc1200-9dcd-45ab-9a59-6226dec4a566"), true, false, "Admin", null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6417), null },
                    { 1232L, null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6733), null, null, null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6737), "User role", new Guid("728a6f8f-b6c4-43a6-94d5-8f0c122fd6cb"), true, false, "User", null, new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6736), null }
                });

            _ = migrationBuilder.InsertData(
                table: "AccountEntity",
                columns: new[] { "Username", "CreateBy", "CreateDate", "CreatedAt", "DeletedAt", "DeletedBy", "DeletedDate", "IsActive", "is_deleted", "Password", "RoleId", "UpdateBy", "UpdateDate", "UpdatedAt" },
                values: new object[,]
                {
                    { "admin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "$2b$10$gtmoef9JXZ9kiDDEt97.xOTR8SY6.gmVqKU/gFJkH69b.q2cYJUlu", 12312L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { "user", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "$2b$10$/hmQnaB.74AnywP6rRPpje8LKcav4g8Fsuvn8eKe0K50lC6/Zv9be", 1232L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            _ = migrationBuilder.InsertData(
                table: "ProductEntity",
                columns: new[] { "Id", "CategoryId", "Color", "CreateBy", "CreateDate", "CreatedAt", "DeletedAt", "DeletedBy", "DeletedDate", "Description", "IdNo", "Image", "IsActive", "is_deleted", "Name", "Price", "Size", "StarNumber", "Stock", "UpdateBy", "UpdateDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 2232L, 12321L, "Silver", null, new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6232), null, null, null, new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6238), "A high-performance laptop for professionals", new Guid("0cb03c32-c62d-4e5e-a8d1-da97a398662a"), "laptop.jpg", true, false, "Laptop", 1299.99m, 15.6, 5, 50, null, new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6236), null },
                    { 1231L, 21232L, "Black", null, new DateTime(2024, 5, 6, 21, 14, 47, 16, DateTimeKind.Local).AddTicks(3567), null, null, null, new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(3710), "A high-performance smartphone for professionals", new Guid("fd923159-0a62-4143-a550-9251c2d401b1"), "smartphone.jpg", true, false, "Smartphone", 699.99m, 6.5, 4, 100, null, new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(3472), null }
                });

            _ = migrationBuilder.InsertData(
                table: "UserEntity",
                columns: new[] { "Id", "Address", "CreateBy", "CreateDate", "CreatedAt", "DeletedAt", "DeletedBy", "DeletedDate", "Email", "Fullname", "IdNo", "IsActive", "is_deleted", "Phone", "UpdateBy", "UpdateDate", "UpdatedAt", "Username" },
                values: new object[] { 231211L, "1234 Admin St", null, new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(4977), null, null, null, new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(5018), "admin@co.com", "admin", new Guid("2c3faee8-0f7c-4a42-8c30-d15a7480f34c"), true, false, "123456789", null, new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(5016), null, "admin" });

            _ = migrationBuilder.InsertData(
                table: "UserEntity",
                columns: new[] { "Id", "Address", "CreateBy", "CreateDate", "CreatedAt", "DeletedAt", "DeletedBy", "DeletedDate", "Email", "Fullname", "IdNo", "IsActive", "is_deleted", "Phone", "UpdateBy", "UpdateDate", "UpdatedAt", "Username" },
                values: new object[] { 223123L, "4321 User St", null, new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6275), null, null, null, new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6280), "user@co.com", "user", new Guid("c866e05f-05dc-4d41-8060-138476c7d0af"), true, false, "987654321", null, new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6279), null, "user" });

            _ = migrationBuilder.CreateIndex(
                name: "IX_AccountEntity_RoleId",
                table: "AccountEntity",
                column: "RoleId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_CartEntity_OrderId",
                table: "CartEntity",
                column: "OrderId",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_CategoryEntity_Name",
                table: "CategoryEntity",
                column: "Name");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_CategoryId",
                table: "ProductEntity",
                column: "CategoryId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_Name",
                table: "ProductEntity",
                column: "Name");

            _ = migrationBuilder.CreateIndex(
                name: "IX_UserEntity_Username",
                table: "UserEntity",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "CartEntity");

            _ = migrationBuilder.DropTable(
                name: "ProductEntity");

            _ = migrationBuilder.DropTable(
                name: "UserEntity");

            _ = migrationBuilder.DropTable(
                name: "OrderEntity");

            _ = migrationBuilder.DropTable(
                name: "CategoryEntity");

            _ = migrationBuilder.DropTable(
                name: "AccountEntity");

            _ = migrationBuilder.DropTable(
                name: "RoleEntity");
        }
    }
}
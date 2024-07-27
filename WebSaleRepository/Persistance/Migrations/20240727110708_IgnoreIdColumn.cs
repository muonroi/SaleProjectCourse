using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSaleRepository.Persistance.Migrations
{
    public partial class IgnoreIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AccountEntity");

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "CreateDate", "IdNo", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(7268), new Guid("35a8bef3-f63e-4ffa-8420-98b22e556b48"), "$2b$10$Y.FTUIboK3Y/WbrNFWn9cev9SygSwi2zHI0f3IVnQniU5FBduApBq", "$2b$10$Y.FTUIboK3Y/WbrNFWn9ce" });

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "CreateDate", "IdNo", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 736, DateTimeKind.Utc).AddTicks(990), new Guid("95118159-e214-4ec7-b1cf-c039cdb3fd0e"), "$2b$10$PbLzssp81W/p7ppAork9I.obAHBPCDIUdj6Ci5Y6DYR9LoDnkXD6.", "$2b$10$PbLzssp81W/p7ppAork9I." });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(5451), new Guid("4383cef4-36ed-4d7c-b2fb-acdeddc7b388") });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(5933), new Guid("447ec622-32d4-46e7-998b-ce67e637e643") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 652, DateTimeKind.Utc).AddTicks(4370), new Guid("8004b4f8-88ec-44d0-879c-041a57bbbe28") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 652, DateTimeKind.Utc).AddTicks(6694), new Guid("8b8914d8-99bc-4391-84af-cb895b801b67") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(6754), new Guid("8bee9321-84eb-4e53-be01-df7799a54f7f") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 653, DateTimeKind.Utc).AddTicks(6400), new Guid("a4a0560a-46bd-4c5c-8dda-09990488b3f8") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 814, DateTimeKind.Utc).AddTicks(9368), new Guid("192007d0-55d9-4977-8e1e-6dae5705eda0") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 27, 11, 7, 7, 814, DateTimeKind.Utc).AddTicks(8262), new Guid("be940e2b-8de3-45f2-9f0a-ef4cf652694e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "AccountEntity",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "CreateDate", "IdNo", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 809, DateTimeKind.Utc).AddTicks(5734), new Guid("35f2d67d-42f1-4133-b6a3-447fcc599598"), "$2b$10$1m89N/s9Q4t42ByKCtHYkuK1xbYnJ/60r9PMGBqTcZFUD1BVhBWnu", "$2b$10$1m89N/s9Q4t42ByKCtHYku" });

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "CreateDate", "IdNo", "Password", "Salt" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 903, DateTimeKind.Utc).AddTicks(4622), new Guid("e389cf75-ec45-40f4-afbf-72897890793f"), "$2b$10$9eWyfnE.wF/dpRIaEBS7WO88ekBLFasY0N1uhrUIizXWv9vN5Jdai", "$2b$10$9eWyfnE.wF/dpRIaEBS7WO" });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 809, DateTimeKind.Utc).AddTicks(4132), new Guid("aa99ca21-1ee3-4f83-9b43-9734c6f1bd7a") });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 809, DateTimeKind.Utc).AddTicks(4666), new Guid("9bee568e-c7d6-4767-9181-7643d85b4370") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 808, DateTimeKind.Utc).AddTicks(2008), new Guid("9f278243-9e78-4c00-9c17-78fb284ac271") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 808, DateTimeKind.Utc).AddTicks(4554), new Guid("02337db2-e19d-428c-87ed-266680cf0dc6") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 809, DateTimeKind.Utc).AddTicks(5381), new Guid("9ef9a6dc-a408-4cf4-b0fc-541dc9930626") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 809, DateTimeKind.Utc).AddTicks(5058), new Guid("06b9fd79-ac58-4984-a9a0-e81ae90f4039") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 988, DateTimeKind.Utc).AddTicks(5750), new Guid("abbdccd5-feb0-4583-9eff-81794c920e62") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 988, DateTimeKind.Utc).AddTicks(4571), new Guid("85cbd085-777f-4577-b0b8-6ee9feb57ed5") });
        }
    }
}

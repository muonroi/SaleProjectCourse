using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSaleRepository.Persistance.Migrations
{
    public partial class addSalfToAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "AccountEntity",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$CDLrWyeVWIxm5Wjak364NugVVW3P4VmwOw1cVZzX47iwKy0dLBp7m", "$2b$10$CDLrWyeVWIxm5Wjak364Nu" });

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$mJTvVE5jgNwJlUr2aBGBhOLOPfdlc6x5ZcWfnLg0CU3zcX7K5E97.", "$2b$10$mJTvVE5jgNwJlUr2aBGBhO" });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 978, DateTimeKind.Utc).AddTicks(2290), new Guid("003beb5c-1712-4a3f-8545-4808eb6ac42a") });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 978, DateTimeKind.Utc).AddTicks(2856), new Guid("1d2c1766-db5a-46ff-ac1a-f25ec9867e41") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 976, DateTimeKind.Utc).AddTicks(8974), new Guid("2f213058-7349-487d-a410-0ea3f1fe9bbe") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 977, DateTimeKind.Utc).AddTicks(1744), new Guid("7232c781-c5ef-43e9-bf9d-e5841a3274bf") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 978, DateTimeKind.Utc).AddTicks(3608), new Guid("84bcd26d-7fbc-497b-b765-30fec345f932") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 7, 978, DateTimeKind.Utc).AddTicks(3258), new Guid("75e93ca3-bdc5-4848-96ee-a7e526605776") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 8, 165, DateTimeKind.Utc).AddTicks(7897), new Guid("3874b0bc-d7ca-42b3-bd94-88a5e510328d") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 18, 13, 6, 8, 165, DateTimeKind.Utc).AddTicks(6799), new Guid("b64b56ea-de30-48c6-99ef-1479e3391413") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "AccountEntity");

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                column: "Password",
                value: "$2b$10$Q9xh3qGaE8cnIXk3f.O18.ZmVfuMZ3I0UYUwvj5/Jy1l8rDotANzG");

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                column: "Password",
                value: "$2b$10$rnTppnF5HzCGzk7qo.1TBecVY3OMMhaIUBnpsMjW9AgJCesX03xYe");

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 259, DateTimeKind.Utc).AddTicks(7856), new Guid("d57b532c-d1eb-4f2c-b4e7-9e5da1a04b6f") });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 259, DateTimeKind.Utc).AddTicks(8307), new Guid("7affb931-a1f2-4286-b2c1-134b47bc047b") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 258, DateTimeKind.Utc).AddTicks(6718), new Guid("738f4a97-4a62-497c-b94f-bbdf61bf5735") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 258, DateTimeKind.Utc).AddTicks(9042), new Guid("7609a598-b662-4c6f-8142-c0db0d5bcf3c") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 259, DateTimeKind.Utc).AddTicks(8939), new Guid("1a2ccc26-98f1-4267-9657-5edf6fc78804") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 259, DateTimeKind.Utc).AddTicks(8621), new Guid("5afb2eca-8526-4eb2-9394-84fcc76297d6") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 446, DateTimeKind.Utc).AddTicks(6783), new Guid("d3422ba1-6709-4829-80ba-28085b41d093") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 446, DateTimeKind.Utc).AddTicks(5243), new Guid("433ccc87-b3ad-458b-9ef5-1b9b76655cdd") });
        }
    }
}

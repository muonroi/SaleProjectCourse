using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSaleRepository.Persistance.Migrations
{
    public partial class Changelogicdeletedatetimetimeandupdatedatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "UserEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "UserEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "RoleEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "RoleEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "ProductEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "OrderEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "OrderEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CategoryEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "CategoryEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CartEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "CartEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 259, DateTimeKind.Utc).AddTicks(7856), null, new Guid("d57b532c-d1eb-4f2c-b4e7-9e5da1a04b6f"), null });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 259, DateTimeKind.Utc).AddTicks(8307), null, new Guid("7affb931-a1f2-4286-b2c1-134b47bc047b"), null });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 258, DateTimeKind.Utc).AddTicks(6718), null, new Guid("738f4a97-4a62-497c-b94f-bbdf61bf5735"), null });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 258, DateTimeKind.Utc).AddTicks(9042), null, new Guid("7609a598-b662-4c6f-8142-c0db0d5bcf3c"), null });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 259, DateTimeKind.Utc).AddTicks(8939), null, new Guid("1a2ccc26-98f1-4267-9657-5edf6fc78804"), null });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 259, DateTimeKind.Utc).AddTicks(8621), null, new Guid("5afb2eca-8526-4eb2-9394-84fcc76297d6"), null });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 446, DateTimeKind.Utc).AddTicks(6783), null, new Guid("d3422ba1-6709-4829-80ba-28085b41d093"), null });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 12, 14, 7, 4, 446, DateTimeKind.Utc).AddTicks(5243), null, new Guid("433ccc87-b3ad-458b-9ef5-1b9b76655cdd"), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "UserEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "UserEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "RoleEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "RoleEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "ProductEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "OrderEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "OrderEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CategoryEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "CategoryEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "CartEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "CartEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                column: "Password",
                value: "$2b$10$gtmoef9JXZ9kiDDEt97.xOTR8SY6.gmVqKU/gFJkH69b.q2cYJUlu");

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                column: "Password",
                value: "$2b$10$/hmQnaB.74AnywP6rRPpje8LKcav4g8Fsuvn8eKe0K50lC6/Zv9be");

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5601), new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5618), new Guid("2e6e5b8b-3e55-479e-87c8-e5a29481b68a"), new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(5616) });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6058), new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6063), new Guid("3e2f01f7-6c69-402a-ad17-52196bf8c930"), new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6061) });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 6, 21, 14, 47, 16, DateTimeKind.Local).AddTicks(3567), new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(3710), new Guid("fd923159-0a62-4143-a550-9251c2d401b1"), new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6232), new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6238), new Guid("0cb03c32-c62d-4e5e-a8d1-da97a398662a"), new DateTime(2024, 5, 6, 21, 14, 47, 17, DateTimeKind.Local).AddTicks(6236) });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6733), new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6737), new Guid("728a6f8f-b6c4-43a6-94d5-8f0c122fd6cb"), new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6736) });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6414), new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6418), new Guid("5cfc1200-9dcd-45ab-9a59-6226dec4a566"), new DateTime(2024, 5, 6, 21, 14, 47, 18, DateTimeKind.Local).AddTicks(6417) });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6275), new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6280), new Guid("c866e05f-05dc-4d41-8060-138476c7d0af"), new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(6279) });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(4977), new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(5018), new Guid("2c3faee8-0f7c-4a42-8c30-d15a7480f34c"), new DateTime(2024, 5, 6, 21, 14, 47, 225, DateTimeKind.Local).AddTicks(5016) });
        }
    }
}

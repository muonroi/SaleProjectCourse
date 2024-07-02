using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSaleRepository.Persistance.Migrations
{
    public partial class updateIdNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "AccountEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "AccountEntity",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "AccountEntity",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "IdNo",
                table: "AccountEntity",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "IsActive", "Password", "Salt", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 49, 856, DateTimeKind.Utc).AddTicks(378), null, new Guid("40757720-a0cc-4053-a02e-cd3d30dfc986"), true, "$2b$10$pYjnWiQ5UHv9UAsa.fK01Or3a4m3FDQLvD0HWVvELHWuplN/mfW0G", "$2b$10$pYjnWiQ5UHv9UAsa.fK01O", null });

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "CreateDate", "DeletedDate", "IdNo", "IsActive", "Password", "Salt", "UpdateDate" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 49, 943, DateTimeKind.Utc).AddTicks(1738), null, new Guid("44aaee31-e18e-4f63-b7d0-b941b739a8eb"), true, "$2b$10$uyPs08kjKH78VNEELzI/OO7uqJY8UkyqXcHiAXslE6vmi2.RYJ046", "$2b$10$uyPs08kjKH78VNEELzI/OO", null });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 49, 855, DateTimeKind.Utc).AddTicks(8000), new Guid("fe36bb1e-21e3-421b-a521-0e5be66691c7") });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 49, 855, DateTimeKind.Utc).AddTicks(8730), new Guid("0efc6d68-c401-4534-be2b-90628e8054bb") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 49, 854, DateTimeKind.Utc).AddTicks(2894), new Guid("4c874a34-f81a-48c9-a2be-81898ed27c0c") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 49, 854, DateTimeKind.Utc).AddTicks(5327), new Guid("bee64f77-7d16-487c-ba3a-1bafcc7391c8") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 49, 855, DateTimeKind.Utc).AddTicks(9748), new Guid("4cdbeee7-3dff-4482-8708-0a723bd8beef") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 49, 855, DateTimeKind.Utc).AddTicks(9241), new Guid("9fa18c14-55e3-4b36-8d5d-289c750a49fd") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 50, 26, DateTimeKind.Utc).AddTicks(101), new Guid("be2dd7c7-0ee5-4e27-a87b-dcd8484a02e4") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 49, 50, 25, DateTimeKind.Utc).AddTicks(9253), new Guid("2e98e6d8-b97d-4e58-9055-2175be85399d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AccountEntity");

            migrationBuilder.DropColumn(
                name: "IdNo",
                table: "AccountEntity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "AccountEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "AccountEntity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "CreateDate", "DeletedDate", "IsActive", "Password", "Salt", "UpdateDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2b$10$854jM0glEIqpDoKSwIFheu0PyncdrDkJkD9.ChPZT2aYRTMt0bi8W", "$2b$10$854jM0glEIqpDoKSwIFheu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "CreateDate", "DeletedDate", "IsActive", "Password", "Salt", "UpdateDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "$2b$10$7nYlIxYf.rD27spLY.ZfT.l0EJH7l0g9px02IurQ6NKHgbgM15nD6", "$2b$10$7nYlIxYf.rD27spLY.ZfT.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 22, 47, 469, DateTimeKind.Utc).AddTicks(9624), new Guid("d19d48db-0f06-4110-ab41-f391eb0d6016") });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 22, 47, 470, DateTimeKind.Utc).AddTicks(311), new Guid("47f20437-e5d3-4a0b-afa9-28c9ca40c083") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 22, 47, 467, DateTimeKind.Utc).AddTicks(9466), new Guid("7b5f2fa3-9fda-42e4-9f92-dcc219ecf495") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 22, 47, 468, DateTimeKind.Utc).AddTicks(5698), new Guid("5d726684-c67c-4565-bad2-a38df3a7a5d1") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 22, 47, 470, DateTimeKind.Utc).AddTicks(1724), new Guid("8a26ee9f-e268-435b-9cea-6c102955962f") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 22, 47, 470, DateTimeKind.Utc).AddTicks(1111), new Guid("f036857a-cfa6-41b0-902d-1c37460e0368") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 22, 47, 632, DateTimeKind.Utc).AddTicks(33), new Guid("71835523-151f-49da-bcdf-c5c9209e6267") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 22, 47, 631, DateTimeKind.Utc).AddTicks(8880), new Guid("f487354e-b92e-459e-ab03-b7ffc07d48d7") });
        }
    }
}

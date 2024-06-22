using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSaleRepository.Persistance.Migrations
{
    public partial class AddAccountStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountStatus",
                table: "AccountEntity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$854jM0glEIqpDoKSwIFheu0PyncdrDkJkD9.ChPZT2aYRTMt0bi8W", "$2b$10$854jM0glEIqpDoKSwIFheu" });

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$7nYlIxYf.rD27spLY.ZfT.l0EJH7l0g9px02IurQ6NKHgbgM15nD6", "$2b$10$7nYlIxYf.rD27spLY.ZfT." });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountStatus",
                table: "AccountEntity");

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$24VtN3uYwV0FYqplSCIpb./alqTrMzeUw4b5g1CK04RMcR6.0TsIO", "$2b$10$24VtN3uYwV0FYqplSCIpb." });

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$.nc7iFe9I3eZBJniO91/K.qP.NksyIOmVyDlJT5i4iUm3.sHluuhm", "$2b$10$.nc7iFe9I3eZBJniO91/K." });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 7, 50, 149, DateTimeKind.Utc).AddTicks(8740), new Guid("1a677713-5a35-4003-9c87-dd53fc188880") });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 7, 50, 149, DateTimeKind.Utc).AddTicks(9303), new Guid("9203c24d-a6a0-4107-b5dd-e771a1fbd854") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 7, 50, 148, DateTimeKind.Utc).AddTicks(8667), new Guid("45c571f3-08a2-4615-a312-d45513144d07") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 7, 50, 149, DateTimeKind.Utc).AddTicks(774), new Guid("ffe0c8be-47ee-48b2-93db-27611b5bf1a9") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 7, 50, 149, DateTimeKind.Utc).AddTicks(9937), new Guid("66150139-bbcb-496c-8382-59e1150701a6") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 7, 50, 149, DateTimeKind.Utc).AddTicks(9652), new Guid("44569025-8126-44fb-a0ea-6c0028181a57") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 7, 50, 306, DateTimeKind.Utc).AddTicks(5364), new Guid("04dfe0a2-1c80-4ad5-b562-f31a897fbe80") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 19, 12, 7, 50, 306, DateTimeKind.Utc).AddTicks(4478), new Guid("fa93b2fc-087c-4c7f-8d9a-4218af167eb2") });
        }
    }
}

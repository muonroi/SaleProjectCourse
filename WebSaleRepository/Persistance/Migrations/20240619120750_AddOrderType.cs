using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSaleRepository.Persistance.Migrations
{
    public partial class AddOrderType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "OrderEntity",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "OrderEntity");

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$7uTbocVDTc8PGlzQ.xgD9eGP1kqli5MN9BzUVlf4NzaOC071K3MiG", "$2b$10$7uTbocVDTc8PGlzQ.xgD9e" });

            migrationBuilder.UpdateData(
                table: "AccountEntity",
                keyColumn: "Username",
                keyValue: "user",
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$DLNdLEj.HadE2m39IRM5vOEBWBJFylTD5D3Y7VgpIqtwpbIw9sd7e", "$2b$10$DLNdLEj.HadE2m39IRM5vO" });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 12321L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 196, DateTimeKind.Utc).AddTicks(609), new Guid("1df4301c-92fd-4cf3-b7b6-81af2e59a219") });

            migrationBuilder.UpdateData(
                table: "CategoryEntity",
                keyColumn: "Id",
                keyValue: 21232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 196, DateTimeKind.Utc).AddTicks(1340), new Guid("be58ae78-ea0d-4f9f-bec7-7ef464bbda10") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 1231L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 194, DateTimeKind.Utc).AddTicks(5797), new Guid("fd8fe63c-26e2-43a5-bc08-5db7d94160d4") });

            migrationBuilder.UpdateData(
                table: "ProductEntity",
                keyColumn: "Id",
                keyValue: 2232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 194, DateTimeKind.Utc).AddTicks(8855), new Guid("14330c9d-5997-4678-aa77-f2c226dbffbc") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 1232L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 196, DateTimeKind.Utc).AddTicks(2582), new Guid("7a37b386-a610-4922-9b26-6243a3d443cc") });

            migrationBuilder.UpdateData(
                table: "RoleEntity",
                keyColumn: "Id",
                keyValue: 12312L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 196, DateTimeKind.Utc).AddTicks(1997), new Guid("0e7d3e77-fc71-467a-9dcb-858e30d15742") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 223123L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 433, DateTimeKind.Utc).AddTicks(9345), new Guid("34564d21-d4b6-4bbf-bdee-d785be738434") });

            migrationBuilder.UpdateData(
                table: "UserEntity",
                keyColumn: "Id",
                keyValue: 231211L,
                columns: new[] { "CreateDate", "IdNo" },
                values: new object[] { new DateTime(2024, 6, 17, 12, 59, 9, 433, DateTimeKind.Utc).AddTicks(8084), new Guid("efa61d4e-afa3-48fe-98e7-4a717b3f7b2e") });
        }
    }
}

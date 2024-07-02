using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebSaleRepository.Persistance.Migrations
{
    public partial class editseedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.InsertData(
                table: "AccountEntity",
                columns: new[] { "CreateDate", "IdNo", "Password", "Salt", "username", "RoleId", "IsActive", "is_deleted" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 809, DateTimeKind.Utc).AddTicks(5734), new Guid("35f2d67d-42f1-4133-b6a3-447fcc599598"), "$2b$10$1m89N/s9Q4t42ByKCtHYkuK1xbYnJ/60r9PMGBqTcZFUD1BVhBWnu", "$2b$10$1m89N/s9Q4t42ByKCtHYku", "admin", "12312", true, false });

            _ = migrationBuilder.InsertData(
                table: "AccountEntity",
                columns: new[] { "CreateDate", "IdNo", "Password", "Salt", "username", "RoleId", "IsActive", "is_deleted" },
                values: new object[] { new DateTime(2024, 7, 2, 12, 52, 40, 903, DateTimeKind.Utc).AddTicks(4622), new Guid("e389cf75-ec45-40f4-afbf-72897890793f"), "$2b$10$9eWyfnE.wF/dpRIaEBS7WO88ekBLFasY0N1uhrUIizXWv9vN5Jdai", "$2b$10$9eWyfnE.wF/dpRIaEBS7WO", "user", "1232", true, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
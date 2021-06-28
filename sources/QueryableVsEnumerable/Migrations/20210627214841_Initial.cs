using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryableVsEnumerable.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { new Guid("b4a9dd01-856a-4c12-b4af-7e44638f7b55"), new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("cd181292-a92f-4e87-847a-d11001fcd325"), new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("13358824-9af8-4c4c-9f71-17ac64bf1b08"), new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("e1c56df6-89b1-4389-a00f-69d395db2f39"), new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

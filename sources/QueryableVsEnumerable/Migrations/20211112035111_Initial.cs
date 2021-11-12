using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DustInTheWind.QueryableVsEnumerable.Migrations
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
                    { new Guid("96464eaf-47f5-4bfd-a182-36a30403cb4d"), new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c4072f7-1365-4057-821f-69b0018a25d4"), new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33f0e58b-bc15-4c2a-b65b-1b693d1e2330"), new DateTime(2021, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("182b2d60-9582-448d-83e7-22e98c818073"), new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3ab2d9f9-21ae-40d7-baae-4a75d02ff183"), new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("61cb19f9-0985-4f01-a624-3dd4aed4ddbd"), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5e78eb8c-7a77-4e50-9e79-3e782fd9e4d9"), new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

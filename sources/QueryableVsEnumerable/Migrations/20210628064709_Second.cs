using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryableVsEnumerable.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("13358824-9af8-4c4c-9f71-17ac64bf1b08"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b4a9dd01-856a-4c12-b4af-7e44638f7b55"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("cd181292-a92f-4e87-847a-d11001fcd325"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e1c56df6-89b1-4389-a00f-69d395db2f39"));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date" },
                values: new object[,]
                {
                    { new Guid("d5ec2305-3db5-4864-ba7d-bdc2c3da0d88"), new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("80fd270c-de5f-4deb-90f9-ac76d28398a0"), new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("0469137b-ae56-40d3-9488-596a7a9e188d"), new DateTime(2021, 6, 21, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("6e63fd29-c5f9-4ec4-9f3f-57838454425b"), new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("b12b46ed-f1e8-4942-b525-87465d56084f"), new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("2bedf5b3-05a9-4d43-92db-0bbad201d1de"), new DateTime(2021, 6, 27, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("cbdafc5d-257f-4eec-8177-af56175bf26f"), new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("0469137b-ae56-40d3-9488-596a7a9e188d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("2bedf5b3-05a9-4d43-92db-0bbad201d1de"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("6e63fd29-c5f9-4ec4-9f3f-57838454425b"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("80fd270c-de5f-4deb-90f9-ac76d28398a0"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("b12b46ed-f1e8-4942-b525-87465d56084f"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("cbdafc5d-257f-4eec-8177-af56175bf26f"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d5ec2305-3db5-4864-ba7d-bdc2c3da0d88"));

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
    }
}

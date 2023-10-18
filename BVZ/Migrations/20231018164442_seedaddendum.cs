using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class seedaddendum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Guides",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000099"), "Nisse" });

            migrationBuilder.InsertData(
                table: "AnimalCompetences",
                columns: new[] { "Id", "AnimalId", "GuideId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-1000-000000000030"), new Guid("00000000-0000-0000-0000-200000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000031"), new Guid("00000000-0000-0000-0000-020000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000032"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000000000099") }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Description", "GuideId", "NrOfParticipants", "TourCompleted", "TourDate", "TourName", "ZooDayId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-444400000000"), "Se havets vidunder!", new Guid("00000000-0000-0000-0000-000000000099"), 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aqua-expedition", new Guid("00000000-0000-0000-0000-123000000000") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000030"));

            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000031"));

            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444400000000"));

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"));
        }
    }
}

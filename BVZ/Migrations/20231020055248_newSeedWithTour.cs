using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class newSeedWithTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000032"));

            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000046"));

            migrationBuilder.InsertData(
                table: "AnimalCompetences",
                columns: new[] { "Id", "AnimalId", "GuideId" },
                values: new object[] { new Guid("00000000-0000-0000-1000-000002050046"), new Guid("00000000-0000-0000-0000-001000000000"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.InsertData(
                table: "Guides",
                columns: new[] { "Id", "IsUnavailable", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000700100099"), false, "Ronny" });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444400000000"),
                column: "Description",
                value: "Se havets vidunder.. Obs, det sker på egen risk då redan åtskilliga besökare skadats av dom livsfarliga elektriska undervattensbestarna.");

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(426));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.InsertData(
                table: "AnimalCompetences",
                columns: new[] { "Id", "AnimalId", "GuideId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0040-1030-000000000031"), new Guid("00000000-0000-0000-0000-030000000000"), new Guid("00000000-0000-0000-0000-000700100099") },
                    { new Guid("00000000-1002-0000-1040-000000000030"), new Guid("00000000-0000-0000-0000-001000000000"), new Guid("00000000-0000-0000-0000-000700100099") },
                    { new Guid("05043020-0000-0000-1000-000000000032"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000700100099") }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Description", "GuideId", "TourCompleted", "TourName" },
                values: new object[] { new Guid("00000000-0000-0000-0060-444405030000"), "En rasslande upplevelse bland trädens toppar. Följ med in i vindlande raviner och höga alptoppar, på jakt efter den gäckande örnen. Har vi tur får vi se, eller höra, den fåniga norska blåa papegojan. Sedan, en liten överraskning..", new Guid("00000000-0000-0000-0000-000700100099"), false, "Flygande vidunder och en liten överraskning" });

            migrationBuilder.InsertData(
                table: "ZooTours",
                columns: new[] { "Id", "DateOfTour", "IsMorningTour", "NrOfParticipants", "TourID", "ZooDayId" },
                values: new object[,]
                {
                    { new Guid("00000000-0023-5070-0000-999070000600"), new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(617), false, 0, new Guid("00000000-0000-0000-0060-444405030000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000080-9090-0909-0000-999070000000"), new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(591), true, 0, new Guid("00000000-0000-0000-0060-444405030000"), new Guid("00000000-0000-0000-0000-123000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000002050046"));

            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0040-1030-000000000031"));

            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1002-0000-1040-000000000030"));

            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("05043020-0000-0000-1000-000000000032"));

            migrationBuilder.DeleteData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"));

            migrationBuilder.DeleteData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"));

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0060-444405030000"));

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000700100099"));

            migrationBuilder.InsertData(
                table: "AnimalCompetences",
                columns: new[] { "Id", "AnimalId", "GuideId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-1000-000000000032"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000046"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000000000009") }
                });

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444400000000"),
                column: "Description",
                value: "Se havets vidunder!");

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 20, 7, 1, 4, 949, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 1, 4, 949, DateTimeKind.Local).AddTicks(4103));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 1, 4, 949, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 1, 4, 949, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 1, 4, 949, DateTimeKind.Local).AddTicks(4125));
        }
    }
}

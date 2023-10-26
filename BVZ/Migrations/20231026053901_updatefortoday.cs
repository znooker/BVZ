using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class updatefortoday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-001000000000"),
                column: "AnimalName",
                value: "Snabbfot");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-010000000000"),
                column: "AnimalName",
                value: "Snuttis");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-020000000000"),
                column: "AnimalName",
                value: "Taggis");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-030000000000"),
                column: "AnimalName",
                value: "Nisse");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-100000000000"),
                column: "AnimalName",
                value: "Herr Kvick");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-200000000000"),
                column: "AnimalName",
                value: "Shock");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-300000000000"),
                column: "AnimalName",
                value: "Örnie");

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00002040-8888-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999030000900"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00005000-0000-0300-0000-999000076000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2388));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00700500-2340-0000-0000-999002000000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 26, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0350-123000964000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 26, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 26, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 26, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 26, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-994073020600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 26, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 26, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0090-192070300400"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00240600-0800-0200-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11241100-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303450-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303451-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 7, 39, 1, 63, DateTimeKind.Local).AddTicks(2252));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-001000000000"),
                column: "AnimalName",
                value: "Ozelot");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-010000000000"),
                column: "AnimalName",
                value: "Okapi");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-020000000000"),
                column: "AnimalName",
                value: "Moray Eel");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-030000000000"),
                column: "AnimalName",
                value: "Norwegian Blue Parrot");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-100000000000"),
                column: "AnimalName",
                value: "Cheetah");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-200000000000"),
                column: "AnimalName",
                value: "Electric Eel");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-300000000000"),
                column: "AnimalName",
                value: "Bald Eagle");

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00002040-8888-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999030000900"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00005000-0000-0300-0000-999000076000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00700500-2340-0000-0000-999002000000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 25, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0350-123000964000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-994073020600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7651));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 25, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0090-192070300400"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00240600-0800-0200-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11241100-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303450-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303451-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 20, 14, 28, 916, DateTimeKind.Local).AddTicks(7608));
        }
    }
}

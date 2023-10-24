using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DateTime currentDate = DateTime.Now;
            DateTime yesterDay = currentDate.AddDays(-1);

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "VisitDate",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00002040-8888-0000-0000-999000000000"),
                column: "VisitDate",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "TicketDate",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999030000900"),
                column: "TicketDate",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00005000-0000-0300-0000-999000076000"),
                column: "TicketDate",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00700500-2340-0000-0000-999002000000"),
                column: "TicketDate",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0350-123000964000"),
                column: "TodaysDate",
                value: currentDate);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: currentDate);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: currentDate);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: currentDate);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: currentDate);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-994073020600"),
                column: "DateOfTour",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"),
                column: "DateOfTour",
                currentDate);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"),
                column: "DateOfTour",
                currentDate);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0090-192070300400"),
                column: "DateOfTour",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00240600-0800-0200-0000-999000000000"),
                column: "DateOfTour",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11241100-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303450-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: yesterDay);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303451-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: yesterDay);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00002040-8888-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999030000900"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00005000-0000-0300-0000-999000076000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3154));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00700500-2340-0000-0000-999002000000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0350-123000964000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2897));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-994073020600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2935));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0090-192070300400"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00240600-0800-0200-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2965));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11241100-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303450-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303451-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3004));
        }
    }
}

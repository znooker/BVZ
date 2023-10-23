using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class SoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Visitors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Tours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Guides",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Animals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-001000000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-010000000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-020000000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-030000000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-100000000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-200000000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-300000000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000700100099"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00002040-8888-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9528));

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444000000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444400000000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0060-444405030000"),
                column: "IsArchived",
                value: false);

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                columns: new[] { "IsArchived", "TicketDate" },
                values: new object[] { false, new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9478) });

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999030000900"),
                columns: new[] { "IsArchived", "TicketDate" },
                values: new object[] { false, new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9543) });

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00005000-0000-0300-0000-999000076000"),
                columns: new[] { "IsArchived", "TicketDate" },
                values: new object[] { false, new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00700500-2340-0000-0000-999002000000"),
                columns: new[] { "IsArchived", "TicketDate" },
                values: new object[] { false, new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9514) });

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0350-123000964000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-994073020600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0090-192070300400"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00240600-0800-0200-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11241100-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9402));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303450-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9415));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303451-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 22, 13, 9, 29, 65, DateTimeKind.Local).AddTicks(9429));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Guides");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Animals");

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

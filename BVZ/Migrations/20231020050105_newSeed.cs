using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class newSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfParticipants",
                table: "Tours");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NrOfParticipants",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444000000000"),
                column: "NrOfParticipants",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444400000000"),
                column: "NrOfParticipants",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}

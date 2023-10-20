using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedVisitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 20, 11, 0, 49, 505, DateTimeKind.Local).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 11, 0, 49, 505, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 11, 0, 49, 505, DateTimeKind.Local).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 11, 0, 49, 505, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 11, 0, 49, 505, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 11, 0, 49, 505, DateTimeKind.Local).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 11, 0, 49, 505, DateTimeKind.Local).AddTicks(5403));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Visitors");

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

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 20, 7, 52, 48, 457, DateTimeKind.Local).AddTicks(591));
        }
    }
}

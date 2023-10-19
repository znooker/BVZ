using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ZooTours",
                columns: new[] { "Id", "DateOfTour", "IsMorningTour", "TourID", "ZooDayId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-999000000000"), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), true, new Guid("00000000-0000-0000-0000-444000000000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000000-0000-0000-0000-999070000000"), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), true, new Guid("00000000-0000-0000-0000-444400000000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000000-0000-0000-0000-999070000600"), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), false, new Guid("00000000-0000-0000-0000-444400000000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000000-0000-1000-0000-899000000000"), new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local), false, new Guid("00000000-0000-0000-0000-444000000000"), new Guid("00000000-0000-0000-0000-123000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"));

            migrationBuilder.DeleteData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"));

            migrationBuilder.DeleteData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"));

            migrationBuilder.DeleteData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"));
        }
    }
}

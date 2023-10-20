using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class updateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitorCode",
                table: "Visitors");

            migrationBuilder.AddColumn<int>(
                name: "NrOfParticipants",
                table: "ZooTours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "VisitDate",
                table: "TourParticipants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "NrOfParticipants",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "NrOfParticipants",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "NrOfParticipants",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "NrOfParticipants",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrOfParticipants",
                table: "ZooTours");

            migrationBuilder.DropColumn(
                name: "VisitDate",
                table: "TourParticipants");

            migrationBuilder.AddColumn<string>(
                name: "VisitorCode",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

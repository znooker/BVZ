using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalCompetences_Animals_AnimalId",
                table: "AnimalCompetences");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVisits_Animals_AnimalId",
                table: "AnimalVisits");

            migrationBuilder.DropIndex(
                name: "IX_AnimalCompetences_AnimalId",
                table: "AnimalCompetences");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "AnimalCompetences");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalId",
                table: "AnimalVisits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "AnimalArchetype",
                table: "AnimalVisits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnimalArchetype",
                table: "AnimalCompetences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000030"),
                column: "AnimalArchetype",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000031"),
                column: "AnimalArchetype",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000044"),
                column: "AnimalArchetype",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000045"),
                column: "AnimalArchetype",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000002050046"),
                column: "AnimalArchetype",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0040-1030-000000000031"),
                column: "AnimalArchetype",
                value: 6);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1002-0000-1040-000000000030"),
                column: "AnimalArchetype",
                value: 5);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("05043020-0000-0000-1000-000000000032"),
                column: "AnimalArchetype",
                value: 2);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVisits_Animals_AnimalId",
                table: "AnimalVisits",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalVisits_Animals_AnimalId",
                table: "AnimalVisits");

            migrationBuilder.DropColumn(
                name: "AnimalArchetype",
                table: "AnimalVisits");

            migrationBuilder.DropColumn(
                name: "AnimalArchetype",
                table: "AnimalCompetences");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnimalId",
                table: "AnimalVisits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AnimalId",
                table: "AnimalCompetences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000030"),
                column: "AnimalId",
                value: new Guid("00000000-0000-0000-0000-200000000000"));

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000031"),
                column: "AnimalId",
                value: new Guid("00000000-0000-0000-0000-020000000000"));

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000044"),
                column: "AnimalId",
                value: new Guid("00000000-0000-0000-0000-100000000000"));

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000045"),
                column: "AnimalId",
                value: new Guid("00000000-0000-0000-0000-010000000000"));

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000002050046"),
                column: "AnimalId",
                value: new Guid("00000000-0000-0000-0000-001000000000"));

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0040-1030-000000000031"),
                column: "AnimalId",
                value: new Guid("00000000-0000-0000-0000-030000000000"));

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1002-0000-1040-000000000030"),
                column: "AnimalId",
                value: new Guid("00000000-0000-0000-0000-001000000000"));

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("05043020-0000-0000-1000-000000000032"),
                column: "AnimalId",
                value: new Guid("00000000-0000-0000-0000-300000000000"));

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "TourParticipants",
                keyColumn: "Id",
                keyValue: new Guid("00002040-8888-0000-0000-999000000000"),
                column: "VisitDate",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999030000900"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00005000-0000-0300-0000-999000076000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: new Guid("00700500-2340-0000-0000-999002000000"),
                column: "TicketDate",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(3056));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 24, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0350-123000964000"),
                column: "TodaysDate",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2784));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-994073020600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0023-5070-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2905));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 24, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00000080-9090-0909-0090-192070300400"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("00240600-0800-0200-0000-999000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2934));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11241100-0000-1000-0000-899000000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303450-0000-0000-0000-999070000000"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "ZooTours",
                keyColumn: "Id",
                keyValue: new Guid("11303451-0000-0000-0000-999070000600"),
                column: "DateOfTour",
                value: new DateTime(2023, 10, 23, 7, 48, 52, 41, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.CreateIndex(
                name: "IX_AnimalCompetences_AnimalId",
                table: "AnimalCompetences",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalCompetences_Animals_AnimalId",
                table: "AnimalCompetences",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalVisits_Animals_AnimalId",
                table: "AnimalVisits",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

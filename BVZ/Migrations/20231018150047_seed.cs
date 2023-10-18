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
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000100"));

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"));

            migrationBuilder.DropColumn(
                name: "Cheetah_Name",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "NorwegianBlueParrot_Name",
                table: "Animals");

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000045"),
                columns: new[] { "AnimalId", "GuideId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-010000000000"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalName", "AnimalType", "DailyVisits", "Specie", "Speed" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-001000000000"), "Ozelot", "Ozelot", 0, 0, 30.0 },
                    { new Guid("00000000-0000-0000-0000-010000000000"), "Okapi", "Okapi", 0, 0, 10.0 }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalName", "AnimalType", "DailyVisits", "DivingDepth", "Specie" },
                values: new object[] { new Guid("00000000-0000-0000-0000-020000000000"), "Moray Eel", "MorayEel", 0, 79.0, 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalName", "AnimalType", "CanSpeak", "DailyVisits", "FeatherColor", "MaxAltitude", "Specie" },
                values: new object[] { new Guid("00000000-0000-0000-0000-030000000000"), "Norwegian Blue Parrot", "NorwegianBlueParrot", true, 0, "Green", 0.0, 2 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalName", "AnimalType", "DailyVisits", "Specie", "Speed" },
                values: new object[] { new Guid("00000000-0000-0000-0000-100000000000"), "Cheetah", "Cheetah", 0, 0, 70.0 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalName", "AnimalType", "DailyVisits", "DivingDepth", "Specie" },
                values: new object[] { new Guid("00000000-0000-0000-0000-200000000000"), "Electric Eel", "ElectricEel", 0, 120.0, 1 });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalName", "AnimalType", "DailyVisits", "MaxAltitude", "Specie", "Wingspan" },
                values: new object[] { new Guid("00000000-0000-0000-0000-300000000000"), "Bald Eagle", "BaldEagle", 0, 0.0, 2, 1.3999999999999999 });

            migrationBuilder.InsertData(
                table: "Guides",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Hjalmar" },
                    { new Guid("00000000-0000-0000-0000-000000000099"), "Nisse" }
                });

            migrationBuilder.InsertData(
                table: "ZooDays",
                columns: new[] { "Id", "Archived", "TodaysDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-123000000000"), false, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "AnimalCompetences",
                columns: new[] { "Id", "AnimalId", "GuideId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-1000-000000000030"), new Guid("00000000-0000-0000-0000-000000000100"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000031"), new Guid("00000000-0000-0000-0000-020000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000032"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000044"), new Guid("00000000-0000-0000-0000-100000000000"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-1000-000000000046"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000000000009") }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Description", "GuideId", "NrOfParticipants", "TourCompleted", "TourDate", "TourName", "ZooDayId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-444000000000"), "Se djungelns mäktigaste djur..", new Guid("00000000-0000-0000-0000-000000000009"), 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djungel-Expeditionen", new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000000-0000-0000-0000-444400000000"), "Se havets vidunder!", new Guid("00000000-0000-0000-0000-000000000099"), 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aqua-expedition", new Guid("00000000-0000-0000-0000-123000000000") }
                });
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
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000044"));

            migrationBuilder.DeleteData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000046"));

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-001000000000"));

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-010000000000"));

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-030000000000"));

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-200000000000"));

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444000000000"));

            migrationBuilder.DeleteData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-444400000000"));

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-020000000000"));

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-100000000000"));

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-300000000000"));

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000099"));

            migrationBuilder.DeleteData(
                table: "ZooDays",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-123000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Cheetah_Name",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NorwegianBlueParrot_Name",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AnimalCompetences",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1000-000000000045"),
                columns: new[] { "AnimalId", "GuideId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000100"), new Guid("00000000-0000-0000-0000-000000000045") });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalName", "AnimalType", "DailyVisits", "Cheetah_Name", "Specie", "Speed" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000100"), "Geopard", "Cheetah", 0, "Karl", 0, 70.0 });

            migrationBuilder.InsertData(
                table: "Guides",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000045"), "Hjalmar" });
        }
    }
}

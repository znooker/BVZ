using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specie = table.Column<int>(type: "int", nullable: false),
                    DailyVisits = table.Column<int>(type: "int", nullable: false),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAltitude = table.Column<double>(type: "float", nullable: true),
                    Wingspan = table.Column<double>(type: "float", nullable: true),
                    FeatherColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanSpeak = table.Column<bool>(type: "bit", nullable: true),
                    Speed = table.Column<double>(type: "float", nullable: true),
                    DivingDepth = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUnavailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZooDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TodaysDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalCompetences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalCompetences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalCompetences_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalCompetences_Guides_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrOfParticipants = table.Column<int>(type: "int", nullable: false),
                    TourCompleted = table.Column<bool>(type: "bit", nullable: false),
                    GuideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tours_Guides_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalVisits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZooDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalVisits_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalVisits_ZooDays_ZooDayId",
                        column: x => x.ZooDayId,
                        principalTable: "ZooDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourParticipants_Tours_TourID",
                        column: x => x.TourID,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourParticipants_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZooTours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZooDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfTour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMorningTour = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooTours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZooTours_Tours_TourID",
                        column: x => x.TourID,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZooTours_ZooDays_ZooDayId",
                        column: x => x.ZooDayId,
                        principalTable: "ZooDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "IsUnavailable", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000009"), false, "Hjalmar" },
                    { new Guid("00000000-0000-0000-0000-000000000099"), false, "Nisse" }
                });

            migrationBuilder.InsertData(
                table: "ZooDays",
                columns: new[] { "Id", "Archived", "TodaysDate" },
                values: new object[] { new Guid("00000000-0000-0000-0000-123000000000"), false, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "AnimalCompetences",
                columns: new[] { "Id", "AnimalId", "GuideId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-1000-000000000030"), new Guid("00000000-0000-0000-0000-200000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000031"), new Guid("00000000-0000-0000-0000-020000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000032"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000044"), new Guid("00000000-0000-0000-0000-100000000000"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-1000-000000000045"), new Guid("00000000-0000-0000-0000-010000000000"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-1000-000000000046"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000000000009") }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Description", "GuideId", "NrOfParticipants", "TourCompleted", "TourName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-444000000000"), "Se djungelns mäktigaste djur..", new Guid("00000000-0000-0000-0000-000000000009"), 0, false, "Djungel-Expeditionen" },
                    { new Guid("00000000-0000-0000-0000-444400000000"), "Se havets vidunder!", new Guid("00000000-0000-0000-0000-000000000099"), 0, false, "Aqua-expedition" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalCompetences_AnimalId",
                table: "AnimalCompetences",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalCompetences_GuideId",
                table: "AnimalCompetences",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalVisits_AnimalId",
                table: "AnimalVisits",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalVisits_ZooDayId",
                table: "AnimalVisits",
                column: "ZooDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TourParticipants_TourID",
                table: "TourParticipants",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_TourParticipants_VisitorId",
                table: "TourParticipants",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_GuideId",
                table: "Tours",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_ZooTours_TourID",
                table: "ZooTours",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_ZooTours_ZooDayId",
                table: "ZooTours",
                column: "ZooDayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalCompetences");

            migrationBuilder.DropTable(
                name: "AnimalVisits");

            migrationBuilder.DropTable(
                name: "TourParticipants");

            migrationBuilder.DropTable(
                name: "ZooTours");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "ZooDays");

            migrationBuilder.DropTable(
                name: "Guides");
        }
    }
}

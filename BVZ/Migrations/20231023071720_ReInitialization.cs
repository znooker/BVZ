using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class ReInitialization : Migration
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
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specie = table.Column<int>(type: "int", nullable: false),
                    DailyVisits = table.Column<int>(type: "int", nullable: false),
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
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "AnimalVisits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "TourParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TourSession = table.Column<int>(type: "int", nullable: false)
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
                    IsMorningTour = table.Column<bool>(type: "bit", nullable: false),
                    NrOfParticipants = table.Column<int>(type: "int", nullable: false)
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
                    { new Guid("00000000-0000-0000-0000-000000000099"), false, "Nisse" },
                    { new Guid("00000000-0000-0000-0000-000700100099"), false, "Ronny" }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "Id", "Alias", "TicketDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-999000000000"), "Mikael", new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3049) },
                    { new Guid("00000000-0000-0000-0000-999030000900"), "Raul", new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3139) },
                    { new Guid("00005000-0000-0300-0000-999000076000"), "Lena", new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3154) },
                    { new Guid("00700500-2340-0000-0000-999002000000"), "Hans", new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3084) }
                });

            migrationBuilder.InsertData(
                table: "ZooDays",
                columns: new[] { "Id", "Archived", "TodaysDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-123000000000"), false, new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2813) },
                    { new Guid("00000000-0000-0000-0350-123000964000"), false, new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2951) }
                });

            migrationBuilder.InsertData(
                table: "AnimalCompetences",
                columns: new[] { "Id", "AnimalId", "GuideId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-1000-000000000030"), new Guid("00000000-0000-0000-0000-200000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000031"), new Guid("00000000-0000-0000-0000-020000000000"), new Guid("00000000-0000-0000-0000-000000000099") },
                    { new Guid("00000000-0000-0000-1000-000000000044"), new Guid("00000000-0000-0000-0000-100000000000"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-1000-000000000045"), new Guid("00000000-0000-0000-0000-010000000000"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-1000-000002050046"), new Guid("00000000-0000-0000-0000-001000000000"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0040-1030-000000000031"), new Guid("00000000-0000-0000-0000-030000000000"), new Guid("00000000-0000-0000-0000-000700100099") },
                    { new Guid("00000000-1002-0000-1040-000000000030"), new Guid("00000000-0000-0000-0000-001000000000"), new Guid("00000000-0000-0000-0000-000700100099") },
                    { new Guid("05043020-0000-0000-1000-000000000032"), new Guid("00000000-0000-0000-0000-300000000000"), new Guid("00000000-0000-0000-0000-000700100099") }
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Description", "GuideId", "TourCompleted", "TourName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-444000000000"), "Se djungelns mäktigaste djur..", new Guid("00000000-0000-0000-0000-000000000009"), false, "Djungel-Expeditionen" },
                    { new Guid("00000000-0000-0000-0000-444400000000"), "Se havets vidunder.. Obs, det sker på egen risk då redan åtskilliga besökare skadats av dom livsfarliga elektriska undervattensbestarna.", new Guid("00000000-0000-0000-0000-000000000099"), false, "Aqua-expedition" },
                    { new Guid("00000000-0000-0000-0060-444405030000"), "En rasslande upplevelse bland trädens toppar. Följ med in i vindlande raviner och höga alptoppar, på jakt efter den gäckande örnen. Har vi tur får vi se, eller höra, den fåniga norska blåa papegojan. Sedan, en liten överraskning..", new Guid("00000000-0000-0000-0000-000700100099"), false, "Flygande vidunder och en liten överraskning" }
                });

            migrationBuilder.InsertData(
                table: "TourParticipants",
                columns: new[] { "Id", "TourID", "TourSession", "VisitDate", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-999000000000"), new Guid("00000000-0000-0000-0060-444405030000"), 1, new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3065), new Guid("00000000-0000-0000-0000-999000000000") },
                    { new Guid("00002040-8888-0000-0000-999000000000"), new Guid("00000000-0000-0000-0060-444405030000"), 1, new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3096), new Guid("00700500-2340-0000-0000-999002000000") }
                });

            migrationBuilder.InsertData(
                table: "ZooTours",
                columns: new[] { "Id", "DateOfTour", "IsMorningTour", "NrOfParticipants", "TourID", "ZooDayId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-999000000000"), new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2846), true, 0, new Guid("00000000-0000-0000-0000-444000000000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000000-0000-0000-0000-999070000000"), new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2884), true, 0, new Guid("00000000-0000-0000-0000-444400000000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000000-0000-0000-0000-999070000600"), new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2897), false, 0, new Guid("00000000-0000-0000-0000-444400000000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000000-0000-1000-0000-899000000000"), new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2861), false, 0, new Guid("00000000-0000-0000-0000-444000000000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000000-0023-5070-0000-994073020600"), new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3029), false, 2, new Guid("00000000-0000-0000-0060-444405030000"), new Guid("00000000-0000-0000-0350-123000964000") },
                    { new Guid("00000000-0023-5070-0000-999070000600"), new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2935), false, 0, new Guid("00000000-0000-0000-0060-444405030000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000080-9090-0909-0000-999070000000"), new DateTime(2023, 10, 23, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2920), true, 0, new Guid("00000000-0000-0000-0060-444405030000"), new Guid("00000000-0000-0000-0000-123000000000") },
                    { new Guid("00000080-9090-0909-0090-192070300400"), new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3017), true, 0, new Guid("00000000-0000-0000-0060-444405030000"), new Guid("00000000-0000-0000-0350-123000964000") },
                    { new Guid("00240600-0800-0200-0000-999000000000"), new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2965), true, 0, new Guid("00000000-0000-0000-0000-444000000000"), new Guid("00000000-0000-0000-0350-123000964000") },
                    { new Guid("11241100-0000-1000-0000-899000000000"), new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2978), false, 0, new Guid("00000000-0000-0000-0000-444000000000"), new Guid("00000000-0000-0000-0350-123000964000") },
                    { new Guid("11303450-0000-0000-0000-999070000000"), new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(2990), true, 0, new Guid("00000000-0000-0000-0000-444400000000"), new Guid("00000000-0000-0000-0350-123000964000") },
                    { new Guid("11303451-0000-0000-0000-999070000600"), new DateTime(2023, 10, 22, 9, 17, 20, 30, DateTimeKind.Local).AddTicks(3004), false, 0, new Guid("00000000-0000-0000-0000-444400000000"), new Guid("00000000-0000-0000-0350-123000964000") }
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

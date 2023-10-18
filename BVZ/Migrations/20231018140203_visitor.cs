using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class visitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Archieved",
                table: "ZooDays",
                newName: "Archived");

            migrationBuilder.AddColumn<double>(
                name: "DivingDepth",
                table: "Animals",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrOfParticipants = table.Column<int>(type: "int", nullable: false),
                    TourCompleted = table.Column<bool>(type: "bit", nullable: false),
                    TourDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZooDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tour_Guides_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tour_ZooDays_ZooDayId",
                        column: x => x.ZooDayId,
                        principalTable: "ZooDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourParticipant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TourID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourParticipant_Tour_TourID",
                        column: x => x.TourID,
                        principalTable: "Tour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourParticipant_Visitor_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tour_GuideId",
                table: "Tour",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_ZooDayId",
                table: "Tour",
                column: "ZooDayId");

            migrationBuilder.CreateIndex(
                name: "IX_TourParticipant_TourID",
                table: "TourParticipant",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_TourParticipant_VisitorId",
                table: "TourParticipant",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourParticipant");

            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "Visitor");

            migrationBuilder.DropColumn(
                name: "DivingDepth",
                table: "Animals");

            migrationBuilder.RenameColumn(
                name: "Archived",
                table: "ZooDays",
                newName: "Archieved");
        }
    }
}

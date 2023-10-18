using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BVZ.Migrations
{
    /// <inheritdoc />
    public partial class draftagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Guides_GuideId",
                table: "Tour");

            migrationBuilder.DropForeignKey(
                name: "FK_Tour_ZooDays_ZooDayId",
                table: "Tour");

            migrationBuilder.DropForeignKey(
                name: "FK_TourParticipant_Tour_TourID",
                table: "TourParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_TourParticipant_Visitor_VisitorId",
                table: "TourParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visitor",
                table: "Visitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourParticipant",
                table: "TourParticipant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tour",
                table: "Tour");

            migrationBuilder.RenameTable(
                name: "Visitor",
                newName: "Visitors");

            migrationBuilder.RenameTable(
                name: "TourParticipant",
                newName: "TourParticipants");

            migrationBuilder.RenameTable(
                name: "Tour",
                newName: "Tours");

            migrationBuilder.RenameIndex(
                name: "IX_TourParticipant_VisitorId",
                table: "TourParticipants",
                newName: "IX_TourParticipants_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_TourParticipant_TourID",
                table: "TourParticipants",
                newName: "IX_TourParticipants_TourID");

            migrationBuilder.RenameIndex(
                name: "IX_Tour_ZooDayId",
                table: "Tours",
                newName: "IX_Tours_ZooDayId");

            migrationBuilder.RenameIndex(
                name: "IX_Tour_GuideId",
                table: "Tours",
                newName: "IX_Tours_GuideId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visitors",
                table: "Visitors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourParticipants",
                table: "TourParticipants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tours",
                table: "Tours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TourParticipants_Tours_TourID",
                table: "TourParticipants",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourParticipants_Visitors_VisitorId",
                table: "TourParticipants",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Guides_GuideId",
                table: "Tours",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_ZooDays_ZooDayId",
                table: "Tours",
                column: "ZooDayId",
                principalTable: "ZooDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourParticipants_Tours_TourID",
                table: "TourParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_TourParticipants_Visitors_VisitorId",
                table: "TourParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Guides_GuideId",
                table: "Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_ZooDays_ZooDayId",
                table: "Tours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visitors",
                table: "Visitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tours",
                table: "Tours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourParticipants",
                table: "TourParticipants");

            migrationBuilder.RenameTable(
                name: "Visitors",
                newName: "Visitor");

            migrationBuilder.RenameTable(
                name: "Tours",
                newName: "Tour");

            migrationBuilder.RenameTable(
                name: "TourParticipants",
                newName: "TourParticipant");

            migrationBuilder.RenameIndex(
                name: "IX_Tours_ZooDayId",
                table: "Tour",
                newName: "IX_Tour_ZooDayId");

            migrationBuilder.RenameIndex(
                name: "IX_Tours_GuideId",
                table: "Tour",
                newName: "IX_Tour_GuideId");

            migrationBuilder.RenameIndex(
                name: "IX_TourParticipants_VisitorId",
                table: "TourParticipant",
                newName: "IX_TourParticipant_VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_TourParticipants_TourID",
                table: "TourParticipant",
                newName: "IX_TourParticipant_TourID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visitor",
                table: "Visitor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tour",
                table: "Tour",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourParticipant",
                table: "TourParticipant",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Guides_GuideId",
                table: "Tour",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_ZooDays_ZooDayId",
                table: "Tour",
                column: "ZooDayId",
                principalTable: "ZooDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourParticipant_Tour_TourID",
                table: "TourParticipant",
                column: "TourID",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourParticipant_Visitor_VisitorId",
                table: "TourParticipant",
                column: "VisitorId",
                principalTable: "Visitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

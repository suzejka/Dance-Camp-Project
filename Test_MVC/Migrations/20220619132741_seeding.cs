using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_MVC.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SponsorOpenEvent_Event_OpenEventId",
                table: "SponsorOpenEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_SponsorOpenEvent_Sponsor_SponsorId",
                table: "SponsorOpenEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SponsorOpenEvent",
                table: "SponsorOpenEvent");

            migrationBuilder.RenameTable(
                name: "SponsorOpenEvent",
                newName: "SponsorOpenEvents");

            migrationBuilder.RenameIndex(
                name: "IX_SponsorOpenEvent_SponsorId",
                table: "SponsorOpenEvents",
                newName: "IX_SponsorOpenEvents_SponsorId");

            migrationBuilder.RenameIndex(
                name: "IX_SponsorOpenEvent_OpenEventId",
                table: "SponsorOpenEvents",
                newName: "IX_SponsorOpenEvents_OpenEventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SponsorOpenEvents",
                table: "SponsorOpenEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorOpenEvents_Event_OpenEventId",
                table: "SponsorOpenEvents",
                column: "OpenEventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorOpenEvents_Sponsor_SponsorId",
                table: "SponsorOpenEvents",
                column: "SponsorId",
                principalTable: "Sponsor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SponsorOpenEvents_Event_OpenEventId",
                table: "SponsorOpenEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_SponsorOpenEvents_Sponsor_SponsorId",
                table: "SponsorOpenEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SponsorOpenEvents",
                table: "SponsorOpenEvents");

            migrationBuilder.RenameTable(
                name: "SponsorOpenEvents",
                newName: "SponsorOpenEvent");

            migrationBuilder.RenameIndex(
                name: "IX_SponsorOpenEvents_SponsorId",
                table: "SponsorOpenEvent",
                newName: "IX_SponsorOpenEvent_SponsorId");

            migrationBuilder.RenameIndex(
                name: "IX_SponsorOpenEvents_OpenEventId",
                table: "SponsorOpenEvent",
                newName: "IX_SponsorOpenEvent_OpenEventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SponsorOpenEvent",
                table: "SponsorOpenEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorOpenEvent_Event_OpenEventId",
                table: "SponsorOpenEvent",
                column: "OpenEventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorOpenEvent_Sponsor_SponsorId",
                table: "SponsorOpenEvent",
                column: "SponsorId",
                principalTable: "Sponsor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

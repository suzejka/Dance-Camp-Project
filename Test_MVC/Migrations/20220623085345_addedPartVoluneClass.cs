using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_MVC.Migrations
{
    public partial class addedPartVoluneClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPerson");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_EventId",
                table: "Person",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Event_EventId",
                table: "Person",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Event_EventId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_EventId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "EventPerson",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPerson", x => new { x.EventsId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_EventPerson_Event_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPerson_Person_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPerson_ParticipantsId",
                table: "EventPerson",
                column: "ParticipantsId");
        }
    }
}

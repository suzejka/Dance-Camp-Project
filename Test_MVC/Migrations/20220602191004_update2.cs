using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_MVC.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerTraining_Training_TrainingsId",
                table: "TrainerTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Training",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "NumberOfClassess",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Training",
                newName: "Event");

            migrationBuilder.RenameColumn(
                name: "licenceNumber",
                table: "Person",
                newName: "LicenceNumber");

            migrationBuilder.RenameColumn(
                name: "TrainingType",
                table: "Event",
                newName: "Status");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Event",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Event",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CameraUsage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraId = table.Column<int>(type: "int", nullable: false),
                    CameraOperatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CameraUsage_Camera_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Camera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CameraUsage_Person_CameraOperatorId",
                        column: x => x.CameraOperatorId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShowTrainer",
                columns: table => new
                {
                    ShowsId = table.Column<int>(type: "int", nullable: false),
                    TrainersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTrainer", x => new { x.ShowsId, x.TrainersId });
                    table.ForeignKey(
                        name: "FK_ShowTrainer_Person_TrainersId",
                        column: x => x.TrainersId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowTrainer_Show_ShowsId",
                        column: x => x.ShowsId,
                        principalTable: "Show",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_RoomId",
                table: "Event",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CameraUsage_CameraId",
                table: "CameraUsage",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_CameraUsage_CameraOperatorId",
                table: "CameraUsage",
                column: "CameraOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPerson_ParticipantsId",
                table: "EventPerson",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTrainer_TrainersId",
                table: "ShowTrainer",
                column: "TrainersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Room_RoomId",
                table: "Event",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerTraining_Event_TrainingsId",
                table: "TrainerTraining",
                column: "TrainingsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Room_RoomId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerTraining_Event_TrainingsId",
                table: "TrainerTraining");

            migrationBuilder.DropTable(
                name: "CameraUsage");

            migrationBuilder.DropTable(
                name: "EventPerson");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "ShowTrainer");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_RoomId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Training");

            migrationBuilder.RenameColumn(
                name: "LicenceNumber",
                table: "Person",
                newName: "licenceNumber");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Training",
                newName: "TrainingType");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfClassess",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Training",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Training",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Training",
                table: "Training",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerTraining_Training_TrainingsId",
                table: "TrainerTraining",
                column: "TrainingsId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

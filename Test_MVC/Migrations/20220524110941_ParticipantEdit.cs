using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_MVC.Migrations
{
    public partial class ParticipantEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AmountOfHoursWorked",
                table: "Person",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DormitoryNumber",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Person",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfHoursWorked",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DormitoryNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Person");
        }
    }
}

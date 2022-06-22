using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_MVC.Migrations
{
    public partial class ownEquip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OwnEquipment",
                table: "Person",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnEquipment",
                table: "Person");
        }
    }
}

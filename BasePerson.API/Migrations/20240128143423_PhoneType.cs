using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasePerson.API.Migrations
{
    public partial class PhoneType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Phones");
        }
    }
}

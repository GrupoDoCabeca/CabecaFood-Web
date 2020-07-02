using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class PisWithFixedLenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PIS",
                table: "DELIVERY_MAN",
                type: "CHAR(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(11)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PIS",
                table: "DELIVERY_MAN",
                type: "CHAR(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(14)");
        }
    }
}

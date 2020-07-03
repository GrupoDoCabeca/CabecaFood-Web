using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class User_PasswordMoreLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD",
                table: "USERS",
                type: "VARCHAR(255)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(16)",
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD",
                table: "USERS",
                type: "VARCHAR(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)",
                oldMaxLength: 16);
        }
    }
}

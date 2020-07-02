using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class addressNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ADDRESS_AddressId",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_USERS_AddressId",
                table: "USERS");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "USERS",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_UserId",
                table: "ADDRESS",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESS_USERS_UserId",
                table: "ADDRESS",
                column: "UserId",
                principalTable: "USERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESS_USERS_UserId",
                table: "ADDRESS");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESS_UserId",
                table: "ADDRESS");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "USERS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_AddressId",
                table: "USERS",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ADDRESS_AddressId",
                table: "USERS",
                column: "AddressId",
                principalTable: "ADDRESS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

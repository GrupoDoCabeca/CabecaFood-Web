using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    STATE = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CITY = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NEIGHBORHOOD = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    STREET = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NUMBER = table.Column<string>(type: "VARCHAR(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERY_MAN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    SALARY = table.Column<double>(type: "FLOAT", nullable: false),
                    PIS = table.Column<string>(type: "CHAR(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERY_MAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INGREDIENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    AMOUNT_TYPE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    DATE = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SNACK",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PRICE = table.Column<double>(type: "FLOAT", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SNACK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR(16)", maxLength: 16, nullable: false),
                    IS_ADMIN = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "DELIVERY_MAN");

            migrationBuilder.DropTable(
                name: "INGREDIENTS");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "SNACK");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}

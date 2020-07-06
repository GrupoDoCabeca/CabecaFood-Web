using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class CreateNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SNACK_ORDER_OrderId",
                table: "SNACK");

            migrationBuilder.DropIndex(
                name: "IX_SNACK_OrderId",
                table: "SNACK");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "SNACK");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "SNACK",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "ORDER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ORDERS_SNACKS",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    SnackId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS_SNACKS", x => new { x.OrderId, x.SnackId });
                    table.ForeignKey(
                        name: "FK_ORDERS_SNACKS_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_SNACKS_SNACK_SnackId",
                        column: x => x.SnackId,
                        principalTable: "SNACK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_SNACKS_SnackId",
                table: "ORDERS_SNACKS",
                column: "SnackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDERS_SNACKS");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "ORDER");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "SNACK",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "SNACK",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SNACK_OrderId",
                table: "SNACK",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SNACK_ORDER_OrderId",
                table: "SNACK",
                column: "OrderId",
                principalTable: "ORDER",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

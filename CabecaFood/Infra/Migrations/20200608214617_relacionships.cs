using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class relacionships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "USERS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryManId",
                table: "ORDER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ORDER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ADDRESS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ORDER_SNACK",
                columns: table => new
                {
                    SnackId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_SNACK", x => new { x.OrderId, x.SnackId });
                    table.ForeignKey(
                        name: "FK_ORDER_SNACK_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_SNACK_SNACK_SnackId",
                        column: x => x.SnackId,
                        principalTable: "SNACK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SNACK_INGREDIENT",
                columns: table => new
                {
                    SnackId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SNACK_INGREDIENT", x => new { x.IngredientId, x.SnackId });
                    table.ForeignKey(
                        name: "FK_SNACK_INGREDIENT_INGREDIENTS_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "INGREDIENTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SNACK_INGREDIENT_SNACK_SnackId",
                        column: x => x.SnackId,
                        principalTable: "SNACK",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USERS_AddressId",
                table: "USERS",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DeliveryManId",
                table: "ORDER",
                column: "DeliveryManId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_UserId",
                table: "ORDER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_SNACK_SnackId",
                table: "ORDER_SNACK",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_SNACK_INGREDIENT_SnackId",
                table: "SNACK_INGREDIENT",
                column: "SnackId");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_DELIVERY_MAN_DeliveryManId",
                table: "ORDER",
                column: "DeliveryManId",
                principalTable: "DELIVERY_MAN",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_USERS_UserId",
                table: "ORDER",
                column: "UserId",
                principalTable: "USERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ADDRESS_AddressId",
                table: "USERS",
                column: "AddressId",
                principalTable: "ADDRESS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_DELIVERY_MAN_DeliveryManId",
                table: "ORDER");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_USERS_UserId",
                table: "ORDER");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ADDRESS_AddressId",
                table: "USERS");

            migrationBuilder.DropTable(
                name: "ORDER_SNACK");

            migrationBuilder.DropTable(
                name: "SNACK_INGREDIENT");

            migrationBuilder.DropIndex(
                name: "IX_USERS_AddressId",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_DeliveryManId",
                table: "ORDER");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_UserId",
                table: "ORDER");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "DeliveryManId",
                table: "ORDER");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ORDER");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ADDRESS");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_SNACK");

            migrationBuilder.DropTable(
                name: "SNACK_INGREDIENT");

            migrationBuilder.DropTable(
                name: "INGREDIENTS");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "SNACK",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "INGREDIENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMOUNT_TYPE = table.Column<int>(type: "int", nullable: false),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_SNACK",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SnackId = table.Column<int>(type: "int", nullable: false)
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
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    SnackId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_ORDER_SNACK_SnackId",
                table: "ORDER_SNACK",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_SNACK_INGREDIENT_SnackId",
                table: "SNACK_INGREDIENT",
                column: "SnackId");
        }
    }
}

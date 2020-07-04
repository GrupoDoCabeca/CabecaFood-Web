using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class newColunsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ADDRESS_UserId",
                table: "ADDRESS");

            migrationBuilder.DropColumn(
                name: "IS_ADMIN",
                table: "USERS");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "SNACK",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "ORDER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ADDRESS",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "ADDRESS",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RESTAURANT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CNPJ = table.Column<string>(type: "CHAR(18)", nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTAURANT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMMENT_RESTAURANT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DELETED = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    RestaurantId = table.Column<int>(nullable: false),
                    COMENTARIO = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    IsGood = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENT_RESTAURANT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMMENT_RESTAURANT_RESTAURANT_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "RESTAURANT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMMENT_RESTAURANT_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SNACK_RestaurantId",
                table: "SNACK",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_RestaurantId",
                table: "ORDER",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_RestaurantId",
                table: "ADDRESS",
                column: "RestaurantId",
                unique: true,
                filter: "[RestaurantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_UserId",
                table: "ADDRESS",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_RESTAURANT_RestaurantId",
                table: "COMMENT_RESTAURANT",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_RESTAURANT_UserId",
                table: "COMMENT_RESTAURANT",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESS_RESTAURANT_RestaurantId",
                table: "ADDRESS",
                column: "RestaurantId",
                principalTable: "RESTAURANT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_RESTAURANT_RestaurantId",
                table: "ORDER",
                column: "RestaurantId",
                principalTable: "RESTAURANT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SNACK_RESTAURANT_RestaurantId",
                table: "SNACK",
                column: "RestaurantId",
                principalTable: "RESTAURANT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESS_RESTAURANT_RestaurantId",
                table: "ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_RESTAURANT_RestaurantId",
                table: "ORDER");

            migrationBuilder.DropForeignKey(
                name: "FK_SNACK_RESTAURANT_RestaurantId",
                table: "SNACK");

            migrationBuilder.DropTable(
                name: "COMMENT_RESTAURANT");

            migrationBuilder.DropTable(
                name: "RESTAURANT");

            migrationBuilder.DropIndex(
                name: "IX_SNACK_RestaurantId",
                table: "SNACK");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_RestaurantId",
                table: "ORDER");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESS_RestaurantId",
                table: "ADDRESS");

            migrationBuilder.DropIndex(
                name: "IX_ADDRESS_UserId",
                table: "ADDRESS");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "SNACK");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "ORDER");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "ADDRESS");

            migrationBuilder.AddColumn<bool>(
                name: "IS_ADMIN",
                table: "USERS",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ADDRESS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_UserId",
                table: "ADDRESS",
                column: "UserId",
                unique: true);
        }
    }
}

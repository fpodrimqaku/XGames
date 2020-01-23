using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XGames.Migrations
{
    public partial class shopSim1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: false),
                    checkedOut = table.Column<bool>(nullable: false),
                    total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LineItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItem_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_CartId",
                table: "LineItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_GameId",
                table: "LineItem",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}

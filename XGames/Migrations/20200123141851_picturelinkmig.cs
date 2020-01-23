using Microsoft.EntityFrameworkCore.Migrations;

namespace XGames.Migrations
{
    public partial class picturelinkmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "GamePicture",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GamePicture_GameId",
                table: "GamePicture",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePicture_Game_GameId",
                table: "GamePicture",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePicture_Game_GameId",
                table: "GamePicture");

            migrationBuilder.DropIndex(
                name: "IX_GamePicture_GameId",
                table: "GamePicture");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GamePicture");
        }
    }
}

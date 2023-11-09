using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class connectSeasonAndLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "league_id",
                table: "season",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_season_league_id",
                table: "season",
                column: "league_id");

            migrationBuilder.AddForeignKey(
                name: "fk_season_leagues_league_id",
                table: "season",
                column: "league_id",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_season_leagues_league_id",
                table: "season");

            migrationBuilder.DropIndex(
                name: "ix_season_league_id",
                table: "season");

            migrationBuilder.DropColumn(
                name: "league_id",
                table: "season");
        }
    }
}

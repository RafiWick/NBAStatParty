using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class addYearToTeamSeason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_seasons_season_season_id",
                table: "team_seasons");

            migrationBuilder.DropIndex(
                name: "ix_team_seasons_season_id",
                table: "team_seasons");

            migrationBuilder.AlterColumn<string>(
                name: "season_id",
                table: "team_seasons",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "team_seasons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "team_seasons");

            migrationBuilder.AlterColumn<string>(
                name: "season_id",
                table: "team_seasons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "ix_team_seasons_season_id",
                table: "team_seasons",
                column: "season_id");

            migrationBuilder.AddForeignKey(
                name: "fk_team_seasons_season_season_id",
                table: "team_seasons",
                column: "season_id",
                principalTable: "season",
                principalColumn: "id");
        }
    }
}

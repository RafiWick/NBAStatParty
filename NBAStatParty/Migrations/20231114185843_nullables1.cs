using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class nullables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_players_player_drafts_draft_id",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "fk_team_seasons_ranks_ranks_id",
                table: "team_seasons");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_divisions_division_id",
                table: "teams");

            migrationBuilder.AlterColumn<string>(
                name: "division_id",
                table: "teams",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "division_alias",
                table: "teams",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ranks_id",
                table: "team_seasons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "draft_id",
                table: "players",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_players_player_drafts_draft_id",
                table: "players",
                column: "draft_id",
                principalTable: "player_drafts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_team_seasons_ranks_ranks_id",
                table: "team_seasons",
                column: "ranks_id",
                principalTable: "ranks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_teams_divisions_division_id",
                table: "teams",
                column: "division_id",
                principalTable: "divisions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_players_player_drafts_draft_id",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "fk_team_seasons_ranks_ranks_id",
                table: "team_seasons");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_divisions_division_id",
                table: "teams");

            migrationBuilder.AlterColumn<string>(
                name: "division_id",
                table: "teams",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "division_alias",
                table: "teams",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ranks_id",
                table: "team_seasons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "draft_id",
                table: "players",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_players_player_drafts_draft_id",
                table: "players",
                column: "draft_id",
                principalTable: "player_drafts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_team_seasons_ranks_ranks_id",
                table: "team_seasons",
                column: "ranks_id",
                principalTable: "ranks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_teams_divisions_division_id",
                table: "teams",
                column: "division_id",
                principalTable: "divisions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

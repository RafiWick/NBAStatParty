using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class players2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_coach_teams_team_id",
                table: "coach");

            migrationBuilder.DropForeignKey(
                name: "fk_color_rgb_rgb_id",
                table: "color");

            migrationBuilder.DropForeignKey(
                name: "fk_color_teams_team_id",
                table: "color");

            migrationBuilder.DropForeignKey(
                name: "fk_player_player_draft_draft_id",
                table: "player");

            migrationBuilder.DropForeignKey(
                name: "fk_player_teams_team_id",
                table: "player");

            migrationBuilder.DropForeignKey(
                name: "fk_season_leagues_league_id",
                table: "season");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_venue_venue_id",
                table: "teams");

            migrationBuilder.DropForeignKey(
                name: "fk_venue_location_location_id",
                table: "venue");

            migrationBuilder.DropPrimaryKey(
                name: "pk_venue",
                table: "venue");

            migrationBuilder.DropPrimaryKey(
                name: "pk_season",
                table: "season");

            migrationBuilder.DropPrimaryKey(
                name: "pk_rgb",
                table: "rgb");

            migrationBuilder.DropPrimaryKey(
                name: "pk_player_draft",
                table: "player_draft");

            migrationBuilder.DropPrimaryKey(
                name: "pk_player",
                table: "player");

            migrationBuilder.DropPrimaryKey(
                name: "pk_location",
                table: "location");

            migrationBuilder.DropPrimaryKey(
                name: "pk_color",
                table: "color");

            migrationBuilder.DropPrimaryKey(
                name: "pk_coach",
                table: "coach");

            migrationBuilder.RenameTable(
                name: "venue",
                newName: "venues");

            migrationBuilder.RenameTable(
                name: "season",
                newName: "seasons");

            migrationBuilder.RenameTable(
                name: "rgb",
                newName: "rg_bs");

            migrationBuilder.RenameTable(
                name: "player_draft",
                newName: "player_drafts");

            migrationBuilder.RenameTable(
                name: "player",
                newName: "players");

            migrationBuilder.RenameTable(
                name: "location",
                newName: "locations");

            migrationBuilder.RenameTable(
                name: "color",
                newName: "colors");

            migrationBuilder.RenameTable(
                name: "coach",
                newName: "coaches");

            migrationBuilder.RenameIndex(
                name: "ix_venue_location_id",
                table: "venues",
                newName: "ix_venues_location_id");

            migrationBuilder.RenameIndex(
                name: "ix_season_league_id",
                table: "seasons",
                newName: "ix_seasons_league_id");

            migrationBuilder.RenameIndex(
                name: "ix_player_team_id",
                table: "players",
                newName: "ix_players_team_id");

            migrationBuilder.RenameIndex(
                name: "ix_player_draft_id",
                table: "players",
                newName: "ix_players_draft_id");

            migrationBuilder.RenameIndex(
                name: "ix_color_team_id",
                table: "colors",
                newName: "ix_colors_team_id");

            migrationBuilder.RenameIndex(
                name: "ix_color_rgb_id",
                table: "colors",
                newName: "ix_colors_rgb_id");

            migrationBuilder.RenameIndex(
                name: "ix_coach_team_id",
                table: "coaches",
                newName: "ix_coaches_team_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_venues",
                table: "venues",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_seasons",
                table: "seasons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_rg_bs",
                table: "rg_bs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_player_drafts",
                table: "player_drafts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_players",
                table: "players",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_locations",
                table: "locations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_colors",
                table: "colors",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_coaches",
                table: "coaches",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_coaches_teams_team_id",
                table: "coaches",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_colors_rg_bs_rgb_id",
                table: "colors",
                column: "rgb_id",
                principalTable: "rg_bs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_colors_teams_team_id",
                table: "colors",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_players_player_drafts_draft_id",
                table: "players",
                column: "draft_id",
                principalTable: "player_drafts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_players_teams_team_id",
                table: "players",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_seasons_leagues_league_id",
                table: "seasons",
                column: "league_id",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_teams_venues_venue_id",
                table: "teams",
                column: "venue_id",
                principalTable: "venues",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_venues_locations_location_id",
                table: "venues",
                column: "location_id",
                principalTable: "locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_coaches_teams_team_id",
                table: "coaches");

            migrationBuilder.DropForeignKey(
                name: "fk_colors_rg_bs_rgb_id",
                table: "colors");

            migrationBuilder.DropForeignKey(
                name: "fk_colors_teams_team_id",
                table: "colors");

            migrationBuilder.DropForeignKey(
                name: "fk_players_player_drafts_draft_id",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "fk_players_teams_team_id",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "fk_seasons_leagues_league_id",
                table: "seasons");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_venues_venue_id",
                table: "teams");

            migrationBuilder.DropForeignKey(
                name: "fk_venues_locations_location_id",
                table: "venues");

            migrationBuilder.DropPrimaryKey(
                name: "pk_venues",
                table: "venues");

            migrationBuilder.DropPrimaryKey(
                name: "pk_seasons",
                table: "seasons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_rg_bs",
                table: "rg_bs");

            migrationBuilder.DropPrimaryKey(
                name: "pk_players",
                table: "players");

            migrationBuilder.DropPrimaryKey(
                name: "pk_player_drafts",
                table: "player_drafts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_locations",
                table: "locations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_colors",
                table: "colors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_coaches",
                table: "coaches");

            migrationBuilder.RenameTable(
                name: "venues",
                newName: "venue");

            migrationBuilder.RenameTable(
                name: "seasons",
                newName: "season");

            migrationBuilder.RenameTable(
                name: "rg_bs",
                newName: "rgb");

            migrationBuilder.RenameTable(
                name: "players",
                newName: "player");

            migrationBuilder.RenameTable(
                name: "player_drafts",
                newName: "player_draft");

            migrationBuilder.RenameTable(
                name: "locations",
                newName: "location");

            migrationBuilder.RenameTable(
                name: "colors",
                newName: "color");

            migrationBuilder.RenameTable(
                name: "coaches",
                newName: "coach");

            migrationBuilder.RenameIndex(
                name: "ix_venues_location_id",
                table: "venue",
                newName: "ix_venue_location_id");

            migrationBuilder.RenameIndex(
                name: "ix_seasons_league_id",
                table: "season",
                newName: "ix_season_league_id");

            migrationBuilder.RenameIndex(
                name: "ix_players_team_id",
                table: "player",
                newName: "ix_player_team_id");

            migrationBuilder.RenameIndex(
                name: "ix_players_draft_id",
                table: "player",
                newName: "ix_player_draft_id");

            migrationBuilder.RenameIndex(
                name: "ix_colors_team_id",
                table: "color",
                newName: "ix_color_team_id");

            migrationBuilder.RenameIndex(
                name: "ix_colors_rgb_id",
                table: "color",
                newName: "ix_color_rgb_id");

            migrationBuilder.RenameIndex(
                name: "ix_coaches_team_id",
                table: "coach",
                newName: "ix_coach_team_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_venue",
                table: "venue",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_season",
                table: "season",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_rgb",
                table: "rgb",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_player",
                table: "player",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_player_draft",
                table: "player_draft",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_location",
                table: "location",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_color",
                table: "color",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_coach",
                table: "coach",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_coach_teams_team_id",
                table: "coach",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_color_rgb_rgb_id",
                table: "color",
                column: "rgb_id",
                principalTable: "rgb",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_color_teams_team_id",
                table: "color",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_player_player_draft_draft_id",
                table: "player",
                column: "draft_id",
                principalTable: "player_draft",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_player_teams_team_id",
                table: "player",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_season_leagues_league_id",
                table: "season",
                column: "league_id",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_teams_venue_venue_id",
                table: "teams",
                column: "venue_id",
                principalTable: "venue",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_venue_location_location_id",
                table: "venue",
                column: "location_id",
                principalTable: "location",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

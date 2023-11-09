using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class teams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games_behinds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    league = table.Column<double>(type: "double precision", nullable: false),
                    conference = table.Column<double>(type: "double precision", nullable: false),
                    division = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_games_behinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "leagues",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    alias = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_leagues", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ranks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    div_rank = table.Column<int>(type: "integer", nullable: false),
                    conf_rank = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ranks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "season",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_season", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "conferences",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    alias = table.Column<string>(type: "text", nullable: false),
                    league_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_conferences", x => x.id);
                    table.ForeignKey(
                        name: "fk_conferences_leagues_league_id",
                        column: x => x.league_id,
                        principalTable: "leagues",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "divisions",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    alias = table.Column<string>(type: "text", nullable: false),
                    conference_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_divisions", x => x.id);
                    table.ForeignKey(
                        name: "fk_divisions_conferences_conference_id",
                        column: x => x.conference_id,
                        principalTable: "conferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    market = table.Column<string>(type: "text", nullable: false),
                    division_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                    table.ForeignKey(
                        name: "fk_teams_divisions_division_id",
                        column: x => x.division_id,
                        principalTable: "divisions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "team_seasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    team_id = table.Column<string>(type: "text", nullable: false),
                    season_id = table.Column<string>(type: "text", nullable: true),
                    wins = table.Column<int>(type: "integer", nullable: false),
                    losses = table.Column<int>(type: "integer", nullable: false),
                    win_pct = table.Column<float>(type: "real", nullable: false),
                    points_for = table.Column<float>(type: "real", nullable: false),
                    points_against = table.Column<float>(type: "real", nullable: false),
                    point_diff = table.Column<float>(type: "real", nullable: false),
                    games_behind_id = table.Column<int>(type: "integer", nullable: false),
                    calc_rank_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team_seasons", x => x.id);
                    table.ForeignKey(
                        name: "fk_team_seasons_games_behinds_games_behind_id",
                        column: x => x.games_behind_id,
                        principalTable: "games_behinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_team_seasons_ranks_calc_rank_id",
                        column: x => x.calc_rank_id,
                        principalTable: "ranks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_team_seasons_season_season_id",
                        column: x => x.season_id,
                        principalTable: "season",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_team_seasons_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "records",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    record_type = table.Column<string>(type: "text", nullable: false),
                    wins = table.Column<int>(type: "integer", nullable: false),
                    losses = table.Column<int>(type: "integer", nullable: false),
                    win_pct = table.Column<float>(type: "real", nullable: false),
                    team_season_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_records_team_seasons_team_season_id",
                        column: x => x.team_season_id,
                        principalTable: "team_seasons",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_conferences_league_id",
                table: "conferences",
                column: "league_id");

            migrationBuilder.CreateIndex(
                name: "ix_divisions_conference_id",
                table: "divisions",
                column: "conference_id");

            migrationBuilder.CreateIndex(
                name: "ix_records_team_season_id",
                table: "records",
                column: "team_season_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_seasons_calc_rank_id",
                table: "team_seasons",
                column: "calc_rank_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_seasons_games_behind_id",
                table: "team_seasons",
                column: "games_behind_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_seasons_season_id",
                table: "team_seasons",
                column: "season_id");

            migrationBuilder.CreateIndex(
                name: "ix_team_seasons_team_id",
                table: "team_seasons",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_teams_division_id",
                table: "teams",
                column: "division_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "records");

            migrationBuilder.DropTable(
                name: "team_seasons");

            migrationBuilder.DropTable(
                name: "games_behinds");

            migrationBuilder.DropTable(
                name: "ranks");

            migrationBuilder.DropTable(
                name: "season");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "divisions");

            migrationBuilder.DropTable(
                name: "conferences");

            migrationBuilder.DropTable(
                name: "leagues");
        }
    }
}

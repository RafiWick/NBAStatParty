using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class players : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "record_type",
                table: "records",
                newName: "type");

            migrationBuilder.AddColumn<string>(
                name: "alias",
                table: "teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "conference_alias",
                table: "teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "division_alias",
                table: "teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "founded",
                table: "teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "league_alias",
                table: "teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "venue_id",
                table: "teams",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "coach",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    experience = table.Column<string>(type: "text", nullable: false),
                    team_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_coach", x => x.id);
                    table.ForeignKey(
                        name: "fk_coach_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lat = table.Column<string>(type: "text", nullable: false),
                    lng = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_draft",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    team_id = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    round = table.Column<string>(type: "text", nullable: false),
                    pick = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_draft", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rgb",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    r = table.Column<int>(type: "integer", nullable: false),
                    g = table.Column<int>(type: "integer", nullable: false),
                    b = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rgb", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "venue",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    zip = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    location_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_venue", x => x.id);
                    table.ForeignKey(
                        name: "fk_venue_location_location_id",
                        column: x => x.location_id,
                        principalTable: "location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    abbr_name = table.Column<string>(type: "text", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<int>(type: "integer", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    primary_position = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    experience = table.Column<string>(type: "text", nullable: false),
                    college = table.Column<string>(type: "text", nullable: false),
                    high_school = table.Column<string>(type: "text", nullable: false),
                    birth_place = table.Column<string>(type: "text", nullable: false),
                    birthdate = table.Column<string>(type: "text", nullable: false),
                    rookie_year = table.Column<int>(type: "integer", nullable: false),
                    draft_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player", x => x.id);
                    table.ForeignKey(
                        name: "fk_player_player_draft_draft_id",
                        column: x => x.draft_id,
                        principalTable: "player_draft",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "color",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false),
                    hex = table.Column<string>(type: "text", nullable: false),
                    rgb_id = table.Column<int>(type: "integer", nullable: false),
                    team_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_color", x => x.id);
                    table.ForeignKey(
                        name: "fk_color_rgb_rgb_id",
                        column: x => x.rgb_id,
                        principalTable: "rgb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_color_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_teams_venue_id",
                table: "teams",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "ix_coach_team_id",
                table: "coach",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_color_rgb_id",
                table: "color",
                column: "rgb_id");

            migrationBuilder.CreateIndex(
                name: "ix_color_team_id",
                table: "color",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_draft_id",
                table: "player",
                column: "draft_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_team_id",
                table: "player",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_venue_location_id",
                table: "venue",
                column: "location_id");

            migrationBuilder.AddForeignKey(
                name: "fk_teams_venue_venue_id",
                table: "teams",
                column: "venue_id",
                principalTable: "venue",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_teams_venue_venue_id",
                table: "teams");

            migrationBuilder.DropTable(
                name: "coach");

            migrationBuilder.DropTable(
                name: "color");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "venue");

            migrationBuilder.DropTable(
                name: "rgb");

            migrationBuilder.DropTable(
                name: "player_draft");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropIndex(
                name: "ix_teams_venue_id",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "alias",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "conference_alias",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "division_alias",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "founded",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "league_alias",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "venue_id",
                table: "teams");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "records",
                newName: "record_type");
        }
    }
}

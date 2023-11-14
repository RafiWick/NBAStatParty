using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class addwnba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_players_teams_team_id",
                table: "players");

            migrationBuilder.AddColumn<string>(
                name: "conference_id",
                table: "teams",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "team_id",
                table: "players",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_teams_conference_id",
                table: "teams",
                column: "conference_id");

            migrationBuilder.AddForeignKey(
                name: "fk_players_teams_team_id",
                table: "players",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_teams_conferences_conference_id",
                table: "teams",
                column: "conference_id",
                principalTable: "conferences",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_players_teams_team_id",
                table: "players");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_conferences_conference_id",
                table: "teams");

            migrationBuilder.DropIndex(
                name: "ix_teams_conference_id",
                table: "teams");

            migrationBuilder.DropColumn(
                name: "conference_id",
                table: "teams");

            migrationBuilder.AlterColumn<string>(
                name: "team_id",
                table: "players",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "fk_players_teams_team_id",
                table: "players",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id");
        }
    }
}

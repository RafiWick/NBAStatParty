using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class fixendlessloopjsonerror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_conferences_leagues_league_id",
                table: "conferences");

            migrationBuilder.AlterColumn<string>(
                name: "league_id",
                table: "conferences",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_conferences_leagues_league_id",
                table: "conferences",
                column: "league_id",
                principalTable: "leagues",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_conferences_leagues_league_id",
                table: "conferences");

            migrationBuilder.AlterColumn<string>(
                name: "league_id",
                table: "conferences",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "fk_conferences_leagues_league_id",
                table: "conferences",
                column: "league_id",
                principalTable: "leagues",
                principalColumn: "id");
        }
    }
}

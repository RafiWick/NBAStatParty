using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NBAStatParty.Migrations
{
    /// <inheritdoc />
    public partial class namechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_seasons_ranks_calc_rank_id",
                table: "team_seasons");

            migrationBuilder.RenameColumn(
                name: "calc_rank_id",
                table: "team_seasons",
                newName: "ranks_id");

            migrationBuilder.RenameIndex(
                name: "ix_team_seasons_calc_rank_id",
                table: "team_seasons",
                newName: "ix_team_seasons_ranks_id");

            migrationBuilder.AddForeignKey(
                name: "fk_team_seasons_ranks_ranks_id",
                table: "team_seasons",
                column: "ranks_id",
                principalTable: "ranks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_team_seasons_ranks_ranks_id",
                table: "team_seasons");

            migrationBuilder.RenameColumn(
                name: "ranks_id",
                table: "team_seasons",
                newName: "calc_rank_id");

            migrationBuilder.RenameIndex(
                name: "ix_team_seasons_ranks_id",
                table: "team_seasons",
                newName: "ix_team_seasons_calc_rank_id");

            migrationBuilder.AddForeignKey(
                name: "fk_team_seasons_ranks_calc_rank_id",
                table: "team_seasons",
                column: "calc_rank_id",
                principalTable: "ranks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

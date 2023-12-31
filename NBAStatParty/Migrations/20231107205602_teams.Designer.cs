﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBAStatParty.DataAccess;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NBAStatParty.Migrations
{
    [DbContext(typeof(NBAContext))]
    [Migration("20231107205602_teams")]
    partial class teams
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Conference", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alias");

                    b.Property<string>("LeagueId")
                        .HasColumnType("text")
                        .HasColumnName("league_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_conferences");

                    b.HasIndex("LeagueId")
                        .HasDatabaseName("ix_conferences_league_id");

                    b.ToTable("conferences", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Division", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alias");

                    b.Property<string>("ConferenceId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("conference_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_divisions");

                    b.HasIndex("ConferenceId")
                        .HasDatabaseName("ix_divisions_conference_id");

                    b.ToTable("divisions", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.GamesBehind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Conference")
                        .HasColumnType("double precision")
                        .HasColumnName("conference");

                    b.Property<double>("Division")
                        .HasColumnType("double precision")
                        .HasColumnName("division");

                    b.Property<double>("League")
                        .HasColumnType("double precision")
                        .HasColumnName("league");

                    b.HasKey("Id")
                        .HasName("pk_games_behinds");

                    b.ToTable("games_behinds", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.League", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alias");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_leagues");

                    b.ToTable("leagues", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConfRank")
                        .HasColumnType("integer")
                        .HasColumnName("conf_rank");

                    b.Property<int>("DivRank")
                        .HasColumnType("integer")
                        .HasColumnName("div_rank");

                    b.HasKey("Id")
                        .HasName("pk_ranks");

                    b.ToTable("ranks", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Losses")
                        .HasColumnType("integer")
                        .HasColumnName("losses");

                    b.Property<string>("Record_Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("record_type");

                    b.Property<int?>("TeamSeasonId")
                        .HasColumnType("integer")
                        .HasColumnName("team_season_id");

                    b.Property<float>("Win_Pct")
                        .HasColumnType("real")
                        .HasColumnName("win_pct");

                    b.Property<int>("Wins")
                        .HasColumnType("integer")
                        .HasColumnName("wins");

                    b.HasKey("Id")
                        .HasName("pk_records");

                    b.HasIndex("TeamSeasonId")
                        .HasDatabaseName("ix_records_team_season_id");

                    b.ToTable("records", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Season", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_season");

                    b.ToTable("season", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Team", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("DivisionId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("division_id");

                    b.Property<string>("Market")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("market");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_teams");

                    b.HasIndex("DivisionId")
                        .HasDatabaseName("ix_teams_division_id");

                    b.ToTable("teams", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.TeamSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Calc_RankId")
                        .HasColumnType("integer")
                        .HasColumnName("calc_rank_id");

                    b.Property<int>("Games_BehindId")
                        .HasColumnType("integer")
                        .HasColumnName("games_behind_id");

                    b.Property<int>("Losses")
                        .HasColumnType("integer")
                        .HasColumnName("losses");

                    b.Property<float>("Point_Diff")
                        .HasColumnType("real")
                        .HasColumnName("point_diff");

                    b.Property<float>("Points_Against")
                        .HasColumnType("real")
                        .HasColumnName("points_against");

                    b.Property<float>("Points_For")
                        .HasColumnType("real")
                        .HasColumnName("points_for");

                    b.Property<string>("SeasonId")
                        .HasColumnType("text")
                        .HasColumnName("season_id");

                    b.Property<string>("TeamId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("team_id");

                    b.Property<float>("Win_Pct")
                        .HasColumnType("real")
                        .HasColumnName("win_pct");

                    b.Property<int>("Wins")
                        .HasColumnType("integer")
                        .HasColumnName("wins");

                    b.HasKey("Id")
                        .HasName("pk_team_seasons");

                    b.HasIndex("Calc_RankId")
                        .HasDatabaseName("ix_team_seasons_calc_rank_id");

                    b.HasIndex("Games_BehindId")
                        .HasDatabaseName("ix_team_seasons_games_behind_id");

                    b.HasIndex("SeasonId")
                        .HasDatabaseName("ix_team_seasons_season_id");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_team_seasons_team_id");

                    b.ToTable("team_seasons", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Conference", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.League", "League")
                        .WithMany("Conferences")
                        .HasForeignKey("LeagueId")
                        .HasConstraintName("fk_conferences_leagues_league_id");

                    b.Navigation("League");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Division", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.Conference", "Conference")
                        .WithMany("Divisions")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_divisions_conferences_conference_id");

                    b.Navigation("Conference");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Record", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.TeamSeason", null)
                        .WithMany("Records")
                        .HasForeignKey("TeamSeasonId")
                        .HasConstraintName("fk_records_team_seasons_team_season_id");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Team", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teams_divisions_division_id");

                    b.Navigation("Division");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.TeamSeason", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.Rank", "Calc_Rank")
                        .WithMany()
                        .HasForeignKey("Calc_RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_team_seasons_ranks_calc_rank_id");

                    b.HasOne("NBAStatParty.Models.DbModels.GamesBehind", "Games_Behind")
                        .WithMany()
                        .HasForeignKey("Games_BehindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_team_seasons_games_behinds_games_behind_id");

                    b.HasOne("NBAStatParty.Models.DbModels.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .HasConstraintName("fk_team_seasons_season_season_id");

                    b.HasOne("NBAStatParty.Models.DbModels.Team", "Team")
                        .WithMany("Seasons")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_team_seasons_teams_team_id");

                    b.Navigation("Calc_Rank");

                    b.Navigation("Games_Behind");

                    b.Navigation("Season");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Conference", b =>
                {
                    b.Navigation("Divisions");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Division", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.League", b =>
                {
                    b.Navigation("Conferences");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Team", b =>
                {
                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.TeamSeason", b =>
                {
                    b.Navigation("Records");
                });
#pragma warning restore 612, 618
        }
    }
}

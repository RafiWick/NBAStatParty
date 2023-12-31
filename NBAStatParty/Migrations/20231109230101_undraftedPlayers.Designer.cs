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
    [Migration("20231109230101_undraftedPlayers")]
    partial class undraftedPlayers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Coach", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("experience");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("position");

                    b.Property<string>("TeamId")
                        .HasColumnType("text")
                        .HasColumnName("team_id");

                    b.HasKey("Id")
                        .HasName("pk_coaches");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_coaches_team_id");

                    b.ToTable("coaches", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Hex")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("hex");

                    b.Property<int>("RGBId")
                        .HasColumnType("integer")
                        .HasColumnName("rgb_id");

                    b.Property<string>("TeamId")
                        .HasColumnType("text")
                        .HasColumnName("team_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_colors");

                    b.HasIndex("RGBId")
                        .HasDatabaseName("ix_colors_rgb_id");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_colors_team_id");

                    b.ToTable("colors", (string)null);
                });

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
                        .IsRequired()
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

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lat");

                    b.Property<string>("Lng")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lng");

                    b.HasKey("Id")
                        .HasName("pk_locations");

                    b.ToTable("locations", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("AbbrName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("abbr_name");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("birth_place");

                    b.Property<string>("Birthdate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("birthdate");

                    b.Property<string>("College")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("college");

                    b.Property<int>("DraftId")
                        .HasColumnType("integer")
                        .HasColumnName("draft_id");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("experience");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<int>("Height")
                        .HasColumnType("integer")
                        .HasColumnName("height");

                    b.Property<string>("HighSchool")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("high_school");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("position");

                    b.Property<string>("PrimaryPosition")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("primary_position");

                    b.Property<int>("RookieYear")
                        .HasColumnType("integer")
                        .HasColumnName("rookie_year");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("TeamId")
                        .HasColumnType("text")
                        .HasColumnName("team_id");

                    b.Property<int>("Weight")
                        .HasColumnType("integer")
                        .HasColumnName("weight");

                    b.HasKey("Id")
                        .HasName("pk_players");

                    b.HasIndex("DraftId")
                        .HasDatabaseName("ix_players_draft_id");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_players_team_id");

                    b.ToTable("players", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.PlayerDraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Pick")
                        .HasColumnType("text")
                        .HasColumnName("pick");

                    b.Property<string>("Round")
                        .HasColumnType("text")
                        .HasColumnName("round");

                    b.Property<string>("TeamId")
                        .HasColumnType("text")
                        .HasColumnName("team_id");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_player_drafts");

                    b.ToTable("player_drafts", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.RGB", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("B")
                        .HasColumnType("integer")
                        .HasColumnName("b");

                    b.Property<int>("G")
                        .HasColumnType("integer")
                        .HasColumnName("g");

                    b.Property<int>("R")
                        .HasColumnType("integer")
                        .HasColumnName("r");

                    b.HasKey("Id")
                        .HasName("pk_rg_bs");

                    b.ToTable("rg_bs", (string)null);
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

                    b.Property<int?>("TeamSeasonId")
                        .HasColumnType("integer")
                        .HasColumnName("team_season_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<float>("WinPct")
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

                    b.Property<string>("LeagueId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("league_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_seasons");

                    b.HasIndex("LeagueId")
                        .HasDatabaseName("ix_seasons_league_id");

                    b.ToTable("seasons", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Team", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alias");

                    b.Property<string>("ConferenceAlias")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("conference_alias");

                    b.Property<string>("DivisionAlias")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("division_alias");

                    b.Property<string>("DivisionId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("division_id");

                    b.Property<int>("Founded")
                        .HasColumnType("integer")
                        .HasColumnName("founded");

                    b.Property<string>("LeagueAlias")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("league_alias");

                    b.Property<string>("Market")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("market");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("VenueId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("venue_id");

                    b.HasKey("Id")
                        .HasName("pk_teams");

                    b.HasIndex("DivisionId")
                        .HasDatabaseName("ix_teams_division_id");

                    b.HasIndex("VenueId")
                        .HasDatabaseName("ix_teams_venue_id");

                    b.ToTable("teams", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.TeamSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GamesBehindId")
                        .HasColumnType("integer")
                        .HasColumnName("games_behind_id");

                    b.Property<int>("Losses")
                        .HasColumnType("integer")
                        .HasColumnName("losses");

                    b.Property<float>("PointDiff")
                        .HasColumnType("real")
                        .HasColumnName("point_diff");

                    b.Property<float>("PointsAgainst")
                        .HasColumnType("real")
                        .HasColumnName("points_against");

                    b.Property<float>("PointsFor")
                        .HasColumnType("real")
                        .HasColumnName("points_for");

                    b.Property<int>("RanksId")
                        .HasColumnType("integer")
                        .HasColumnName("ranks_id");

                    b.Property<string>("SeasonId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("season_id");

                    b.Property<string>("TeamId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("team_id");

                    b.Property<float>("WinPct")
                        .HasColumnType("real")
                        .HasColumnName("win_pct");

                    b.Property<int>("Wins")
                        .HasColumnType("integer")
                        .HasColumnName("wins");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_team_seasons");

                    b.HasIndex("GamesBehindId")
                        .HasDatabaseName("ix_team_seasons_games_behind_id");

                    b.HasIndex("RanksId")
                        .HasDatabaseName("ix_team_seasons_ranks_id");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_team_seasons_team_id");

                    b.ToTable("team_seasons", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Venue", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer")
                        .HasColumnName("location_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip");

                    b.HasKey("Id")
                        .HasName("pk_venues");

                    b.HasIndex("LocationId")
                        .HasDatabaseName("ix_venues_location_id");

                    b.ToTable("venues", (string)null);
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Coach", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.Team", null)
                        .WithMany("Coaches")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("fk_coaches_teams_team_id");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Color", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.RGB", "RGB")
                        .WithMany()
                        .HasForeignKey("RGBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_colors_rg_bs_rgb_id");

                    b.HasOne("NBAStatParty.Models.DbModels.Team", null)
                        .WithMany("Colors")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("fk_colors_teams_team_id");

                    b.Navigation("RGB");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Conference", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.League", null)
                        .WithMany("Conferences")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_conferences_leagues_league_id");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Division", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.Conference", null)
                        .WithMany("Divisions")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_divisions_conferences_conference_id");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Player", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.PlayerDraft", "Draft")
                        .WithMany()
                        .HasForeignKey("DraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_players_player_drafts_draft_id");

                    b.HasOne("NBAStatParty.Models.DbModels.Team", null)
                        .WithMany("Roster")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("fk_players_teams_team_id");

                    b.Navigation("Draft");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Record", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.TeamSeason", null)
                        .WithMany("Records")
                        .HasForeignKey("TeamSeasonId")
                        .HasConstraintName("fk_records_team_seasons_team_season_id");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Season", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.League", null)
                        .WithMany("Seasons")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_seasons_leagues_league_id");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Team", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.Division", null)
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teams_divisions_division_id");

                    b.HasOne("NBAStatParty.Models.DbModels.Venue", null)
                        .WithMany("Teams")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teams_venues_venue_id");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.TeamSeason", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.GamesBehind", "GamesBehind")
                        .WithMany()
                        .HasForeignKey("GamesBehindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_team_seasons_games_behinds_games_behind_id");

                    b.HasOne("NBAStatParty.Models.DbModels.Rank", "Ranks")
                        .WithMany()
                        .HasForeignKey("RanksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_team_seasons_ranks_ranks_id");

                    b.HasOne("NBAStatParty.Models.DbModels.Team", null)
                        .WithMany("Seasons")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_team_seasons_teams_team_id");

                    b.Navigation("GamesBehind");

                    b.Navigation("Ranks");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Venue", b =>
                {
                    b.HasOne("NBAStatParty.Models.DbModels.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_venues_locations_location_id");

                    b.Navigation("Location");
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

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Team", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Colors");

                    b.Navigation("Roster");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.TeamSeason", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("NBAStatParty.Models.DbModels.Venue", b =>
                {
                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}

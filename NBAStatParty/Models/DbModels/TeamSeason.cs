﻿using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class TeamSeason
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Season Season { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public float WinPct { get; set; }
        public float PointsFor { get; set; }
        public float PointsAgainst { get; set; }
        public float PointDiff { get; set; }
        public GamesBehind GamesBehind { get; set; }
        public Rank Ranks { get; set; }
        public List<Record> Records { get; set; } = new List<Record>();


        public TeamSeason()
        {

        }

        public TeamSeason(Season season, StandingsTeam input)
        {
            Season = season;

            Wins = input.Wins;
            Losses = input.Losses;
            WinPct = input.Win_Pct;
            PointsFor = input.Points_For;
            PointsAgainst = input.Points_Against;
            PointDiff = input.Point_Diff;
            GamesBehind = new GamesBehind(input.Games_Behind);
            Ranks = new Rank(input.Calc_Rank);
            foreach(var record in input.Records)
            {
                Records.Add(new Record(record));
            }
        }
    }
}

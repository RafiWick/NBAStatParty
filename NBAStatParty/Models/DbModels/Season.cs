﻿using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class Season
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string LeagueId { get; set; }

        public Season()
        {

        }

        public Season(StandingsSeason input)
        {
            Id = input.Id;
            Year = input.Year;
            Type = input.Type;
        }
    }
}

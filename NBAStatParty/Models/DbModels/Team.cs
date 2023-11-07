using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }
        public List<TeamSeason> Seasons { get; set; } = new List<TeamSeason>();
        public Division Division { get; set; }

        public Team()
        {

        }

        public Team(StandingsTeam input)
        {
            Id = input.Id;
            Name = input.Name;
            Market = input.Market;
        }
    }
}

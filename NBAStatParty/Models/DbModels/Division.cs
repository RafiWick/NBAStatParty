
using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class Division
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
        public string ConferenceId { get; set; }

        public Division()
        {

        }

        public Division(StandingsDivision input)
        {
            Id = input.Id;
            Name = input.Name;
            Alias = input.Alias;

            foreach(var team in input.Teams)
            {
                var newTeam = new Team(team);
                Teams.Add(newTeam);
            }
        }
    }
}

using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;

namespace NBAStatParty.Models.DbModels
{
    public class Conference
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Division> Divisions { get; set; } = new List<Division>();
        public List<Team> Teams { get; set; } = new List<Team>();
        public string LeagueId { get; set; }

        public Conference()
        {

        }

        public Conference(SR_Standings.Conference conference)
        {
            Id = conference.Id;
            Name = conference.Name;
            Alias = conference.Alias;
        }

        public static async Task<Conference> CreateAsync(SR_Standings.Conference input, string league, INBAApiService _NBAApiService, string apiKey, NBAContext context)
        {
            Conference conference = new Conference(input);
            if (input.Divisions != null)
            {
                foreach (var division in input.Divisions)
                {
                    var newDivision = await Division.CreateAsync(division, league, _NBAApiService, apiKey, context);
                    conference.Divisions.Add(newDivision);
                }
            }
            else
            {
                foreach (var team in input.Teams)
                {
                    var newTeam = await Team.CreateAsync(team.Id, league, _NBAApiService, apiKey, context);
                    conference.Teams.Add(newTeam);
                }
            }
            
            return conference;
        }
    }
}

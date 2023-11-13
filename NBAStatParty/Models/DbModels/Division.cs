
using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;

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

        public Division(SR_Standings.Division input)
        {
            Id = input.Id;
            Name = input.Name;
            Alias = input.Alias;

            
        }

        public static async Task<Division> CreateAsync(SR_Standings.Division input, INBAApiService _NBAApiService, string apiKey, NBAContext context)
        {
            Division division = new Division(input);
            foreach (var team in input.Teams)
            {
                var newTeam = await Team.CreateAsync(team.Id, _NBAApiService, apiKey, context);
                division.Teams.Add(newTeam);
            }
            return division;
        }
    }
}

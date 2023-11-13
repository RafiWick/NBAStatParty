using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;

namespace NBAStatParty.Models.DbModels
{
    public class League
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Conference> Conferences { get; set; } = new List<Conference>();
        public List<Season> Seasons { get; set; } = new List<Season>();

        public League()
        {

        }

        public League(SR_Standings.SR_Standings input)
        {
            Id = input.League.Id;
            Name = input.League.Name;
            Alias = input.League.Alias;
        }

        public static async Task<League> CreateAsync(SR_Standings.SR_Standings input, INBAApiService _NBAApiService, string apiKey, NBAContext context)
        {
            League league = new League(input);
            foreach (var conference in input.Conferences)
            {
                var newConference = await Conference.CreateAsync(conference, _NBAApiService, apiKey, context);
                league.Conferences.Add(newConference);
            }
            return league;
        }
    }
}

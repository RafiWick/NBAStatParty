using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;

namespace NBAStatParty.Models.DbModels
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }
        public string Alias { get; set; }
        public int Founded { get; set; }
        public string VenueId { get; set; }
        public string LeagueAlias { get; set; }
        public string ConferenceAlias { get; set; }
        public string DivisionAlias { get; set; }
        public List<Coach> Coaches { get; set; } = new List<Coach>();
        public List<Color> Colors { get; set; } = new List<Color>();
        public List<Player> Roster { get; set; } = new List<Player>();
        public List<TeamSeason> Seasons { get; set; } = new List<TeamSeason>();
        public string DivisionId { get; set; }

        public Team()
        {

        }

        public Team(SR_TeamProfile.SR_TeamProfile input, NBAContext context)
        {
            Id = input.Id;
            Name = input.Name;
            Market = input.Market;
            Alias = input.Alias;
            Founded = input.Founded;
            LeagueAlias = input.League.Alias;
            ConferenceAlias = input.Conference.Alias;
            DivisionAlias = input.Division.Alias;
            VenueId = input.Venue.Id;
            if(!context.Venues.Any(v=> v.Id == input.Venue.Id))
            {
                context.Venues.Add(new Venue(input.Venue));
                context.SaveChanges();
            }
            

            foreach(var coach in input.Coaches)
            {
                Coaches.Add(new Coach(coach));
            }
            foreach (var color in input.Team_Colors)
            {
                Colors.Add(new Color(color));
            }
            foreach (var player in input.Players)
            {
                Roster.Add(new Player(player, Id));
            }
        }

        public static async Task<Team> CreateAsync(string id, INBAApiService _NBAApiService, string apiKey, NBAContext context)
        {
            await Task.Delay(1100);
            var teamData = await _NBAApiService.GetTeamProfile(id, apiKey);
            Team team = new Team(teamData, context);
            return team;
        }
    }
}

using NBAStatParty.Models.SR_PlayerProfile;
using NBAStatParty.Models.SR_Standings;
using NBAStatParty.Models.SR_TeamProfile;

namespace NBAStatParty.Interfaces
{
    public interface INBAApiService
    {
        Task<SR_Standings> GetStandings(int year, string apiKey);
        Task<SR_TeamProfile> GetTeamProfile(string id, string apiKey);
        Task<SR_PlayerProfile> GetPlayerProfile(string id, string apiKey);
    }
}

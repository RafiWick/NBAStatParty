using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Interfaces
{
    public interface INBAApiService
    {
        Task<SR_Standings> GetStandings(int year, string apiKey);
    }
}

using NBAStatParty.Interfaces;
using NBAStatParty.Models.SR_PlayerProfile;
using NBAStatParty.Models.SR_Standings;
using NBAStatParty.Models.SR_TeamProfile;
using Newtonsoft.Json;

namespace NBAStatParty.Services
{
    public class NBAApiService : INBAApiService
    {
        private readonly HttpClient _client;
        public NBAApiService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("NBAAPI");
        }

        public async Task<SR_Standings> GetStandings(int year, string apiKey)
        {
            var url = string.Format("/nba/trial/v8/en/seasons/{0}/REG/standings.json?api_key={1}", year, apiKey);
            var result = new SR_Standings();
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<SR_Standings>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
        
        public async Task<SR_TeamProfile> GetTeamProfile(string id, string apiKey)
        {
            var url = string.Format("/nba/trial/v8/en/teams/{0}/profile.json?api_key={1}", id, apiKey);
            var result = new SR_TeamProfile();
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<SR_TeamProfile>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }

        public async Task<SR_PlayerProfile> GetPlayerProfile(string id, string apiKey)
        {
            var url = string.Format("/nba/trial/v8/en/players/{0}/profile.json?api_key={1}", id, apiKey);
            var result = new SR_PlayerProfile();
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<SR_PlayerProfile>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;

        }
    }
}

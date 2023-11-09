namespace NBAStatParty.Models.SR_Standings
{
    public class StandingsConference
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<StandingsDivision> Divisions { get; set; }

    }
}

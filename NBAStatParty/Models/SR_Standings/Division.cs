namespace NBAStatParty.Models.SR_Standings
{
    public class StandingsDivision
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<StandingsTeam> Teams { get; set; }

    }
}

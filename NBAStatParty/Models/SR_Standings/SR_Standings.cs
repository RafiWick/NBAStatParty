namespace NBAStatParty.Models.SR_Standings
{
    public class SR_Standings
    {
        public StandingsLeague League { get; set; }
        public StandingsSeason Season { get; set; }
        public List<StandingsConference> Conferences { get; set; }
    }
}

namespace NBAStatParty.Models.SR_Standings
{
    public class StandingsTeam
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public float Win_Pct { get; set; }
        public float Points_For { get; set; }
        public float Points_Against { get; set; }
        public float Point_Diff { get; set; }
        public StandingsGamesBehind Games_Behind { get; set; }
        public StandingsRank Calc_Rank { get; set; }
        public List<StandingsRecord> Records { get; set; }
    }
}

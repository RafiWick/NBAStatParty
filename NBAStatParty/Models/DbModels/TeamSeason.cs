using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class TeamSeason
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Season Season { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public float Win_Pct { get; set; }
        public float Points_For { get; set; }
        public float Points_Against { get; set; }
        public float Point_Diff { get; set; }
        public GamesBehind Games_Behind { get; set; }
        public Rank Calc_Rank { get; set; }
        public List<Record> Records { get; set; }

    }
}

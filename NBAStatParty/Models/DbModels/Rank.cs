using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class Rank
    {
        public int Id { get; set; }
        public int DivRank { get; set; }
        public int ConfRank { get; set; }

        public Rank()
        {

        }

        public Rank(StandingsRank input)
        {
            DivRank = input.Div_Rank;
            ConfRank = input.Conf_Rank;
        }
    }
}

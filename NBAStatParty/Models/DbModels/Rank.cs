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

        public Rank(SR_Standings.Rank input)
        {
            DivRank = input.Div_Rank;
            ConfRank = input.Conf_Rank;
        }
    }
}

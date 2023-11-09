
namespace NBAStatParty.Models.DbModels
{
    public class Record
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public float WinPct { get; set; }

        public Record()
        {

        }

        public Record(SR_Standings.Record input)
        {
            Type = input.Record_Type;
            Wins = input.Wins;
            Losses = input.Losses;
            WinPct = input.Win_Pct;
        }
    }
}

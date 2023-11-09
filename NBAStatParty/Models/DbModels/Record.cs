using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class Record
    {
        public int Id { get; set; }
        public string RecordType { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public float WinPct { get; set; }

        public Record()
        {

        }

        public Record(StandingsRecord input)
        {
            RecordType = input.Record_Type;
            Wins = input.Wins;
            Losses = input.Losses;
            WinPct = input.Win_Pct;
        }
    }
}

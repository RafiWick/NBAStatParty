namespace NBAStatParty.Models.DbModels
{
    public class Record
    {
        public int Id { get; set; }
        public string Record_Type { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public float Win_Pct { get; set; }
    }
}

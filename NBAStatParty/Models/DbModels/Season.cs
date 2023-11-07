namespace NBAStatParty.Models.DbModels
{
    public class Season
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public League League { get; set; }

    }
}

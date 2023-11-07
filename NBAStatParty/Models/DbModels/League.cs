namespace NBAStatParty.Models.DbModels
{
    public class League
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Conference> Conferences { get; set; } = new List<Conference>();
        public List<Season> Seasons { get; set; }
    }
}

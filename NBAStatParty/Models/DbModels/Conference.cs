namespace NBAStatParty.Models.DbModels
{
    public class Conference
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Division> Divisions { get; set; } = new List<Division>();
        public League League { get; set; }
    }
}

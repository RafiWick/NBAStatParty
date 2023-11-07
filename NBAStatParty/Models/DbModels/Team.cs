namespace NBAStatParty.Models.DbModels
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }
        public List<TeamSeason> Seasons { get; set; }
        public Division Division { get; set; }
    }
}

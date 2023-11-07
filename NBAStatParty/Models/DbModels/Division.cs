using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class Division
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Team> Teams { get; set; }
        public Conference Conference { get; set; }
    }
}

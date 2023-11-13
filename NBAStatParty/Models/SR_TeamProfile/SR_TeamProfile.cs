namespace NBAStatParty.Models.SR_TeamProfile
{
    public class SR_TeamProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }
        public string Alias { get; set; }
        public int Founded { get; set; }
        public Venue Venue { get; set; }
        public League League { get; set; }
        public Conference Conference { get; set; }
        public Division Division { get; set; }
        public List<Coach> Coaches { get; set; }
        public List<Color> Team_Colors { get; set; }
        public List<Player> Players { get; set; }


    }
}

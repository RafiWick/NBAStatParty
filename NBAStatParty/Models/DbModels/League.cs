namespace NBAStatParty.Models.DbModels
{
    public class League
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Conference> Conferences { get; set; } = new List<Conference>();
        public List<Season> Seasons { get; set; } = new List<Season>();

        public League()
        {

        }

        public League(SR_Standings.SR_Standings input)
        {
            Id = input.League.Id;
            Name = input.League.Name;
            Alias = input.League.Alias;

            foreach(var conference in input.Conferences)
            {
                var newConference = new Conference(conference);
                Conferences.Add(newConference);
            }
        }
    }
}

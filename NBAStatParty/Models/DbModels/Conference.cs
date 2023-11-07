using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class Conference
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public List<Division> Divisions { get; set; } = new List<Division>();
        public League League { get; set; }

        public Conference()
        {

        }

        public Conference(StandingsConference conference)
        {
            Id = conference.Id;
            Name = conference.Name;
            Alias = conference.Alias;

            foreach(var division in conference.Divisions)
            {
                var newDivision = new Division(division);
                Divisions.Add(newDivision);
            }
        }
    }
}

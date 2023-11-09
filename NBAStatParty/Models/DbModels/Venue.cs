namespace NBAStatParty.Models.DbModels
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public Location Location { get; set; }

        public List<Team> Teams { get; set; }

        public Venue()
        {

        }

        public Venue(SR_TeamProfile.Venue input)
        {
            Id = input.Id;
            Name = input.Name;
            Capacity = input.Capacity;
            Address = input.Address;
            City = input.City;
            State = input.State;
            Zip = input.Zip;
            Country = input.Country;
            Location = new Location(input.Location);
        }
    }
}

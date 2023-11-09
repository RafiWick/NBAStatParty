namespace NBAStatParty.Models.SR_TeamProfile
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




    }
}

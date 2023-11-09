namespace NBAStatParty.Models.DbModels
{
    public class Location
    {
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

        public Location()
        {

        }
        public Location(SR_TeamProfile.Location input)
        {
            Lat = input.Lat;
            Lng = input.Lng;
        }
    }
}
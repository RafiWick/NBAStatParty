namespace NBAStatParty.Models.DbModels
{
    public class Coach
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string? Experience { get; set; }

        
        public Coach()
        {

        }

        public Coach(SR_TeamProfile.Coach input)
        {
            Id = input.Id;
            FullName = input.Full_Name;
            FirstName = input.First_Name;
            LastName = input.Last_Name;
            Position = input.Position;
            Experience = input.Experience;
        }
    }
}
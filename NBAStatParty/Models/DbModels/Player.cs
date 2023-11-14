namespace NBAStatParty.Models.DbModels
{
    public class Player
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Status { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AbbrName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Position { get; set; }
        public string PrimaryPosition { get; set; }
        public string Number { get; set; }
        public string Experience { get; set; }
        public string? College { get; set; }
        public string? HighSchool { get; set; }
        public string BirthPlace { get; set; }
        public string Birthdate { get; set; }
        public int RookieYear { get; set; }
        public PlayerDraft? Draft { get; set; }

        public Player()
        {

        }

        public Player(SR_TeamProfile.Player input, string teamId)
        {
            Id = input.Id;
            TeamId = teamId;
            Status = input.Status;
            FullName = input.Full_Name;
            FirstName = input.First_Name;
            LastName = input.Last_Name;
            AbbrName = input.Abbr_Name;
            Height = input.Height;
            Weight = input.Weight;
            Position = input.Position;
            PrimaryPosition = input.Primary_Position;
            Number = input.Jersey_Number;
            if(input.Jersey_Number == null)
            {
                Number = " ";
            }
            Experience = input.Experience;
            College = input.College;
            HighSchool = input.High_School;
            BirthPlace = input.Birth_Place;
            Birthdate = input.Birthdate;
            RookieYear = input.Rookie_Year;
            if (input.Draft != null)
            {
                Draft = new PlayerDraft(input.Draft);
            }

        }

        public string HeightString()
        {
            return $"{Height/12}' {Height%12}\"";
        }
}
}
namespace NBAStatParty.Models.DbModels
{
    public class PlayerDraft
    {
        public int Id { get; set; }
        public string? TeamId { get; set; }
        public int Year { get; set; }
        public string? Round { get; set; }
        public string? Pick { get; set; }

        public PlayerDraft()
        {

        }
        public PlayerDraft(SR_TeamProfile.Draft input)
        {
            TeamId = input.Team_Id;
            Year = input.Year;
            Round = input.Round;
            Pick = input.Pick;
        }
    }
}
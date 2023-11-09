namespace NBAStatParty.Models.DbModels
{
    public class RGB
    {
        public int Id { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public RGB()
        {

        }
        public RGB(SR_TeamProfile.Rgb_Color input)
        {
            R = input.Red;
            G = input.Green;
            B = input.Blue;
        }
    }
}
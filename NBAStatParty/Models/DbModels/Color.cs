namespace NBAStatParty.Models.DbModels
{
    public class Color
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Hex { get; set; }
        public RGB RGB { get; set; }

        public Color()
        {

        }
        public Color(SR_TeamProfile.Color input)
        {
            Type = input.Type;
            Hex = input.Hex_Color;
            RGB = new RGB(input.Rgb_Color);
        }
    }
}
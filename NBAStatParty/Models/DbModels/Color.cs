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

        public string Up()
        {
            var r = RGB.R + 5;
            var g = RGB.G + 5;
            var b = RGB.B + 5;
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;
            var R = Convert.ToString(r, 16);
            var G = Convert.ToString(g, 16);
            var B = Convert.ToString(b, 16);
            if (R.Length == 1) R = "0" + R;
            if (G.Length == 1) G = "0" + G;
            if (B.Length == 1) B = "0" + B;
            return $"#{R}{G}{B}";
        }

        public string Down()
        {
            var r = RGB.R - 5;
            var g = RGB.G - 5;
            var b = RGB.B - 5;
            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;
            var R = Convert.ToString(r, 16);
            var G = Convert.ToString(g, 16);
            var B = Convert.ToString(b, 16);
            if (R.Length == 1) R = "0" + R;
            if (G.Length == 1) G = "0" + G;
            if (B.Length == 1) B = "0" + B;
            return $"#{R}{G}{B}";
        }
    }
}
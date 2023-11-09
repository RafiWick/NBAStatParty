using NBAStatParty.Models.SR_Standings;

namespace NBAStatParty.Models.DbModels
{
    public class GamesBehind
    {
        public int Id { get; set; }

        public double League { get; set; }
        public double Conference { get; set; }
        public double Division { get; set; }

        public GamesBehind()
        {

        }

        public GamesBehind(StandingsGamesBehind input)
        {
            League = input.League;
            Conference = input.Conference;
            Division = input.Division;
        }
    }
}

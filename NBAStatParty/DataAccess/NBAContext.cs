using Microsoft.EntityFrameworkCore;
using NBAStatParty.Models.DbModels;

namespace NBAStatParty.DataAccess
{
    public class NBAContext : DbContext
    {
        public DbSet<Season> Seasons { get; set; }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }
        
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Venue> Venues { get; set; }

        public DbSet<TeamSeason> TeamSeasons { get; set; }

        public DbSet<GamesBehind> GamesBehinds { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Record> Records { get; set; }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PlayerDraft> PlayerDrafts { get; set; }
        public DbSet<RGB> RGBs { get; set; }



        public NBAContext(DbContextOptions<NBAContext> options) : base(options)
        {

        }
    }
}

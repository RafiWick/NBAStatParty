using Microsoft.EntityFrameworkCore;
using NBAStatParty.DataAccess;
using NBAStatParty.Models.DbModels;
using StackExchange.Redis;

namespace NBAStatParty.Models
{
    public class LiveGame
    {
        public string Channel { get; set; }
        public Team Home { get; set; }
        public Team Away { get; set; }
        public Stack<StreamEntry> Entries { get; set; } = new Stack<StreamEntry>();

        public LiveGame(StreamEntry entry, NBAContext context)
        {
            Channel = entry["channel"];
            Home = context.Teams.Include(t => t.Colors).ThenInclude(c => c.RGB).FirstOrDefault(t => t.Id == entry["home"].ToString());
            Away = context.Teams.Include(t => t.Colors).ThenInclude(c => c.RGB).FirstOrDefault(t => t.Id == entry["away"].ToString());
        }
        
    }
}

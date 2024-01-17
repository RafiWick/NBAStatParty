using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;
using NBAStatParty.Models;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text.Json.Nodes;

namespace NBAStatParty.Controllers
{
    public class LiveGamesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly INBAApiService _NBAApiService;
        private readonly NBAContext _context;
        private readonly IDatabase _db;

        public LiveGamesController(ILogger<HomeController> logger, IConfiguration configuration,
            INBAApiService NBAApiService, NBAContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _NBAApiService = NBAApiService;
            _context = context;

            var options = new ConfigurationOptions
            {
                EndPoints = { configuration["REDIS_ENDPOINT"] },
                User = "default",
                Password = configuration["REDIS_PASSWORD"],
                AbortOnConnectFail = false
            };

            // initalize a multiplexer with ConnectionMultiplexer.Connect()
            var muxer = ConnectionMultiplexer.Connect(options);

            // get an IDatabase here with GetDatabase
            _db = muxer.GetDatabase();
        }

        [Route("/livegames")]
        public async Task<IActionResult> Index()
        {
            
            
            var gameUpdates = await FindGames();
            var liveGames = await GetPlayByPlay(gameUpdates, new List<string>());
            

            
            var favoriteTeam = _context.Teams.Include(t => t.Colors).ThenInclude(c => c.RGB)
                .FirstOrDefault(t => t.Id == _context.Favorites.OrderByDescending(f => f.Rating).FirstOrDefault(t => t.Type == "TEAM").FavoriteId);

            if (favoriteTeam != null)
            {
                if (favoriteTeam.Colors.Any())
                {
                    ViewData["BackgroundColor"] = favoriteTeam.Colors.FirstOrDefault(c => c.Type == "primary").Hex;
                    ViewData["TextColor"] = favoriteTeam.Colors.FirstOrDefault(c => c.Type == "secondary").Hex;
                    ViewData["TableUpColor"] = favoriteTeam.Colors.FirstOrDefault(c => c.Type == "primary").Up();
                    ViewData["TableDownColor"] = favoriteTeam.Colors.FirstOrDefault(c => c.Type == "primary").Down();
                }
                else
                {
                    ViewData["BackgroundColor"] = "#FFFFFF";
                    ViewData["TextColor"] = "#000000";
                    ViewData["TableUpColor"] = "#FFFFFF";
                    ViewData["TableDownColor"] = "#F9F9F9";
                }
            }
            else
            {
                ViewData["BackgroundColor"] = "#FFFFFF";
                ViewData["TextColor"] = "#000000";
                ViewData["TableUpColor"] = "#FFFFFF";
                ViewData["TableDownColor"] = "#F9F9F9";
            }

            return View(liveGames);
        }

        public async Task<List<StreamEntry>> FindGames()
        {
            var positions = new Dictionary<RedisKey, StreamPosition>();
            foreach (string team in _context.Favorites.Where(f => f.Type == "TEAM").Select(f => f.FavoriteId))
            {
                positions.Add("streams:liveGames:team:" + team, new StreamPosition("streams:liveGames:team:" + team, "0-0"));
            }

            var returnList = new List<StreamEntry>();
            while (true)
            {
                var readResults = await _db.StreamReadAsync(positions.Values.ToArray(), countPerStream: 1);
                if (!readResults.Any(x => x.Entries.Any()))
                {
                    break;
                }
                foreach (var stream in readResults)
                {
                    foreach (var entry in stream.Entries)
                    {
                        returnList.Add(entry);
                        positions[stream.Key!] = new StreamPosition(stream.Key, entry.Id);
                    }
                }
            }
            

            return returnList;
        }
        public async Task<Dictionary<string, LiveGame>> GetPlayByPlay(List<StreamEntry> gameUpdates, List<string> oldEvents)
        {
            var liveGames = new Dictionary<string, LiveGame>();
            foreach (var update in gameUpdates)
            {
                if (update["status"] == "inprogress")
                {
                    if (!liveGames.Keys.ToList().Contains(update["channel"]))
                    {
                        liveGames.Add(update["channel"], new LiveGame(update, _context));
                    }
                }
            }
            var positions = new Dictionary<RedisKey, StreamPosition>();
            foreach (string channel in liveGames.Values.Select(g => g.Channel))
            {
                positions.Add(channel, new StreamPosition(channel, "0-0"));
            }
            while (positions.Any())
            {
                var readResults = await _db.StreamReadAsync(positions.Values.ToArray());
                if (!readResults.Any(x => x.Entries.Any()))
                {
                    break;
                }
                foreach (var stream in readResults)
                {
                    foreach (var entry in stream.Entries)
                    {
                        if (!oldEvents.Contains(entry["id"]))
                        {
                            liveGames[stream.Key].Entries.Push(entry);
                        }
                        positions[stream.Key!] = new StreamPosition(stream.Key, entry.Id);
                    }
                }
            }
            return liveGames;
        }
        [HttpPost]
        [Route("/livegames/update")]
        public async Task<string> Update()
        {

            var games = await FindGames();
            var reader = new StreamReader(Request.Body);
            
            var oldEvents = await reader.ReadToEndAsync();
            var events = await GetPlayByPlay(games, JsonConvert.DeserializeObject<List<string>>(oldEvents));
            var jsonEvents = JsonConvert.SerializeObject(events);
            return jsonEvents;
        }
    }
}

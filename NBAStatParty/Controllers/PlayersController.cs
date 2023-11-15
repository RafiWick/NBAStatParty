using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;
using NBAStatParty.Models.DbModels;
using NBAStatParty.Services;

namespace NBAStatParty.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly INBAApiService _NBAApiService;
        private readonly NBAContext _context;


        public PlayersController(IConfiguration configuration,
            INBAApiService NBAApiService, NBAContext context)
        {
            _configuration = configuration;
            _NBAApiService = NBAApiService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/players")]
        public async Task<IActionResult> Show(string? id)
        {
            var player = _context.Players.Include(p => p.Draft).FirstOrDefault(p => p.Id == id);
            var team = _context.Teams.Include(t => t.Colors).ThenInclude(c => c.RGB).FirstOrDefault(t => t.Id == player.TeamId);
            var draftedBy = new Team();
            if(player.Draft != null)
            {
                draftedBy = _context.Teams.Find(player.Draft.TeamId);
            }
            var apiKey = "";
            if (team.LeagueAlias.ToLower() == "nba") apiKey = _configuration["NBA_SPORTRADAR_APIKEY"];
            else apiKey = _configuration["WNBA_SPORTRADAR_APIKEY"];
            var playerData = await (_NBAApiService as NBAApiService).GetPlayerProfile(id, apiKey, team.LeagueAlias.ToLower());
            ViewData["CurrentTeam"] = $"{team.Market} {team.Name}";
            ViewData["TeamId"] = team.Id;
            if (player.Draft != null)
            {
                if (player.Draft.TeamId != null)
                {
                    ViewData["DraftedBy"] = draftedBy.Alias;
                }
            }   
            if (team.Colors.Any()){
                ViewData["BackgroundColor"] = team.Colors.FirstOrDefault(c => c.Type == "primary").Hex;
                ViewData["TextColor"] = team.Colors.FirstOrDefault(c => c.Type == "secondary").Hex;
                ViewData["TableUpColor"] = team.Colors.FirstOrDefault(c => c.Type == "primary").Up();
                ViewData["TableDownColor"] = team.Colors.FirstOrDefault(c => c.Type == "primary").Down();
            }
            else
            {
                ViewData["BackgroundColor"] = "#FFFFFF";
                ViewData["TextColor"] = "#000000";
                ViewData["TableUpColor"] = "#FFFFFF";
                ViewData["TableDownColor"] = "#F9F9F9";
            }
            ViewData["PlayerData"] = playerData;
            ViewData["Favorites"] = _context.Favorites.Select(f => f.FavoriteId).ToList();



            return View(player);
        }
        [Route("/players/search")]
        public IActionResult Search(string Name)
        {
            ViewData["Search"] = Name;
            var players = _context.Players.Where(p => p.FullName.ToLower().Contains(Name.ToLower())).ToList();



            var favoriteTeam = _context.Teams.Include(t => t.Colors).ThenInclude(c => c.RGB)
                .FirstOrDefault(t => t.Id == _context.Favorites.OrderByDescending(f => f.Rating).FirstOrDefault(t => t.Type == "TEAM").FavoriteId);

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

            return View(players);
        }

        [HttpPost]
        [Route("players/addfavorite")]
        public IActionResult AddFavorite(string? id)
        {
            var favorite = new Favorite("PLAYER", id);
            _context.Favorites.Add(favorite);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("players/removefavorite")]
        public IActionResult RemoveFavorite(string? id)
        {
            var favorite = _context.Favorites.FirstOrDefault(f => f.FavoriteId == id);
            _context.Favorites.Remove(favorite);
            _context.SaveChanges();
            return Ok();
        }
    }
}

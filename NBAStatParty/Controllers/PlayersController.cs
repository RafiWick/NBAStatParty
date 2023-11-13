using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;

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
            var draftedBy = _context.Teams.Find(player.Draft.TeamId);
            var playerData = await _NBAApiService.GetPlayerProfile(id, _configuration["NBA_SPORTRADAR_APIKEY"]);
            ViewData["CurrentTeam"] = $"{team.Market} {team.Name}";
            if (player.Draft.TeamId != null)
            {
                ViewData["DraftedBy"] = draftedBy.Alias;
            }
            ViewData["BackgroundColor"] = team.Colors.FirstOrDefault(c => c.Type == "primary").Hex;
            ViewData["TextColor"] = team.Colors.FirstOrDefault(c => c.Type == "secondary").Hex;
            ViewData["PlayerData"] = playerData;
            ViewData["TableUpColor"] = team.Colors.FirstOrDefault(c => c.Type == "primary").Up();
            ViewData["TableDownColor"] = team.Colors.FirstOrDefault(c => c.Type == "primary").Down();



            return View(player);
        }
        [Route("/players/search")]
        public IActionResult Search(string Name)
        {
            ViewData["Search"] = Name;
            var players = _context.Players.Where(p => p.FullName.ToLower().Contains(Name.ToLower())).ToList();
            return View(players);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;
using NBAStatParty.Models;
using NBAStatParty.Models.DbModels;
using System.Diagnostics;

namespace NBAStatParty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly INBAApiService _NBAApiService;
        private readonly NBAContext _context;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration,
            INBAApiService NBAApiService, NBAContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _NBAApiService = NBAApiService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (!_context.Leagues.Any(l => l.Id == "4353138d-4c22-4396-95d8-5f587d2df25c"))
            {
                var nba = await CreateNBATeams();
                await Task.Delay(1100);
                await FillNBATeamSeasons(nba);
            }
            if (!_context.Leagues.Any(l => l.Id == "59c24590-0adb-4b3d-80a8-10450f83f4a1"))
            {
                var wnba = await CreateWNBATeams();
                await Task.Delay(1100);
                await FillWNBATeamSeasons(wnba);
            }
            var leagues = _context.Leagues.Include(l => l.Conferences).ThenInclude(c => c.Divisions).ThenInclude(d => d.Teams)
                .Include(l => l.Conferences).ThenInclude(c => c.Teams).ToList();

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


            return View(leagues);
        }


        public async Task<League> CreateNBATeams()
        {
            string apiKey = _configuration["NBA_SPORTRADAR_APIKEY"];
            var result = await _NBAApiService.GetStandings(2022, apiKey, "nba");
            var league = await League.CreateAsync(result, _NBAApiService, apiKey, _context);
            _context.Leagues.Add(league);
            _context.SaveChanges();

            return league;
        }

        public async Task<bool> FillNBATeamSeasons(League league)
        {
            string apiKey = _configuration["NBA_SPORTRADAR_APIKEY"];
            var seasons = new List<int> { 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023 };
            foreach(int year in seasons)
            {
                var result = await _NBAApiService.GetStandings(year, apiKey, "nba");
                var season = new Season(result.Season);
                league.Seasons.Add(season);
                var standingsTeams = new List<Models.SR_Standings.Team>();
                foreach(var conference in result.Conferences)
                {
                    foreach(var division in conference.Divisions)
                    {
                        standingsTeams.AddRange(division.Teams);
                    }
                }

                foreach(var standingsTeam in standingsTeams)
                {
                    var team = _context.Teams.Find(standingsTeam.Id);
                    team.Seasons.Add(new TeamSeason(season, standingsTeam));
                    _context.Teams.Update(team);
                }
                await Task.Delay(1100);
            }
            _context.SaveChanges();
            return true;
        }

        public async Task<League> CreateWNBATeams()
        {
            string apiKey = _configuration["WNBA_SPORTRADAR_APIKEY"];
            var result = await _NBAApiService.GetStandings(2022, apiKey, "wnba");
            var league = await League.CreateAsync(result, _NBAApiService, apiKey, _context);
            _context.Leagues.Add(league);
            _context.SaveChanges();

            return league;
        }

        public async Task<bool> FillWNBATeamSeasons(League league)
        {
            string apiKey = _configuration["WNBA_SPORTRADAR_APIKEY"];
            var seasons = new List<int> { 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023 };
            foreach (int year in seasons)
            {
                var result = await _NBAApiService.GetStandings(year, apiKey, "wnba");
                var season = new Season(result.Season);
                league.Seasons.Add(season);
                var standingsTeams = new List<Models.SR_Standings.Team>();
                foreach (var conference in result.Conferences)
                {
                    standingsTeams.AddRange(conference.Teams);
                }

                foreach (var standingsTeam in standingsTeams)
                {
                    var teams = _context.Teams.ToList();
                    var team = _context.Teams.Find(standingsTeam.Id);
                    if (team != null)
                    {
                        team.Seasons.Add(new TeamSeason(season, standingsTeam));

                        _context.Teams.Update(team);
                    }
                }
                await Task.Delay(1100);
            }
            _context.SaveChanges();
            return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
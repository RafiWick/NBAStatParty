using Microsoft.AspNetCore.Mvc;
using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;
using NBAStatParty.Models;
using NBAStatParty.Models.DbModels;
using NBAStatParty.Models.SR_Standings;
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
            var league = new League();
            if (!_context.Leagues.Any(l => l.Name == "NBA"))
            {
                league = await CreateNBATeams();
                await FillNBATeamSeasons(league);
            }

            return View();
        }


        public async Task<League> CreateNBATeams()
        {
            string apiKey = _configuration["NBA_SPORTRADAR_APIKEY"];
            var result = await _NBAApiService.GetStandings(2022, apiKey);
            var league = new League(result);
            _context.Leagues.Add(league);
            _context.SaveChanges();

            return league;
        }

        public async Task<bool> FillNBATeamSeasons(League league)
        {
            string apiKey = _configuration["NBA_SPORTRADAR_APIKEY"];
            var seasons = new List<int> { 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022 };
            foreach(int year in seasons)
            {
                var result = await _NBAApiService.GetStandings(year, apiKey);
                var season = new Season(result.Season);
                league.Seasons.Add(season);
                var standingsTeams = new List<StandingsTeam>();
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
                Console.WriteLine("pause");
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
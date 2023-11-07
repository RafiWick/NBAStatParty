using Microsoft.AspNetCore.Mvc;
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
            if (!_context.Leagues.Any())
            {
                await CreateNBATeams();
            }

            return View();
        }


        public async Task<bool> CreateNBATeams()
        {
            string apiKey = _configuration["NBA_SPORTRADAR_APIKEY"];
            var result = await _NBAApiService.GetStandings(2022, apiKey);
            var league = new League(result);
            _context.Leagues.Add(league);
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
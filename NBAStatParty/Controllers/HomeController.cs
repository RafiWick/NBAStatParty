using Microsoft.AspNetCore.Mvc;
using NBAStatParty.Interfaces;
using NBAStatParty.Models;
using System.Diagnostics;

namespace NBAStatParty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly INBAApiService _NBAApiService;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, INBAApiService NBAApiService)
        {
            _configuration = configuration;
            _logger = logger;
            _NBAApiService = NBAApiService;
        }

        public async Task<IActionResult> Index()
        {
            string apiKey = _configuration["NBA_SPORTRADAR_APIKEY"];
            var result = await _NBAApiService.GetStandings(2022, apiKey);
            return View();
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
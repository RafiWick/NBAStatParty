using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;
using NBAStatParty.Models.DbModels;

namespace NBAStatParty.Controllers
{
    public class TeamsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly INBAApiService _NBAApiService;
        private readonly NBAContext _context;


        public TeamsController( IConfiguration configuration,
            INBAApiService NBAApiService, NBAContext context)
        {
            _configuration = configuration;
            _NBAApiService = NBAApiService;
            _context = context;
        }

        [Route("/teams")]
        public IActionResult Show(string? id)
        {
            var team = _context.Teams.Include(t => t.Roster)
                .Include(t => t.Colors).ThenInclude(c => c.RGB)
                .Include(t => t.Seasons).ThenInclude(s => s.GamesBehind)
                .Include(t => t.Seasons).ThenInclude(s => s.Ranks)
                .Include(t => t.Seasons).ThenInclude(s => s.Records)
                .FirstOrDefault(t => t.Id == id);

            ViewData["Favorites"] = _context.Favorites.Select(f => f.FavoriteId).ToList();

            return View(team);
        }

        [HttpPost]
        [Route("teams/addfavorite")]
        public IActionResult AddFavorite(string? id)
        {
            var favorite = new Favorite("TEAM", id);
            _context.Favorites.Add(favorite);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("teams/removefavorite")]
        public IActionResult RemoveFavorite(string? id)
        {
            var favorite = _context.Favorites.FirstOrDefault(f => f.FavoriteId == id);
            _context.Favorites.Remove(favorite);
            _context.SaveChanges();
            return Ok();
        }
    }
}

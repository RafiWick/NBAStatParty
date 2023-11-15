using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAStatParty.DataAccess;
using NBAStatParty.Interfaces;

namespace NBAStatParty.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly INBAApiService _NBAApiService;
        private readonly NBAContext _context;


        public FavoritesController(INBAApiService NBAApiService, NBAContext context)
        {
            _NBAApiService = NBAApiService;
            _context = context;
        }

        public IActionResult Index()
        {
            var favorites = _context.Favorites.OrderByDescending(f => f.Rating).ToList();
            var favoritePlayers = _context.Players.Where(p => favorites.Select(f => f.FavoriteId).Contains(p.Id)).ToList();
            var favoriteTeams = _context.Teams.Include(t => t.Colors).Where(t => favorites.Select(f => f.FavoriteId).Contains(t.Id)
                || favoritePlayers.Select(p => p.TeamId).Contains(t.Id)).ToList();
            
            ViewData["FavoriteTeams"] = favoriteTeams;
            ViewData["FavoritePlayers"] = favoritePlayers;
            return View(favorites);
        }

        [HttpPost]
        [Route("/favorites/updaterating")]
        public IActionResult UpdateRating(int rating, string id)
        {
            var favorite = _context.Favorites.FirstOrDefault(f => f.FavoriteId == id);
            favorite.Rating = rating;
            _context.Favorites.Update(favorite);
            _context.SaveChanges();
            return Ok();
        }
    }
}

using Anyar.DAL;
using Anyar.Models;
using Anyar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anyar.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Position> Positions = await _context.Positions.ToListAsync();
            List<Team> Teams = await _context.Teams.ToListAsync();
            HomeVM model = new()
            {
            Positions = Positions,
            Teams = Teams
            };
            return View(model);
        }

    }
}

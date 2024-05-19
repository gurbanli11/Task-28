using Anyar.DAL;
using Anyar.Models;
using Anyar.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Anyar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;
        public PositionController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Position> positions = await _context.Positions.ToListAsync();
            return View(positions);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PositionCreateVM position)
        {
            if (!ModelState.IsValid) return View();
            bool result = await _context.Positions.AnyAsync(x => x.Name.Trim().ToLower() == position.Name.Trim().ToLower());

            if (result)
            {
                ModelState.AddModelError("Name", "This Name Does Exist");
                return View(position);
            }
            PositionCreateVM model = new()
            {
                Name = position.Name
            };
            await _context.Positions.AddAsync(new Position { Name = position.Name });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}

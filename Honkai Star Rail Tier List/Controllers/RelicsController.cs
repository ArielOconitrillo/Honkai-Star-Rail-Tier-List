using Honkai_Star_Rail_Tier_List.Data;
using Microsoft.AspNetCore.Mvc;

namespace Honkai_Star_Rail_Tier_List.Controllers
{
    public class RelicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelicsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var relics = _context.RelicSets.ToList();
            return View(relics);
        }
    }
}

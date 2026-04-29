using Honkai_Star_Rail_Tier_List.Data;
using Microsoft.AspNetCore.Mvc;

namespace Honkai_Star_Rail_Tier_List.Controllers
{
    public class LightConesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LightConesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lightCones = _context.LightCones.ToList();
            return View(lightCones);
        }
    }
}

using Honkai_Star_Rail_Tier_List.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Honkai_Star_Rail_Tier_List.Data;
using Microsoft.EntityFrameworkCore;

namespace Honkai_Star_Rail_Tier_List.Controllers
{

    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        } 

        public IActionResult Details(string name)
        {
            var character = _context.Characters
                .Include(c => c.Skills)
                    .ThenInclude(s => s.LevelValue)
                .FirstOrDefault(c => c.Name == name);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }
    }
}

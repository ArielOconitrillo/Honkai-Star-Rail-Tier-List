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
                .Include(c => c.Eidolons)
                .Include(c => c.Strengths)
                .Include(c => c.Weaknesss)
                .Include(c => c.Builds)
                    .ThenInclude(b => b.RelicSets)
                        .ThenInclude(rs => rs.RelicSet1)
                .Include(c => c.Builds)
                    .ThenInclude(b => b.RelicSets)
                        .ThenInclude(rs => rs.RelicSet2)
                .Include(c => c.Builds)
                    .ThenInclude (b => b.BuildStats)
                .Include(c => c.Builds)
                    .ThenInclude(l => l.LightCones)
                        .ThenInclude(lc => lc.LightCone)
                .FirstOrDefault(c => c.Name == name);

            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }
    }
}

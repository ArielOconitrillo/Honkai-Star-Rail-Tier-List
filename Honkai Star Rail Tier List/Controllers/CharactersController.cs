using Honkai_Star_Rail_Tier_List.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Honkai_Star_Rail_Tier_List.Data;
using Microsoft.EntityFrameworkCore;

namespace Honkai_Star_Rail_Tier_List.Controllers
{
    [Route("Characters")]
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var characters = _context.Characters.ToList();
            return View(characters);
        }

        [HttpGet("{slug}")]
        public IActionResult Details(string slug)
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
                .Include(c => c.CharacterTeams)
                    .ThenInclude(ct => ct.Team)
                        .ThenInclude(t => t.TeamMembers)
                            .ThenInclude(tm => tm.Character)
                .Include (c => c.Companions)
                    .ThenInclude(co => co.Skills)
                        .ThenInclude(s => s.LevelValue)
                .Include(c => c.CharacterGuide)
                .FirstOrDefault(c => c.Slug == slug);

            if (character == null)
            {
                return NotFound();
            }

            character.CharacterGuide ??= new CharacterGuide();

            return View(character);
        }
    }
}

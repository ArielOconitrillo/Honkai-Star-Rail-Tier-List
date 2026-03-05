using Honkai_Star_Rail_Tier_List.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Honkai_Star_Rail_Tier_List.Controllers
{
    public class CharacterController : Controller
    {
            public IActionResult Details(string name)
            {
                if (string.IsNullOrEmpty(name))
                {
                    return NotFound();
                }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data/characters.json");
            var json = System.IO.File.ReadAllText(path);

            var characters = JsonSerializer.Deserialize<List<Character>>(json) ?? new List<Character>();

                var character = characters.FirstOrDefault(c => c.Name != null &&
                                                               c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (character == null)
                {
                    return NotFound();
                }

                return View(character);
            }
        }
}

using System.ComponentModel.DataAnnotations;

namespace Honkai_Star_Rail_Tier_List.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Element { get; set; }

        public string Path { get; set; }

        public string Role { get; set; }

        public int Rarity { get; set; }

        public string TierMOC { get; set; }

        public string TierAS { get; set; }

        public string TierPF { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Eidolon> Eidolons { get; set; }

        public List<Strength> Strengths { get; set; }

        public List<Weakness> Weaknesss { get; set; }

        public List<Build> Builds { get; set; }
        
        public List<CharacterTeam> CharacterTeams { get; set; }

        public List<Companion> Companions { get; set; }

        public CharacterGuide CharacterGuide { get; set; }
    }
}
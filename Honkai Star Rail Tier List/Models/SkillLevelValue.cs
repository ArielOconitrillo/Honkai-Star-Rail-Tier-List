using Honkai_Star_Rail_Tier_List.Models.Enums;

namespace Honkai_Star_Rail_Tier_List.Models
{
    public class SkillLevelValue
    {
        public int Id { get; set; }

        public int SkillId { get; set; }

        public int Level { get; set; }

        public SkillStatType StatType { get; set; }

        public double Value { get; set; }

        public Skill Skill { get; set; }
    }
}

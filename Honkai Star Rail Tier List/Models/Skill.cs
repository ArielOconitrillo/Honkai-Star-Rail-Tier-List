namespace Honkai_Star_Rail_Tier_List.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public int? CharacterId { get; set; }
        public int? CompanionId { get; set; }

        public string SkillType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int MaxLevel {  get; set; }

        public Character Character { get; set; }
        public Companion Companion { get; set; }

        public List<SkillLevelValue> LevelValue { get; set; }
    }
}

namespace Honkai_Star_Rail_Tier_List.Models
{
    public class CharacterGuide
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string Review { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public Character Character { get; set; }
    }
}

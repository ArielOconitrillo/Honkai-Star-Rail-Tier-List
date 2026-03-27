namespace Honkai_Star_Rail_Tier_List.Models
{
    public class Companion
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; }
        public string Image {  get; set; } 
        public Character Character { get; set; }
        public List<Skill> Skills { get; set; }
    }
}

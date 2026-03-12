namespace Honkai_Star_Rail_Tier_List.Models
{
    public class Eidolon
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }

        public int Level { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Character Character { get; set; }
    }
}

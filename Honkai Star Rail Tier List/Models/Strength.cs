namespace Honkai_Star_Rail_Tier_List.Models
{
    public class Strength
    {
        public int Id { get; set; }

        public int CharacterID { get; set; }

        public string Description { get; set; }

        public Character Character { get; set; }
    }
}

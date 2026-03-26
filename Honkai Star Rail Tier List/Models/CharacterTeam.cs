namespace Honkai_Star_Rail_Tier_List.Models
{
    public class CharacterTeam
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int TeamId { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public Character Character { get; set; }
        public Team Team { get; set; }
    }
}

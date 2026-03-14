namespace Honkai_Star_Rail_Tier_List.Models
{
    public class BuildRelicSet
    {
        public int Id { get; set; }

        public int BuildId { get; set; }

        public int Rank { get; set; }

        public int RelicSet1Id { get; set; }

        public int RelicSet2Id { get; set; }

        public string Description { get; set; }

        public Build Build { get; set; }

        public RelicSet RelicSet1 { get; set; }

        public RelicSet RelicSet2 { get; set; }
    }
}

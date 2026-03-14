namespace Honkai_Star_Rail_Tier_List.Models
{
    public class Build
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Character Character { get; set; }

        public List<BuildRelicSet> RelicSets { get; set; }

        //public List<BuildLightCone> LightCones { get; set; }
    }
}

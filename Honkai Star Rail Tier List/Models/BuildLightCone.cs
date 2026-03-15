namespace Honkai_Star_Rail_Tier_List.Models
{
    public class BuildLightCone
    {
        public int Id { get; set; }

        public int BuildId { get; set; }

        public int Rank { get; set; }

        public int LightConeId { get; set; }

        public string Description { get; set; }

        public Build Build { get; set; }

        public LightCone LightCone { get; set; }
    }
}

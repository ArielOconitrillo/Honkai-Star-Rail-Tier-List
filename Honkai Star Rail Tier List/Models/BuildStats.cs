namespace Honkai_Star_Rail_Tier_List.Models
{
    public class BuildStats
    {
        public int Id { get; set; }

        public int BuildId { get; set; }

        public string Body { get; set; }

        public string Feet { get; set; }

        public string SubstatPriority { get; set; }

        public Build Build { get; set; }
    }
}

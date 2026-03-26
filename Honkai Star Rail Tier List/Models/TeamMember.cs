using Honkai_Star_Rail_Tier_List.Models.Enums;

namespace Honkai_Star_Rail_Tier_List.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int CharacterId { get; set; }

        public int Order { get; set; }

        public TeamRole Role { get; set; }

        public Team Team { get; set; }

        public Character Character { get; set; }
    }
}

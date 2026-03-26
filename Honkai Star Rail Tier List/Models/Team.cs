namespace Honkai_Star_Rail_Tier_List.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Honkai_Star_Rail_Tier_List.Models.Enums
{
    public enum TeamRole
    {
        DPS,
        [Display(Name = "Sub-DPS")]
        SubDPS,
        Support,
        Sustain
    }
}

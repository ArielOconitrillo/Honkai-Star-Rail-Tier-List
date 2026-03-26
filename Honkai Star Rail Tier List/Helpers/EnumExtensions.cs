using System;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Honkai_Star_Rail_Tier_List.Helpers
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field.GetCustomAttribute<DisplayAttribute>();

            return attribute?.Name ?? value.ToString();
        }
    }
}

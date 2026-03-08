using Microsoft.EntityFrameworkCore;
using Honkai_Star_Rail_Tier_List.Models;

namespace Honkai_Star_Rail_Tier_List.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
    }
}
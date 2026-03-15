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
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillLevelValue> SkillValues { get; set; }
        public DbSet<Eidolon> Eidolons { get; set; }
        public DbSet<Strength> Strengths { get; set; }
        public DbSet<Weakness> Weaknesss { get; set; }
        public DbSet<RelicSet> RelicSets { get; set; }
        public DbSet<Build> Builds { get; set; }
        public DbSet<BuildRelicSet> BuildRelicSets { get; set; }
        public DbSet<BuildStats> BuildStats { get; set; }
        public DbSet<LightCone> LightCones { get; set; }
        public DbSet<BuildLightCone> BuildLightCones { get; set; }

        //Charaters should only have one eidolon for each level
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eidolon>()
                .HasIndex(e => new { e.CharacterId, e.Level })
                .IsUnique();

            modelBuilder.Entity<BuildRelicSet>()
                .HasOne(b => b.RelicSet1)
                .WithMany()
                .HasForeignKey(b => b.RelicSet1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuildRelicSet>()
                .HasOne(b => b.RelicSet2)
                .WithMany()
                .HasForeignKey(b => b.RelicSet2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
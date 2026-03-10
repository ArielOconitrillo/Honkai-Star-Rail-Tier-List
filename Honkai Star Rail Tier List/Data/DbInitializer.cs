using Honkai_Star_Rail_Tier_List.Models;

namespace Honkai_Star_Rail_Tier_List.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Characters.Any())
            {
                return;
            }

            var characters = new Character[]
            {
                new Character
                {
                    Name = "Firefly",
                    Element = "Fire",
                    Path = "Destruction",
                    Role = "DPS",
                    Rarity = 5,
                    TierMOC = "S",
                    TierAS = "S",
                    TierPF = "S",
                    Image = "Firefly_profile.webp",
                    Description = "A powerful fire DPS character."
                },

                new Character
                {
                    Name = "Fugue",
                    Element = "Fire",
                    Path = "Nihility",
                    Role = "Support",
                    Rarity = 5,
                    TierMOC = "S",
                    TierAS = "A",
                    TierPF = "A",
                    Image = "Fugue_profile.webp",
                    Description = "An important break team amplifier."
                },

                new Character
                {
                    Name = "Lingsha",
                    Element = "Fire",
                    Path = "Abundance",
                    Role = "Sustain",
                    Rarity = 5,
                    TierMOC = "S",
                    TierAS = "S",
                    TierPF = "S",
                    Image = "Lingsha_profile.webp",
                    Description = "An important break team healer."
                },

                new Character
                {
                    Name = "The Dahlia",
                    Element = "Fire",
                    Path = "Nihility",
                    Role = "Support",
                    Rarity = 5,
                    TierMOC = "A",
                    TierAS = "A",
                    TierPF = "A",
                    Image = "The_Dahlia_profile.webp",
                    Description = "An crucial member of the break team."
                }
            };

            context.Characters.AddRange(characters);
            context.SaveChanges();

            var firefly = context.Characters
                .First(c => c.Name == "Firefly");

            var skills = new Skill[]
            {
            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Basic ATK",
                Name = "Order: Flare Propulsion",
                Description = "Deals Fire DMG equal to {Damage}% of SAM's ATK to a single target enemy.",
                MaxLevel = 7
            },

            new Skill {
                CharacterId = firefly.Id,
                SkillType = "Basic ATK (Enhanced)",
                Name = "Fyrefly Type-IV: Pyrogenic Decimation",
                Description = "Restores HP by an amount equal to 20% of this unit's Max HP. Deals Fire DMG equal to {Damage}% of SAM's ATK to a single target enemy.",
                MaxLevel = 7
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Skill",
                Name = "Order: Aerial Bombardment",
                Description = "Consumes SAM's HP equal to 40% of SAM's Max HP and regenerates a fixed amount of Energy equal to 60% of SAM's Max Energy. Deals Fire DMG equals to {Damage}% of SAM's ATK to a single target enemy. If the current HP is not sufficient, then SAM's HP is reduced to 1 when using this skill. Enables this unit's next Action to be Advanced by 25%.",
                MaxLevel = 12
            },

            new Skill {
                CharacterId= firefly.Id,
                SkillType = "Skill (Enhanced)",
                Name = "Fyrefly Type-IV: Deathstar Overload",
                Description = "Restores HP by an amount equal to 25% of this unit's Max HP. Applies Fire Weakness to a single target enemy, lasting for 2 turn(s). Deals Fire DMG equal to (0.2 x Break Effect + {MainDamage}%) of SAM's ATK to this target. At the same time, deal Fire DMG equal to (0.10 x Break Effect + {AdjacentDamage}%) of SAM's ATK to adjacent targets. The Break Effect taken into the calculation is capped at 360%.",
                MaxLevel= 12
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Ultimate",
                Name = "Fyrefly Type-IV: Complete Combustion",
                Description = "Upon entering the Complete Combustion state, Advances SAM's Action by 100% and gains Enhanced Basic ATK and Enhanced Skill. While in Complete Combustion, increases SPD by {Speed}, and when using the Enhance Basic ATK or Enhance Skill, increases this unit's Weakness Break efficiency by 50% and Break DMG received by enemy targets by {Damage}%, lasting until the current attack ends.\r\n\r\nA countdown timer for the Complete Combustion state appears on the Action Order. When the countdown turn starts, SAM exits Complete Combustion state. The countdown has a fixed SPD of 70.\r\n\r\nSAM cannot use Ultimate while in Complete Combustion.",
                MaxLevel = 12
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Talent",
                Name = "Chrysalid Pyronexus",
                Description = "The lower the HP, the less DMG received. When HP is 20% or lower, the DMG Reduction reaches its maximum effect, reducing up to {DamageReduction}%. During the Complete Combustion, the DMG Reduction remains at its maximum effect, and the Effect RES increases by {EffectRES}%.\r\nIf Energy is lower than 50% when the battle starts, regenerates Energy to 50%. Once Energy is regenerated to its maximum, dispels all debuffs on this unit.",
                MaxLevel = 12
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Technique",
                Name = "Δ Order: Meteoric Incineratoin",
                Description = "Leaps into the air and moves about freely for 5 seconds, which can ended early by launching a plunging attack. When the duration ends, plunges and immediately attacks all enemies within a set area. At the start of each wave, applies a Fire Weakness to all enemies, lasting for 2 turn(s). Then, deals Fire DMG equal to 200% of SAM's ATK to all enemies.",
                MaxLevel = 12
            }
            };

            context.Skills.AddRange(skills);
            context.SaveChanges();
        }
    }
}
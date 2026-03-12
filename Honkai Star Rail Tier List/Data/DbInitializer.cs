using Honkai_Star_Rail_Tier_List.Models;
using Honkai_Star_Rail_Tier_List.Models.Enums;

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
                Description = "Deals Fire DMG equal to <span data-stat=\"Damage\"></span>% of SAM's ATK to a single target enemy.",
                MaxLevel = 7
            },

            new Skill {
                CharacterId = firefly.Id,
                SkillType = "Basic ATK (Enhanced)",
                Name = "Fyrefly Type-IV: Pyrogenic Decimation",
                Description = "Restores HP by an amount equal to 20% of this unit's Max HP. Deals Fire DMG equal to <span data-stat=\"Damage\"></span>% of SAM's ATK to a single target enemy.",
                MaxLevel = 7
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Skill",
                Name = "Order: Aerial Bombardment",
                Description = "Consumes SAM's HP equal to 40% of SAM's Max HP and regenerates a fixed amount of Energy equal to <span data-stat=\"Energy\"></span>% of SAM's Max Energy. Deals Fire DMG equals to <span data-stat=\"Damage\"></span>% of SAM's ATK to a single target enemy. If the current HP is not sufficient, then SAM's HP is reduced to 1 when using this skill. Enables this unit's next Action to be Advanced by 25%.",
                MaxLevel = 12
            },

            new Skill {
                CharacterId= firefly.Id,
                SkillType = "Skill (Enhanced)",
                Name = "Fyrefly Type-IV: Deathstar Overload",
                Description = "Restores HP by an amount equal to 25% of this unit's Max HP. Applies Fire Weakness to a single target enemy, lasting for 2 turn(s). Deals Fire DMG equal to (0.2 x Break Effect + <span data-stat=\"MainDamage\"></span>%) of SAM's ATK to this target. At the same time, deal Fire DMG equal to (0.10 x Break Effect + <span data-stat=\"AdjacentDamage\"></span>%) of SAM's ATK to adjacent targets. The Break Effect taken into the calculation is capped at 360%.",
                MaxLevel= 12
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Ultimate",
                Name = "Fyrefly Type-IV: Complete Combustion",
                Description = "Upon entering the Complete Combustion state, Advances SAM's Action by 100% and gains Enhanced Basic ATK and Enhanced Skill. While in Complete Combustion, increases SPD by <span data-stat=\"Speed\"></span>, and when using the Enhance Basic ATK or Enhance Skill, increases this unit's Weakness Break efficiency by 50% and Break DMG received by enemy targets by <span data-stat=\"Damage\"></span>%, lasting until the current attack ends.\r\n\r\nA countdown timer for the Complete Combustion state appears on the Action Order. When the countdown turn starts, SAM exits Complete Combustion state. The countdown has a fixed SPD of 70.\r\n\r\nSAM cannot use Ultimate while in Complete Combustion.",
                MaxLevel = 12
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Talent",
                Name = "Chrysalid Pyronexus",
                Description = "The lower the HP, the less DMG received. When HP is 20% or lower, the DMG Reduction reaches its maximum effect, reducing up to <span data-stat=\"DamageReduction\"></span>%. During the Complete Combustion, the DMG Reduction remains at its maximum effect, and the Effect RES increases by <span data-stat=\"EffectRES\"></span>%.\r\nIf Energy is lower than 50% when the battle starts, regenerates Energy to 50%. Once Energy is regenerated to its maximum, dispels all debuffs on this unit.",
                MaxLevel = 12
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Technique",
                Name = "Δ Order: Meteoric Incineratoin",
                Description = "Leaps into the air and moves about freely for 5 seconds, which can ended early by launching a plunging attack. When the duration ends, plunges and immediately attacks all enemies within a set area. At the start of each wave, applies a Fire Weakness to all enemies, lasting for 2 turn(s). Then, deals Fire DMG equal to 200% of SAM's ATK to all enemies.",
                MaxLevel = 1
            }
            };

            context.Skills.AddRange(skills);
            context.SaveChanges();

            var skillLevels = new List<SkillLevelValue>();

            //Helper function to add all values of a skill
            void addSkillValues(List<SkillLevelValue> skillsLevels, double[] skillValues, int skillId, SkillStatType type)
            {
                for (int i = 0; i < skillValues.Length; i++) {
                    skillLevels.Add(new SkillLevelValue
                    {
                        SkillId = skillId,
                        Level = i + 1,
                        StatType = type,
                        Value = skillValues[i]
                    });
                }
            };

            // Adding Fireflys skill values

            //Basic Atk
            var skill = context.Skills
                .First(s => s.Name == "Order: Flare Propulsion");

            double[] damageScaling = new double[] {
                50, 60, 70, 80, 90, 100, 110
            };

            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.Damage);

            //Basic Atk (Enhanced)
            damageScaling = new double[] {
                100, 120, 140, 160, 180, 200, 220
            };

            skill = context.Skills.First(s => s.Name == "Fyrefly Type-IV: Pyrogenic Decimation");

            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.Damage);

            // Skill
            double[] energyScaling = new double[] { 50, 51, 52, 53, 54, 54, 56.25, 57.5, 58.75, 60, 61, 62};
            damageScaling = new double[] { 100, 110, 120, 130, 140, 150, 162.5, 175, 187.5, 200, 210, 220};

            skill = context.Skills.First(s => s.Name == "Order: Aerial Bombardment");

            addSkillValues(skillLevels, energyScaling, skill.Id, SkillStatType.Energy);
            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.Damage);

            //Skill (Enhanced)
            double[] mainDamageScaling = new double[] { 100, 110, 120, 130, 140, 150, 162.5, 175, 187.5, 200, 210, 220 };
            double[] adjacentDamageScaling = new double[] { 50, 55, 60, 65, 70, 75, 81.25, 87.5, 93.75, 100, 105, 110 };

            skill = context.Skills.First(s => s.Name == "Fyrefly Type-IV: Deathstar Overload");

            addSkillValues(skillLevels, mainDamageScaling, skill.Id, SkillStatType.MainDamage);
            addSkillValues(skillLevels, adjacentDamageScaling, skill.Id, SkillStatType.AdjacentDamage);

            //Ultimate
            double[] speedScaling = new double[] { 10, 11, 12, 13, 14, 15, 16.25, 17.5, 18.75, 20, 21, 22 };
            damageScaling = new double[] { 30, 33, 36, 39, 42, 45, 48.75, 52.5, 56.25, 60, 63, 66 };

            skill = context.Skills.First(s => s.Name == "Fyrefly Type-IV: Complete Combustion");

            addSkillValues(skillLevels, speedScaling, skill.Id, SkillStatType.Speed);
            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.Damage);

            //Talent
            double[] damageReductionScaling = new double[] { 20, 22, 24, 26, 28, 30, 32.5, 35, 37.5, 40, 42, 44 };
            double[] effectRESScaling = new double[] { 10, 12, 14, 16, 18, 20, 22.5, 25, 27.5, 30, 32, 34 };

            skill = context.Skills.First(s => s.Name == "Chrysalid Pyronexus");

            addSkillValues(skillLevels, damageReductionScaling, skill.Id, SkillStatType.DamageReduction);
            addSkillValues(skillLevels, effectRESScaling, skill.Id, SkillStatType.EffectRES);

            context.SkillValues.AddRange(skillLevels);
            context.SaveChanges();

            //Adding Fireflys eidolons

            var eidolons = new Eidolon[] {
                new Eidolon() { CharacterId = firefly.Id, Level = 1, Name = "In Reddened Chrysalis, I Once Rest", Description = "When using the Enhanced Skill, ignores 15% of the target's DEF. The Enhanced Skill does not consume Skill Points."},
                new Eidolon() { CharacterId = firefly.Id, Level = 2, Name = "From Shattered Sky, I Free Fall", Description = "While in Complete Combustion, using the Enhanced Basic ATK or the Enhanced Skill to defeat an enemy target or to Break their Weakness allows SAM to immediately gain 1 extra turn. This effect can trigger again after 1 turn(s)." },
                new Eidolon() { CharacterId = firefly.Id, Level = 3, Name = "Amidst Silenced Stars, I Deep Sleep", Description = "Skill Lv. +2, up to a maximum of Lv. 15.\r\nBasic ATK Lv. +1, up to a maximum of Lv. 10." },
                new Eidolon() { CharacterId = firefly.Id, Level = 4, Name = "Upon Lighted Fyrefly, I Soon Gaze", Description = "While in Complete Combustion, increases SAM's Effect RES by 50%." }, 
                new Eidolon() { CharacterId = firefly.Id, Level = 5, Name = "From Undreamt Night, I Thence Shine", Description = "Ultimate Lv. +2, up to a maximum of Lv. 15.\r\nTalent Lv. +2, up to a maximum of Lv. 15." },
                new Eidolon() { CharacterId = firefly.Id, Level = 6, Name ="In Finalized Morrow, I Full Bloom", Description = "While in Complete Combustion, increases SAM's Fire RES PEN by 20%. When using the Enhanced Basic ATK or Enhanced Skill, increases Weakness Break Efficiency by 50%." }
            };

            context.Eidolons.AddRange(eidolons);
            context.SaveChanges();

        }
    }
}
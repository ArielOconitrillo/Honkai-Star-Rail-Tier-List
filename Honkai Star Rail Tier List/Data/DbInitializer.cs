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
            double[] energyScaling = new double[] { 50, 51, 52, 53, 54, 54, 56.25, 57.5, 58.75, 60, 61, 62 };
            damageScaling = new double[] { 100, 110, 120, 130, 140, 150, 162.5, 175, 187.5, 200, 210, 220 };

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

            // Adding FireFlys strengths

            var strengths = new Strength[]
            {
                new Strength() {Character = firefly, Description = "Can help keep herself alive with self healing"},
                new Strength() {Character = firefly, Description = "Has plenty of viable team members, including some easily accesable ones"},
                new Strength() {Character = firefly, Description = "Her E1 helps a lot with skill point management, as her enhanced skill no longer consumes them"},
                new Strength() {Character = firefly, Description = "Best girl"}
            };

            context.Strengths.AddRange(strengths);

            // Adding FireFlys weaknesses

            var weaknesses = new Weakness[] {
                new Weakness() {Character = firefly, Description = "Requires a lot of speed to build properly" },
                new Weakness() {Character = firefly, Description = "High speed means she uses a lot of skill points if she doesn't have at least E1" },
                new Weakness() {Character = firefly, Description = "Best support units are all currently limited 5*" },
                new Weakness() {Character = firefly, Description = "Enemies with high toughness take much longer to beat"}
            };

            context.Weaknesss.AddRange(weaknesses);

            // Adding Relics

            var relics = new RelicSet[] {
                new RelicSet() {Name = "Iron Cavalry Against the Scourge", TwoPieceEffect = "Increases Break Effect by 16%.", FourPieceEffect = "If the wearer's Break Effect is 150% or higher, the Break DMG dealt to the enemy target ignores 10% of their DEF. If the wearer's Break Effect is 250% or higher, the Super Break DMG dealt to the enemy target additionally ignores 15% of their DEF.", Image = "Iron_Cavalry_Against_the_Scourge.webp" },
                new RelicSet() {Name = "Thief of Shooting Meteor", TwoPieceEffect = "Increases Break Effect by 16%.", FourPieceEffect = "Increases the wearer's Break Effect by 16%. After the wearer inflicts Weakness Break on an enemy, regenerates 3 Energy.", Image = "Thief_of_Shooting_Meteor.webp" },
                new RelicSet() {Name = "Watchmaker, Master of Dream Machinations", TwoPieceEffect = "Increases Break Effect by 16%.", FourPieceEffect = "When the wearer uses their Ultimate on an ally, all allies' Break Effect increases by 30% for 2 turn(s). This effect cannot be stacked.", Image = "Watchmaker_Master_of_Dream_Machinations.webp"}
            };

            context.RelicSets.AddRange(relics);

            // Adding Fireflys builds

            var builds = new Build[] {
                new Build() {Character = firefly, Name = "Firefly Standard Build", Description = "Fireflys standard build revolves around getting high speed and a lot of break damage to break enemies quickly and defeat them before they can recover" },
                new Build() {Character = firefly, Name = "Firefly Alternative Build", Description = "Don't worry as much about speed, but instead gather as much break damage and attack as you can to beat the enemy in just a few hits" }
            };

            context.Builds.AddRange(builds);
            context.SaveChanges();

            //Adding Fireflys buildRelicSets

            var iron = context.RelicSets.First(r => r.Name == "Iron Cavalry Against the Scourge");
            var tief = context.RelicSets.First(r => r.Name == "Thief of Shooting Meteor");
            var watchmaker = context.RelicSets.First(r => r.Name == "Watchmaker, Master of Dream Machinations");

            var build1 = context.Builds.First(b => b.Name == "Firefly Standard Build");
            var build2 = context.Builds.First(b => b.Name == "Firefly Alternative Build");

            var buildRelicSets = new BuildRelicSet[] {
                new BuildRelicSet() {Build = build1, Rank = 1, RelicSet1 = iron, RelicSet2 = iron, Description = "Easily Fireflys best build, as it provides plenty of break damage and defense shred"},
                new BuildRelicSet() {Build = build1, Rank = 2, RelicSet1 = iron, RelicSet2 = watchmaker, Description = "An alterantive build that trades defense shred for more break damage"},
                new BuildRelicSet() { Build = build2, Rank = 1, RelicSet1 = tief, RelicSet2 = tief, Description = "Gives more Break damage and Energy" }
            };

            context.BuildRelicSets.AddRange(buildRelicSets);
            // Adding Fireflys Build stats

            var stats = new BuildStats[]
            {
                new BuildStats() { Build = build1, Body = "Atk%", Feet = "Speed", SubstatPriority = "Speed > Break Effect% >> ATK%"},
                new BuildStats() { Build = build2, Body = "Break Effect%", Feet = "Atk%", SubstatPriority = "Break Effect% >= ATK% >> Speed" }
            };

            context.BuildStats.AddRange(stats);
            context.SaveChanges();

            //Adding Light Cones

            var lightCones = new LightCone[]
            {
                new LightCone() { Name = "Whereabouts Should Dreams Rest", Rarity = 5, Path = "Destruction", Description = "Increases the wearer's Break Effect by 60/70/80/90/100%. When the wearer deals Break DMG to an enemy target, inflicts Routed on the enemy, lasting for 2 turn(s). Targets afflicted with Routed receive 24/28/32/36/40% increased Break DMG from the wearer, and their SPD is lowered by 20%. Effects of the similar type cannot be stacked.", Obtain = "Limited Warp", Image = "Whereabouts_Should_Dreams_Rest.webp" },
                new LightCone() { Name = "Thus Burns the Dawn", Rarity = 5, Path = "Destruction", Description = "The wearer's base SPD increases by 12/14/16/18/20. When the wearer deals DMG, ignores 18/22/27/31/36% of the target's DEF. After the wearer uses Ultimate, obtains \"Blazing Sun,\" which is removed at the start of their turn. While \"Blazing Sun\" is in possession, increases the wearer's DMG dealt by 60/78/96/114/132%.", Obtain = "Limited Warp", Image = "Thus_Burns_the_Dawn.webp"},
                new LightCone() { Name = "On the Fall of an Aeon", Rarity = 5, Path = "Destruction", Description = "Whenever the wearer attacks, their ATK is increased by 8/10/12/14/16% in this battle, up to 4 times. When the wearer inflicts Weakness Break on enemies, the wearer's DMG increases by 12/15/18/21/24% for 2 turn(s).", Obtain = "Herta's Shop", Image = "On_the_Fall_of_an_Aeon.webp"},
                new LightCone() { Name = "Indelible Promise", Rarity = 4, Path = "Destruction", Description = "Increases the wearer's Break Effect by 28/35/42/49/56%. When the wearer uses their Ultimate, increases CRIT Rate by 15/18.75/22.5/26.25/30%, lasting for 2 turns.", Obtain = "Stellar Warp or Event Warp", Image = "Light_Cone_Indelible_Promise.webp"}
            };

            context.LightCones.AddRange(lightCones);
            context.SaveChanges();

            // Adding build light cones
            LightCone lightCone = context.LightCones.First(lc => lc.Name == "Whereabouts Should Dreams Rest");
            LightCone lightCone2 = context.LightCones.First(lc => lc.Name == "Thus Burns the Dawn");
            LightCone lightCone3 = context.LightCones.First(lc => lc.Name == "On the Fall of an Aeon");
            LightCone lightCone4 = context.LightCones.First(lc => lc.Name == "Indelible Promise");

            var buildLightCones = new BuildLightCone[] {
                new BuildLightCone() { Build = build1, Rank = 1, LightCone = lightCone, Description = "Firefly's signature light cone is her best performing Light Cone, as it gives her a lot of break damage and applies a debuff to enemies causing them to take more break damage and have lower speed, allowing Firefly to attack even more times before her enemies can recover. "},
                new BuildLightCone() { Build = build1, Rank = 2, LightCone = lightCone2, Description = "A very close second. Phainon's signature light cone grants Firefly a nice speed boost and high defense ignore." },
                new BuildLightCone() { Build = build1, Rank = 3, LightCone = lightCone3, Description = "An easily accessible light cone that provides Firefly a good boost to her attack and damage." },
                new BuildLightCone() { Build = build1, Rank = 4, LightCone = lightCone4, Description = "A close alternative to Fall of an Aeon, giving Firefly a nice boost to her break effect. Unfortunately the crit rate boost is useless as Break damage can not crit." },
                new BuildLightCone() { Build = build2, Rank = 1, LightCone = lightCone, Description = "Still her best option, this light cone gives Firefly an incredible amount of break damage." },
                new BuildLightCone() { Build = build2, Rank = 2, LightCone = lightCone4, Description = "Gives Firefly a big boost to her break damage." },
                new BuildLightCone() { Build = build2, Rank = 3, LightCone = lightCone3, Description = "A good boost to Firefly's attack and damage." },
                new BuildLightCone() { Build = build2, Rank = 4, LightCone = lightCone2, Description = "Doesn't offer any break damage or attack boosts, but still give Firefly a great boost to her damage."},
            };

            context.BuildLightCones.AddRange(buildLightCones);
            context.SaveChanges();
        }
    }
}
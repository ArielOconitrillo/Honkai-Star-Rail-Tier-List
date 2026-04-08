using Honkai_Star_Rail_Tier_List.Models;
using Honkai_Star_Rail_Tier_List.Models.Enums;
using Humanizer;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Mono.TextTemplating;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Security.Cryptography.Xml;

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
                },

                new Character {
                    Name = "Harmony Trailblazer",
                    Element = "Imaginary",
                    Path = "Harmony",
                    Role = "Support",
                    Rarity = 5,
                    TierMOC = "A",
                    TierAS = "A",
                    TierPF = "S",
                    Image = "Harmony_Trailblazer.webp",
                    Description = "A great Super Break damage enabler"
                },

                new Character {
                    Name = "Ruan Mei",
                    Element = "Ice",
                    Path = "Harmony",
                    Role = "Support",
                    Rarity = 5,
                    TierMOC = "A",
                    TierAS = "A",
                    TierPF = "B",
                    Image = "Ruan_Mei.webp",
                    Description = "A fantastic damage buffer"
                },

                new Character {
                    Name = "Gallagher",
                    Element = "Fire",
                    Path = "Abundance",
                    Role = "Sustain",
                    Rarity = 4,
                    TierMOC = "F",
                    TierAS = "F",
                    TierPF = "F",
                    Image = "Gallagher_profile.webp",
                    Description = "A good easily obatainable sustainer"
                },

                new Character {
                    Name = "Castorice",
                    Element = "Quantum",
                    Path = "Remembrance",
                    Role = "DPS",
                    Rarity = 5,
                    TierMOC = "S",
                    TierAS = "S",
                    TierPF = "S",
                    Image = "Castorice.webp",
                    Description = "The best Remembrance damage dealer"
                },
                new Character {
                    Name = "Hyacine",
                    Element = "Wind",
                    Path = "Remembrance",
                    Role = "Sustain",
                    Rarity = 5,
                    TierMOC = "S",
                    TierAS = "S",
                    TierPF = "S",
                    Image = "Hyacine.webp",
                    Description = "One of the best healers in the game"
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
                Description = "Deals Fire DMG equal to <span class=\"skill-value\" data-stat=\"Damage\"></span>% of SAM's ATK to a single target enemy.",
                MaxLevel = 7
            },

            new Skill {
                CharacterId = firefly.Id,
                SkillType = "Basic ATK (Enhanced)",
                Name = "Fyrefly Type-IV: Pyrogenic Decimation",
                Description = "Restores HP by an amount equal to 20% of this unit's Max HP. Deals Fire DMG equal to <span class=\"skill-value\" data-stat=\"Damage\"></span>% of SAM's ATK to a single target enemy.",
                MaxLevel = 7
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Skill",
                Name = "Order: Aerial Bombardment",
                Description = "Consumes SAM's HP equal to 40% of SAM's Max HP and regenerates a fixed amount of Energy equal to <span class=\"skill-value\" data-stat=\"Energy\"></span>% of SAM's Max Energy. Deals Fire DMG equals to <span class=\"skill-value\" data-stat=\"Damage\"></span>% of SAM's ATK to a single target enemy. If the current HP is not sufficient, then SAM's HP is reduced to 1 when using this skill. Enables this unit's next Action to be Advanced by 25%.",
                MaxLevel = 12
            },

            new Skill {
                CharacterId= firefly.Id,
                SkillType = "Skill (Enhanced)",
                Name = "Fyrefly Type-IV: Deathstar Overload",
                Description = "Restores HP by an amount equal to 25% of this unit's Max HP. Applies Fire Weakness to a single target enemy, lasting for 2 turn(s). Deals Fire DMG equal to (0.2 x Break Effect + <span class=\"skill-value\" data-stat=\"MainDamage\"></span>%) of SAM's ATK to this target. At the same time, deal Fire DMG equal to (0.10 x Break Effect + <span class=\"skill-value\" data-stat=\"AdjacentDamage\"></span>%) of SAM's ATK to adjacent targets. The Break Effect taken into the calculation is capped at 360%.",
                MaxLevel= 12
            },

            new Skill
            {
                CharacterId = firefly.Id,
                SkillType = "Ultimate",
                Name = "Fyrefly Type-IV: Complete Combustion",
                Description = "Upon entering the Complete Combustion state, Advances SAM's Action by 100% and gains Enhanced Basic ATK and Enhanced Skill. While in Complete Combustion, increases SPD by <span class=\"skill-value\" data-stat=\"Speed\"></span>, and when using the Enhance Basic ATK or Enhance Skill, increases this unit's Weakness Break efficiency by 50% and Break DMG received by enemy targets by <span class=\"skill-value\" data-stat=\"Damage\"></span>%, lasting until the current attack ends.\r\n\r\nA countdown timer for the Complete Combustion state appears on the Action Order. When the countdown turn starts, SAM exits Complete Combustion state. The countdown has a fixed SPD of 70.\r\n\r\nSAM cannot use Ultimate while in Complete Combustion.",
                MaxLevel = 12
            },

            new Skill
            {   
                CharacterId = firefly.Id,
                SkillType = "Talent",
                Name = "Chrysalid Pyronexus",
                Description = "The lower the HP, the less DMG received. When HP is 20% or lower, the DMG Reduction reaches its maximum effect, reducing up to <span class=\"skill-value\" data-stat=\"DamageReduction\"></span>%. During the Complete Combustion, the DMG Reduction remains at its maximum effect, and the Effect RES increases by <span class=\"skill-value\" data-stat=\"EffectRES\"></span>%.\r\nIf Energy is lower than 50% when the battle starts, regenerates Energy to 50%. Once Energy is regenerated to its maximum, dispels all debuffs on this unit.",
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
                100, 110, 120, 130, 140, 150, 162.5
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
            double[] speedScaling = new double[] { 30, 33, 36, 39, 42, 45, 48.75, 52.5, 56.25, 60, 63, 66 };
            damageScaling = new double[] { 10, 11, 12, 13, 14, 15, 16.25, 17.5, 18.75, 20, 21, 22 };

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

            var guide = new CharacterGuide()
            {
                Character = firefly,
                Strengths = @"Can help keep herself alive with self healing
                              Has plenty of viable team members, including some easily accesable ones
                              Her E1 helps a lot with skill point management, as her enhanced skill no longer consumes them
                              Best girl",
                Weaknesses = @"Requires a lot of speed to build properly
                               High speed means she uses a lot of skill points if she doesn't have at least E1
                               Best support units are all currently limited 5*
                               Enemies with high toughness take much longer to beat",
                Review = "Definetly worth pulling even more than a year after she was released"
            };

            context.CharacterGuides.AddRange(guide);

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
                new LightCone() { Name = "Indelible Promise", Rarity = 4, Path = "Destruction", Description = "Increases the wearer's Break Effect by 28/35/42/49/56%. When the wearer uses their Ultimate, increases CRIT Rate by 15/18.75/22.5/26.25/30%, lasting for 2 turns.", Obtain = "Stellar Warp or Event Warp", Image = "Indelible_Promise.webp"}
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

            //Adding Firefly's two teams

            var teams = new Team[] {
                new Team() { Name = "Premium Break Team", Description = "The best current break team" },
                new Team() { Name = "Alternate Break Team", Description = "Firefly's secondary Teammates"}
            };

            context.Teams.AddRange(teams);
            context.SaveChanges();

            // Adding team members for Firefly's two teams

            var team = context.Teams.First(t => t.Name == "Premium Break Team");
            var team2 = context.Teams.First(t => t.Name == "Alternate Break Team");

            var lingsha = context.Characters.First(c => c.Name == "Lingsha");
            var dahlia = context.Characters.First(c => c.Name == "The Dahlia");
            var fugue = context.Characters.First(c => c.Name == "Fugue");
            var ruanMei = context.Characters.First(c => c.Name == "Ruan Mei");
            var trailblazer = context.Characters.First(c => c.Name == "Harmony Trailblazer");
            var gallagher = context.Characters.First(c => c.Name == "Gallagher");

            var teamMembers = new TeamMember[] {
                new TeamMember() { Team = team, Character = firefly, Order = 1, Role = TeamRole.DPS },
                new TeamMember() { Team = team, Character = dahlia, Order = 2, Role = TeamRole.SubDPS },
                new TeamMember() { Team = team, Character = fugue, Order = 3, Role = TeamRole.Support },
                new TeamMember() { Team = team, Character = lingsha, Order = 4, Role = TeamRole.Sustain },
                new TeamMember() { Team = team2, Character = firefly, Order = 1, Role = TeamRole.DPS },
                new TeamMember() { Team = team2, Character = ruanMei, Order = 2, Role = TeamRole.Support },
                new TeamMember() { Team = team2, Character = trailblazer, Order = 3, Role = TeamRole.Support },
                new TeamMember() { Team = team2, Character = gallagher, Order = 4, Role = TeamRole.Sustain },
            };

            context.AddRange(teamMembers);
            context.SaveChanges();

            //Adding Firefly's teams

            var characterTeams = new CharacterTeam[] {
                new CharacterTeam() { Character = firefly, Team = team, Type = "Premium", Rank = 1},
                new CharacterTeam() { Character = firefly, Team = team2, Type = "Alternate", Rank = 2}
            };

            context.AddRange(characterTeams);
            context.SaveChanges();

            //Adding Castorice skills

            var castorice = context.Characters.First(c => c.Name == "Castorice");

            skills = new Skill[]
            {
                new Skill
                {
                    CharacterId = castorice.Id,
                    SkillType = "Basic ATK",
                    Name = "Lament, Nethersea's Ripple",
                    Description = "Deals Quantum DMG equal to <span data-stat=\"Damage\"></span>% of Castorice's Max HP to one designated enemy.",
                    MaxLevel = 7
                },
                new Skill
                {
                    CharacterId = castorice.Id,
                    SkillType = "Skill",
                    Name = "Silence, Wraithfly's Caress",
                    Description = "Consumes 30% of all allies' current HP. Deals Quantum DMG equal to <span data-stat=\"MainDamage\"></span>% of Castorice's Max HP to one designated enemy and Quantum DMG equal to <span data-stat=\"AdjacentDamage\"></span>% of Castorice's Max HP to adjacent targets.\r\nIf the current HP is insufficient, reduces the current HP down to 1.\r\nIf Netherwing is on the battlefield, the Skill becomes \"Boneclaw, Doomdrake's Embrace\" instead.",
                    MaxLevel = 12
                },
                new Skill
                {
                    CharacterId = castorice.Id,
                    SkillType = "Skill (Enhanced)",
                    Name = "Boneclaw, Doomdrake's Embrace",
                    Description = "Consumes 40% of the current HP of all allies (except Netherwing). Castorice and Netherwing launch Joint ATK on the targets, dealing Quantum DMG equal to <span data-stat=\"MainDamage\"></span>% and <span data-stat=\"SecondaryDamage\"></span>% of Castorice's Max HP to all enemies.\r\nIf the current HP is insufficient, reduces the current HP down to 1.",
                    MaxLevel = 12
                },
                new Skill
                {
                    CharacterId = castorice.Id,
                    SkillType = "Ultimate",
                    Name = "Doomshriek, Dawn's Chime",
                    Description = "Summons the memosprite Netherwing and advances its action by 100%. At the same time, deploys the Territory \"Lost Netherland,\" which decreases all enemies' All-Type RES by <span data-stat=\"DamageReduction\"></span>%. If Castorice has the DMG Boost effect from her Talent, then this effect spreads to Netherwing. Netherwing has an initial SPD of 165 and a set Max HP equal to 100% of max \"Newbud.\"\r\nAfter Netherwing experiences 3 turns or when its HP is 0, it disappears and dispels the Territory \"Lost Netherland.\"",
                    MaxLevel = 12
                },
                new Skill
                {
                    CharacterId = castorice.Id,
                    SkillType = "Talent",
                    Name = "Desolation Across Palms",
                    Description = "The maximum limit of \"Newbud\" is related to the levels of all characters on the battlefield. For every 1 point of HP lost by all allies, Castorice gains 1 point of \"Newbud.\" When \"Newbud\" reaches its maximum limit, can activate the Ultimate. When allies lose HP, Castorice's and Netherwing's DMG dealt increases by <span data-stat=\"DamageBoost\"></span>%. This effect can stack up to 3 time(s), lasting for 3 turn(s).\r\nWhen Netherwing is on the field, \"Newbud\" cannot be gained through Talent, and every 1 point of HP lost by all allies (except Netherwing) will be converted to an equal amount of HP for Netherwing.",
                    MaxLevel = 12
                },
                new Skill
                {
                    CharacterId = castorice.Id,
                    SkillType = "Technique",
                    Name = "Wail, Death's Herald",
                    Description = "After using Technique, enters the \"Netherveil\" state that lasts for 20 seconds. While \"Netherveil\" is active, enemies are unable to actively approach Castorice.\r\nDuring \"Netherveil,\" active attacks will cause all enemies within range to enter combat. At the same time, summons the memosprite Netherwing, advances its action by 100%, and deploys the Territory \"Lost Netherland.\" Netherwing has its current HP equal to 50% of max \"Newbud.\" After entering battle, consumes 40% of the current HP of all allies (except Netherwing).\r\nIf Netherwing is not summoned after entering battle, Castorice gains \"Newbud\" by an amount equal to 30% of max \"Newbud.\"",
                    MaxLevel = 1
                },
                new Skill
                {
                    CharacterId = castorice.Id,
                    SkillType = "Exclusive",
                    Name = "Sanctuary of Mooncocoon",
                    Description = "After obtaining Castorice or when Castorice is in the current team, receive the following effect: In battle, when an ally character receives a killing blow, all ally characters that received a killing blow in this action enter the \"Mooncocoon\" state. Characters in \"Mooncocoon\" temporarily delay becoming downed and can take actions normally. After the action and before the start of the next turn, if their current HP increases or they gain a Shield, \"Mooncocoon\" is removed. Otherwise, they will be downed immediately. This effect can only trigger once per battle.",
                    MaxLevel = 1
                }
            };

            context.AddRange(skills);
            context.SaveChanges();

            //Add Skill Values

            skillLevels = new List<SkillLevelValue>();

            //Basic Attack
            skill = context.Skills.First(s => s.Name == "Lament, Nethersea's Ripple");

            damageScaling = new double[] { 25, 30, 35, 40, 45, 50, 55 };

            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.Damage);

            //Skill
            skill = context.Skills.First(s => s.Name == "Silence, Wraithfly's Caress");
            mainDamageScaling = new double[] { 25, 27.5, 30, 32.5, 35, 37.5, 40.63, 43.75, 46.88, 50, 52.5, 55 };
            adjacentDamageScaling = new double[] { 15, 16.5, 18, 19.5, 21, 22.5, 24.38, 26.25, 28.13, 30, 31.5, 33};

            addSkillValues(skillLevels, mainDamageScaling, skill.Id, SkillStatType.MainDamage);
            addSkillValues(skillLevels, adjacentDamageScaling, skill.Id, SkillStatType.AdjacentDamage);

            //Skill (Enhanced)
            skill = context.Skills.First(s => s.Name == "Boneclaw, Doomdrake's Embrace");
            mainDamageScaling = new double[] { 15, 16.5, 18, 19.5, 21, 22.5, 24.4, 26.3, 28.1, 30, 31.5, 33};
            var secondaryDamageScaling = new double[] { 25, 27.5, 30, 32.5, 35, 37.5, 40.6, 43.8, 46.9, 50, 52.5, 55};

            addSkillValues(skillLevels, mainDamageScaling, skill.Id, SkillStatType.MainDamage);
            addSkillValues(skillLevels, secondaryDamageScaling, skill.Id, SkillStatType.SecondaryDamage);

            //Ultimate
            skill = context.Skills.First(s => s.Name == "Doomshriek, Dawn's Chime");
            damageReductionScaling = new double[] { 10, 11, 12, 13, 14, 15, 16.25, 17.5, 18.75, 20, 21, 22};

            addSkillValues(skillLevels, damageReductionScaling, skill.Id, SkillStatType.DamageReduction);

            //Talent
            skill = context.Skills.First(s => s.Name == "Desolation Across Palms");
            damageScaling = new double[] { 10, 11, 12, 13, 14, 15, 16.25, 17.5, 18.75, 20, 21, 22};

            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.DamageBoost);

            context.SkillValues.AddRange(skillLevels);
            context.SaveChanges();

            //Adding Netherwing and Little Ica (Castorice's and Hyacine's Memosprirtes.
            var hyacine = context.Characters.First(c => c.Name == "Hyacine");

            var memosprites = new Companion[]
            {
                new Companion{Name = "Netherwing", Description = "A powerful Dragon that fights alongside Castorice and contributes most of her damage", Character = castorice, Image = "Netherwing.webp"},
                new Companion{Name = "Little Ica", Description = "Hyacines memosprite, Little Ica, helps her by healing allies and constantly launching follow up attacks", Character = hyacine, Image = "Little Ica.webp"}
            };

            context.Companions.AddRange(memosprites);
            context.SaveChanges();

            //Add Netherwing's skills
            var Netherwing = context.Companions.First(c => c.Name == "Netherwing");

            skills = new Skill[]
            {
                new Skill
                {
                    Companion = Netherwing,
                    SkillType = "Memosprite Skill",
                    Name = "Claw Splits the Veil",
                    Description = "Deals Quantum DMG equal to <span data-stat=\"Damage\"></span>% of Castorice's Max HP to all enemies.",
                    MaxLevel = 9,
                },
                new Skill
                {
                    Companion = Netherwing,
                    SkillType = "Memosprite Skill",
                    Name = "Breath Scorches the Shadow",
                    Description = "Launching \"Breath Scorches the Shadow\" will consume 25% of Netherwing's Max HP to deal Quantum DMG equal to <span data-stat=\"Damage\"></span>% of Castorice's Max HP to all enemies.\r\nIn one attack, \"Breath Scorches the Shadow\" can be launched repeatedly, with the DMG multiplier increased progressively to <span data-stat=\"DamageBoost\"></span>% / <span data-stat=\"DamageReduction\"></span>%. After reaching <span data-stat=\"DamageReduction\"></span>%, it will not increase further. The DMG Multiplier Boost effect will not decrease before Netherwing disappears.\r\nWhen Netherwing's current HP is equal to or less than 25% of its Max HP, launching this ability will actively reduce HP down to 1, and then trigger the ability effect equal to that of the Talent \"Wings Sweep the Ruins.\"",
                    MaxLevel = 9,
                },
                new Skill
                {
                    Companion = Netherwing,
                    SkillType = "Memosprite Talent",
                    Name = "Mooncocoon Shrouds the Form",
                    Description = "When Netherwing is on the field, it acts as backup for allies. When allies take DMG or consume HP, their current HP can be reduced down to a minimum of 1, after which Netherwing will consume HP at 500% of the original value until Netherwing disappears.",
                    MaxLevel = 1,
                },
                new Skill
                {
                    Companion = Netherwing,
                    SkillType = "Memosprite Talent",
                    Name = "Roar Rumbles the Realm",
                    Description = "When Netherwing is summoned, increases DMG dealt by all allies by 10%, lasting for 3 turn(s).",
                    MaxLevel = 1,
                },
                new Skill
                {
                    Companion = Netherwing,
                    SkillType = "Memosprite Talent",
                    Name = "Wings Sweep the Ruins",
                    Description = "When Netherwing disappears, deals 6 instance(s) of DMG, with each instance dealing Quantum DMG equal to <span data-stat=\"Damage\"></span>% of Castorice's Max HP to one random enemy. At the same time, restores HP by an amount equal to <span data-stat=\"Healing\"></span>% of Castorice's Max HP plus <span data-stat=\"Health\"></span> for all allies.",
                    MaxLevel = 7,
                },
            };

            context.Skills.AddRange(skills);
            context.SaveChanges();

            //Adding Skill Values for Netherwing

            skillLevels = new List<SkillLevelValue>();

            //First Skill
            skill = context.Skills.First(s => s.Name == "Claw Splits the Veil");
            damageScaling = new double[] { 20, 24, 28, 32, 36, 40, 44, 48, 52};

            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.Damage);

            //Second Skill
            skill = context.Skills.First(s => s.Name == "Breath Scorches the Shadow");
            damageScaling = new double[] { 12, 14.4, 16.8, 19.2, 21.6, 24, 26.4, 28.8, 31.2};
            var scaling2 = new double[] { 14, 16.8, 19.6, 22.4, 25.2, 28, 30.8, 33.6, 36.4};
            var scaling3 = new double[] { 17, 20.4, 23.8, 27.2, 30.6, 34, 37.4, 40.8, 44.2};

            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.Damage);
            addSkillValues(skillLevels, scaling2, skill.Id, SkillStatType.DamageBoost);
            addSkillValues(skillLevels, scaling3, skill.Id, SkillStatType.DamageReduction);

            //Talent
            skill = context.Skills.First(s => s.Name == "Wings Sweep the Ruins");
            damageScaling = new double[] { 20, 24, 28, 32, 36, 40, 44};
            scaling2 = new double[] { 3, 3.6, 4.2, 4.8, 5.4, 6, 6.6};
            scaling3 = new double[] { 3, 3.6, 4.2, 4.8, 5.4, 6, 6.6};

            addSkillValues(skillLevels, damageScaling, skill.Id, SkillStatType.Damage);
            addSkillValues(skillLevels, scaling2, skill.Id, SkillStatType.Healing);
            addSkillValues(skillLevels, scaling3, skill.Id, SkillStatType.Health);

            context.SkillValues.AddRange(skillLevels);
            context.SaveChanges();
        }
    }
}
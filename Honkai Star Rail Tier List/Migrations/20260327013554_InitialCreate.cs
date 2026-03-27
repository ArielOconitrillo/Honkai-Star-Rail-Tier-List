using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honkai_Star_Rail_Tier_List.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Element = table.Column<string>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Rarity = table.Column<int>(type: "INTEGER", nullable: false),
                    TierMOC = table.Column<string>(type: "TEXT", nullable: false),
                    TierAS = table.Column<string>(type: "TEXT", nullable: false),
                    TierPF = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LightCones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Rarity = table.Column<int>(type: "INTEGER", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Obtain = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightCones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelicSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TwoPieceEffect = table.Column<string>(type: "TEXT", nullable: false),
                    FourPieceEffect = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelicSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Builds_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companions_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eidolons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eidolons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eidolons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Strengths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterID = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strengths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Strengths_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weaknesss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterID = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weaknesss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weaknesss_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterTeams_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildLightCones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuildId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false),
                    LightConeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildLightCones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildLightCones_Builds_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildLightCones_LightCones_LightConeId",
                        column: x => x.LightConeId,
                        principalTable: "LightCones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildRelicSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuildId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false),
                    RelicSet1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    RelicSet2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildRelicSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildRelicSets_Builds_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildRelicSets_RelicSets_RelicSet1Id",
                        column: x => x.RelicSet1Id,
                        principalTable: "RelicSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuildRelicSets_RelicSets_RelicSet2Id",
                        column: x => x.RelicSet2Id,
                        principalTable: "RelicSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuildId = table.Column<int>(type: "INTEGER", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    Feet = table.Column<string>(type: "TEXT", nullable: false),
                    SubstatPriority = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildStats_Builds_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: true),
                    CompanionId = table.Column<int>(type: "INTEGER", nullable: true),
                    SkillType = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    MaxLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Skills_Companions_CompanionId",
                        column: x => x.CompanionId,
                        principalTable: "Companions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    StatType = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillValues_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildLightCones_BuildId",
                table: "BuildLightCones",
                column: "BuildId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildLightCones_LightConeId",
                table: "BuildLightCones",
                column: "LightConeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildRelicSets_BuildId",
                table: "BuildRelicSets",
                column: "BuildId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildRelicSets_RelicSet1Id",
                table: "BuildRelicSets",
                column: "RelicSet1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BuildRelicSets_RelicSet2Id",
                table: "BuildRelicSets",
                column: "RelicSet2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_CharacterId",
                table: "Builds",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildStats_BuildId",
                table: "BuildStats",
                column: "BuildId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTeams_CharacterId",
                table: "CharacterTeams",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTeams_TeamId",
                table: "CharacterTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Companions_CharacterId",
                table: "Companions",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Eidolons_CharacterId_Level",
                table: "Eidolons",
                columns: new[] { "CharacterId", "Level" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CharacterId",
                table: "Skills",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CompanionId",
                table: "Skills",
                column: "CompanionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillValues_SkillId",
                table: "SkillValues",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Strengths_CharacterID",
                table: "Strengths",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_CharacterId",
                table: "TeamMembers",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Weaknesss_CharacterID",
                table: "Weaknesss",
                column: "CharacterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildLightCones");

            migrationBuilder.DropTable(
                name: "BuildRelicSets");

            migrationBuilder.DropTable(
                name: "BuildStats");

            migrationBuilder.DropTable(
                name: "CharacterTeams");

            migrationBuilder.DropTable(
                name: "Eidolons");

            migrationBuilder.DropTable(
                name: "SkillValues");

            migrationBuilder.DropTable(
                name: "Strengths");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Weaknesss");

            migrationBuilder.DropTable(
                name: "LightCones");

            migrationBuilder.DropTable(
                name: "RelicSets");

            migrationBuilder.DropTable(
                name: "Builds");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Companions");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}

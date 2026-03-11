using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honkai_Star_Rail_Tier_List.Migrations
{
    /// <inheritdoc />
    public partial class CreateSkillValuesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillLevelValue_Skills_SkillId",
                table: "SkillLevelValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillLevelValue",
                table: "SkillLevelValue");

            migrationBuilder.RenameTable(
                name: "SkillLevelValue",
                newName: "SkillValues");

            migrationBuilder.RenameIndex(
                name: "IX_SkillLevelValue_SkillId",
                table: "SkillValues",
                newName: "IX_SkillValues_SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillValues",
                table: "SkillValues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillValues_Skills_SkillId",
                table: "SkillValues",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillValues_Skills_SkillId",
                table: "SkillValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillValues",
                table: "SkillValues");

            migrationBuilder.RenameTable(
                name: "SkillValues",
                newName: "SkillLevelValue");

            migrationBuilder.RenameIndex(
                name: "IX_SkillValues_SkillId",
                table: "SkillLevelValue",
                newName: "IX_SkillLevelValue_SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillLevelValue",
                table: "SkillLevelValue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillLevelValue_Skills_SkillId",
                table: "SkillLevelValue",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

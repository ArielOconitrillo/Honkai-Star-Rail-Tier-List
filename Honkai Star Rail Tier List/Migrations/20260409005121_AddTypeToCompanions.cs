using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honkai_Star_Rail_Tier_List.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeToCompanions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Companions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Companions");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honkai_Star_Rail_Tier_List.Migrations
{
    /// <inheritdoc />
    public partial class AddSlugToCharctersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Characters");
        }
    }
}

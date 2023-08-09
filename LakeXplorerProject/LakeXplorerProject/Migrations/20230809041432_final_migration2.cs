using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LakeXplorerProject.Migrations
{
    /// <inheritdoc />
    public partial class final_migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "LakeSightings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "LakeSightings");
        }
    }
}

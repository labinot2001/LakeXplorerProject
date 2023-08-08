using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LakeXplorerProject.Migrations
{
    /// <inheritdoc />
    public partial class finalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LakeSightings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LakeSightings_UserId",
                table: "LakeSightings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LakeSightings_AspNetUsers_UserId",
                table: "LakeSightings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LakeSightings_AspNetUsers_UserId",
                table: "LakeSightings");

            migrationBuilder.DropIndex(
                name: "IX_LakeSightings_UserId",
                table: "LakeSightings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LakeSightings");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideosStorage.Data.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class VideosLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Videos",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Videos");
        }
    }
}

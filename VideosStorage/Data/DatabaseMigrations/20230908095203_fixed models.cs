using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideosStorage.Data.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class fixedmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Users_UserId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tags",
                newName: "VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_UserId",
                table: "Tags",
                newName: "IX_Tags_VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Videos_VideoId",
                table: "Tags",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Videos_VideoId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Tags",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_VideoId",
                table: "Tags",
                newName: "IX_Tags_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Users_UserId",
                table: "Tags",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

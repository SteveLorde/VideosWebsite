using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideosStorage.Data.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class ThumbnailPathandFilePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Users_UploadedById",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_UploadedById",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "UploadedById",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "ReleasedDate",
                table: "Videos",
                newName: "thumbnailpath");

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "Videos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "Videos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "filePath",
                table: "Videos");

            migrationBuilder.RenameColumn(
                name: "thumbnailpath",
                table: "Videos",
                newName: "ReleasedDate");

            migrationBuilder.AddColumn<int>(
                name: "UploadedById",
                table: "Videos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_UploadedById",
                table: "Videos",
                column: "UploadedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Users_UploadedById",
                table: "Videos",
                column: "UploadedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

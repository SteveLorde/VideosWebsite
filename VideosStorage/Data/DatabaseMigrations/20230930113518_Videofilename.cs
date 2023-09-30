using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideosStorage.Data.DatabaseMigrations
{
    /// <inheritdoc />
    public partial class Videofilename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "filePath",
                table: "Videos",
                newName: "filename");

            migrationBuilder.AlterColumn<string>(
                name: "thumbnailpath",
                table: "Videos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "filename",
                table: "Videos",
                newName: "filePath");

            migrationBuilder.AlterColumn<string>(
                name: "thumbnailpath",
                table: "Videos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}

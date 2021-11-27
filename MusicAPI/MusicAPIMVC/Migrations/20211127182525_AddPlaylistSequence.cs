using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPIMVC.Migrations
{
    public partial class AddPlaylistSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SequenceInPlaylist",
                table: "PlaylistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SequenceInPlaylist",
                table: "PlaylistSongs");
        }
    }
}

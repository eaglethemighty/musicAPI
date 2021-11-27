using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models.DTOs.Playlist
{
    public class PlaylistReadSong
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int SequenceInPlaylist { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models.DTOs.PlaylistItem
{
    public class PlaylistItemCreateDTO
    {
        [ForeignKey("Song")]
        public int SongId { get; set; }
        [ForeignKey("Playlist")]
        public int PlaylistId { get; set; }
        public int SequenceInPlaylist { get; set; }
    }
}

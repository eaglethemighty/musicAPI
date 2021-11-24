using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models
{
    public class Playlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<PlaylistSong>? PlaylistSongs { get; set; }

        [NotMapped]
        public TimeSpan? Length
        {
            get
            {
                return PlaylistSongs is null ? new TimeSpan(0, 0, 0) : new TimeSpan(PlaylistSongs.Sum(song => song.Song.Length.Ticks));
            }

        }

        [NotMapped]
        public int NumberOfSongs
        {
            get
            {
                return PlaylistSongs is null ? 0 : PlaylistSongs.Count;
            }
        }

    }
}

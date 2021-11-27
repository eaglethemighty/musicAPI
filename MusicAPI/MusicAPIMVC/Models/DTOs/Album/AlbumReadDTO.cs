using MusicAPIMVC.Models.DTOs.Song;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models.DTOs.Album
{
    public class AlbumReadDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int RealeaseYear { get; set; }
        public TimeSpan? Length;
        public int NumberOfSongs;
        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public IList<AlbumReadSongDTO>? Songs { get; set; }
    }
}

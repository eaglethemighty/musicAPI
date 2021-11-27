using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models.DTOs.Song
{
    public class SongUpdateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public TimeSpan Length { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        [ForeignKey("Album")]
        public int AlbumId { get; set; }
    }
}

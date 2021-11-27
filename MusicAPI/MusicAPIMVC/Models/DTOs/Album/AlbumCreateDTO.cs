using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models.DTOs.Album
{
    public class AlbumCreateDTO
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public int RealeaseYear { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models
{
    public class Song
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public TimeSpan Length { get; set; }

        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        [Required]
        public Artist Artist { get; set; }

        [ForeignKey("Genre")]
        public int GenreID { get; set; }
        [Required]
        public Genre Genre { get; set; }

        [ForeignKey("Album")]
        public int AlbumID { get; set; }
        [Required]
        public Album Album { get; set; }

    }
}

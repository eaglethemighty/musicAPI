using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPIMVC.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StageName { get; set; }
        public IList<Album>? Albums { get; set; }

        [NotMapped]
        public int NumberOfAlbums
        {
            get
            {
                return Albums is null ? 0 : Albums.Count;
            }
        }

        [NotMapped]
        public int NumberOfSongs
        {
            get
            {
                return Albums is null ? 0 : Albums.Sum(album => album.NumberOfSongs);
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MusicAPIMVC.Models
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Song>? AllSongs { get; set; }

    }
}

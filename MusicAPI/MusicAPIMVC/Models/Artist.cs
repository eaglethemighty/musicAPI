using System.ComponentModel.DataAnnotations;

namespace MusicAPIMVC.Models
{
    public class Artist
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string StageName { get; set; }

        public IList<Album>? Albums { get; set; }
    }
}

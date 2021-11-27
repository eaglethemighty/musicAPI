using System.ComponentModel.DataAnnotations;

namespace MusicAPIMVC.Models.DTOs.Artist
{
    public class ArtistUpdateDTO
    {
        [Required]
        public string StageName { get; set; }
    }
}

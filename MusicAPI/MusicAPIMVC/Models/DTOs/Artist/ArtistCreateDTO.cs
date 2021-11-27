using System.ComponentModel.DataAnnotations;

namespace MusicAPIMVC.Models.DTOs.Artist
{
    public class ArtistCreateDTO
    {
        [Required]
        public string StageName { get; set; }
    }
}

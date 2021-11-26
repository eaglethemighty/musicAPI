using System.ComponentModel.DataAnnotations;

namespace MusicAPIMVC.Models.DTOs.Genre
{
    public class GenreCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}

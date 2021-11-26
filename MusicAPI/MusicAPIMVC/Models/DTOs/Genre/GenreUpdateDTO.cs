using System.ComponentModel.DataAnnotations;

namespace MusicAPIMVC.Models.DTOs.Genre
{
    public class GenreUpdateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}

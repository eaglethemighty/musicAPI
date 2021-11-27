using System.ComponentModel.DataAnnotations;

namespace MusicAPIMVC.Models.DTOs.Playlist
{
    public class PlaylistCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}

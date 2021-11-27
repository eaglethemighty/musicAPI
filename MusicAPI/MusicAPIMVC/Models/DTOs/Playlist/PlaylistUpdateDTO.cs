using System.ComponentModel.DataAnnotations;

namespace MusicAPIMVC.Models.DTOs.Playlist
{
    public class PlaylistUpdateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}

using MusicAPIMVC.Models.DTOs.Song;

namespace MusicAPIMVC.Models.DTOs.Genre
{
    public class GenreReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SongReadDTO>? AllSongs { get; set; }
    }
}

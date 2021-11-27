namespace MusicAPIMVC.Models.DTOs.Song
{
    public class AlbumReadSongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}

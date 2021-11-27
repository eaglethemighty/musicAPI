namespace MusicAPIMVC.Models.DTOs.Song
{
    public class SongReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }
        public int ArtistId { get; set; }
        public string ArtistStageName { get; set; }
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }

    }
}

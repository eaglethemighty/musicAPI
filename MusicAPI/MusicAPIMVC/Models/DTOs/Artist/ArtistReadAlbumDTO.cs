namespace MusicAPIMVC.Models.DTOs.Artist
{
    public class ArtistReadAlbumDTO
    {

        public string Title { get; set; }
        public int RealeaseYear { get; set; }
        public TimeSpan? Length;
        public int NumberOfSongs;
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
    }
}

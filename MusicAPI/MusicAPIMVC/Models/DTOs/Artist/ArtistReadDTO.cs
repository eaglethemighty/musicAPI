namespace MusicAPIMVC.Models.DTOs.Artist
{
    public class ArtistReadDTO
    {
        public int Id { get; set; }
        public string StageName { get; set; }
        public int NumberOfAlbums;
        public int NumberOfSongs;
        public IList<ArtistReadAlbumDTO>? Albums { get; set; }
    }
}

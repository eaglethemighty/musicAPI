namespace MusicAPIMVC.Models.DTOs.Playlist
{
    public class PlaylistReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan? Length { get; set; }
        public int NumberOfSongs { get; set; }
        public IList<PlaylistReadSong>? PlaylistSongs { get; set; }
    }
}

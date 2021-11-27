using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Models;

namespace MusicAPIMVC.Data
{
    public static class DataSeeder
    {
        public static void SeedData(this ModelBuilder builder)
        {
            ICollection<Song> songs = new List<Song>();
            ICollection<Artist> artists = new List<Artist>();
            ICollection<Genre> genres = new List<Genre>();
            ICollection<Playlist> playlists = new List<Playlist>();
            ICollection<Album> albums = new List<Album>();

            Artist artist1 = new Artist()
            {
                Id = 1,
                StageName = "Milky Chance"
            };

            Artist artist2 = new Artist()
            {
                Id = 2,
                StageName = "Mac Miller"
            };

            Artist artist3 = new Artist()
            {
                Id = 3,
                StageName = "The Doors"
            };

            Artist artist4 = new Artist()
            {
                Id = 4,
                StageName = "Tyler, The Creator",
            };

            Artist artist5 = new Artist()
            {
                Id = 5,
                StageName = "Chet Baker"
            };


            Genre genre1 = new Genre()
            {
                Id = 1,
                Name = "Pop"
            };

            Genre genre2 = new Genre()
            {
                Id = 2,
                Name = "Rap"
            };

            Genre genre3 = new Genre()
            {
                Id = 3,
                Name = "Rock"
            };

            Genre genre4 = new Genre()
            {
                Id = 4,
                Name = "R&B"
            };

            Genre genre5 = new Genre()
            {
                Id = 5,
                Name = "Jazz"
            };

            Album album1 = new Album()
            {
                Id = 1,
                ArtistId = artist1.Id,
                RealeaseYear = 2013,
                Title = "Sadnecessary"

            };

            Album album2 = new Album()
            {
                Id = 2,
                ArtistId = artist2.Id,
                RealeaseYear = 2016,
                Title = "The Divine Feminine"

            };

            Album album3 = new Album()
            {
                Id = 3,
                ArtistId = artist3.Id,
                RealeaseYear = 1967,
                Title = "The Doors"

            };

            Album album4 = new Album()
            {
                Id = 4,
                ArtistId = artist4.Id,
                RealeaseYear = 2019,
                Title = "IGOR"

            };

            Album album5 = new Album()
            {
                Id = 5,
                ArtistId = artist5.Id,
                RealeaseYear = 1956,
                Title = "Chet Baker Sings"

            };


            Song song1 = new Song()
            {
                Id = 1,
                Name = "Stolen Dance",
                AlbumId = album1.Id,
                GenreId = genre1.Id,
                Length = new TimeSpan(0, 5, 13)
            };

            Song song2 = new Song()
            {
                Id = 2,
                Name = "Cinderella",
                AlbumId = album2.Id,
                GenreId = genre2.Id,
                Length = new TimeSpan(0, 8, 0)
            };

            Song song3 = new Song()
            {
                Id = 3,
                Name = "Break on through (on the other side)",
                AlbumId = album3.Id,
                GenreId = genre3.Id,
                Length = new TimeSpan(0, 2, 25)
            };

            Song song4 = new Song()
            {
                Id = 4,
                Name = "GONE GONE / THANK YOU",
                AlbumId = album4.Id,
                GenreId = genre4.Id,
                Length = new TimeSpan(0, 6, 15)
            };

            Song song5 = new Song()
            {
                Id = 5,
                Name = "That Old Feeling",
                AlbumId = album5.Id,
                GenreId = genre5.Id,
                Length = new TimeSpan(0, 3, 3)
            };

            songs.Add(song1);
            songs.Add(song2);
            songs.Add(song3);
            songs.Add(song4);
            songs.Add(song5);

            artists.Add(artist1);
            artists.Add(artist2);
            artists.Add(artist3);
            artists.Add(artist4);
            artists.Add(artist5);

            genres.Add(genre1);
            genres.Add(genre2);
            genres.Add(genre3);
            genres.Add(genre4);
            genres.Add(genre5);

            albums.Add(album1);
            albums.Add(album2);
            albums.Add(album3);
            albums.Add(album4);
            albums.Add(album5);

            builder.Entity<Song>().HasData(songs);
            builder.Entity<Artist>().HasData(artists);
            builder.Entity<Genre>().HasData(genres);
            builder.Entity<Playlist>().HasData(playlists);
            builder.Entity<Album>().HasData(albums);
        }
    }
}

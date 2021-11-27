using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Models;

namespace MusicAPIMVC.Data
{
    public class MusicDBAccess : DbContext
    {
        public MusicDBAccess(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlaylistItem> PlaylistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
                
            base.OnModelCreating(modelBuilder);
        }
    }
}

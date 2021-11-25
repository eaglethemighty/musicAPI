using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Data;
using MusicAPIMVC.Models;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Repository
{
    public class PlaylistRepository : IRepositoryCRUD<Playlist>
    {
<<<<<<< Updated upstream
=======
        public PlaylistRepository(MusicDBAccess context)
        {
            _context = context;
        }

>>>>>>> Stashed changes
        private MusicDBAccess _context { get; set; }
        public void Add(Playlist obj)
        {
            _context.Playlists.Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(Playlist obj)
        {
            _context.Playlists.Add(obj);
            await _context.SaveChangesAsync();
        }

        public void Delete(Playlist obj)
        {
            _context.Playlists.Remove(obj);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Playlist obj)
        {
            _context.Playlists.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public void DeleteByID(int ID)
        {
            Playlist PlaylistToDelete = GetById(ID);
            if (PlaylistToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Playlists.Remove(PlaylistToDelete);
            _context.SaveChanges();
        }

        public async Task DeleteByIDAsync(int ID)
        {
            Playlist PlaylistToDelete = await GetByIdAsync(ID);
            if (PlaylistToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Playlists.Remove(PlaylistToDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Playlist> GetAll()
        {
            return _context.Playlists
                .Include(Playlist => Playlist.PlaylistSongs)
                .ThenInclude(psongs => psongs.Song)
                .ToList();
        }

        public async Task<IEnumerable<Playlist>> GetAllAsync()
        {
            return await Task.Run(
                () => _context.Playlists
                .Include(Playlist => Playlist.PlaylistSongs)
                .ThenInclude(psongs => psongs.Song)
                .ToList());
        }

        public Playlist GetById(int id)
        {
            List<Playlist> AllPlaylists = (List<Playlist>)GetAll();

            return AllPlaylists.First(Playlist => Playlist.Id == id);
        }

        public async Task<Playlist> GetByIdAsync(int id)
        {
            List<Playlist> AllPlaylists = (List<Playlist>)GetAll();

            return await Task.Run(
                () => AllPlaylists.First(Playlist => Playlist.Id == id)
                );
        }

        public void Update(Playlist obj)
        {
            _context.Playlists.Update(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Playlist obj)
        {
            _context.Playlists.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}

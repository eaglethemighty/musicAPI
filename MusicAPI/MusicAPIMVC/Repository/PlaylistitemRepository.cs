using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Data;
using MusicAPIMVC.Models;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Repository
{
    public class PlaylistitemRepository : IRepositoryPlaylistItem
    {
        public PlaylistitemRepository(MusicDBAccess context)
        {
            _context = context;
        }
        private MusicDBAccess _context { get; set; }
        public void Add(PlaylistItem obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(PlaylistItem obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public void Delete(PlaylistItem obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(PlaylistItem obj)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public void DeleteByID(int ID)
        {
            PlaylistItem PlaylistItemToDelete = GetById(ID);
            if (PlaylistItemToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.PlaylistSongs.Remove(PlaylistItemToDelete);
            _context.SaveChanges();
        }

        public async Task DeleteByIDAsync(int ID)
        {
            PlaylistItem PlaylistItemToDelete = await GetByIdAsync(ID);
            if (PlaylistItemToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.PlaylistSongs.Remove(PlaylistItemToDelete);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<PlaylistItem> GetAll()
        {
            return _context.PlaylistSongs
                .Include(PlaylistItem => PlaylistItem.Playlist)
                .Include(PlaylistItem => PlaylistItem.Song)
                .ToList();
        }

        public async Task<IEnumerable<PlaylistItem>> GetAllAsync()
        {
            return await Task.Run(
                () => _context.PlaylistSongs
                    .Include(PlaylistItem => PlaylistItem.Playlist)
                    .Include(PlaylistItem => PlaylistItem.Song)
                    .ToList());
        }

        public PlaylistItem GetById(int id)
        {
            List<PlaylistItem> AllPlaylistItems = (List<PlaylistItem>)GetAll();

            return AllPlaylistItems.First(PlaylistItem => PlaylistItem.Id == id);
        }

        public async Task<PlaylistItem> GetByIdAsync(int id)
        {
            List<PlaylistItem> AllPlaylistItems = (List<PlaylistItem>)GetAll();

            return await Task.Run(
                () => AllPlaylistItems.First(PlaylistItem => PlaylistItem.Id == id));
        }
    }
}

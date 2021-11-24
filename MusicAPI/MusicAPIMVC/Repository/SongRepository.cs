using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Data;
using MusicAPIMVC.Models;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Repository
{
    public class SongRepository : IRepositoryCRUD<Song>
    {
        private MusicDBAccess _context { get; set; }
        public void Add(Song obj)
        {
            _context.Songs.Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(Song obj)
        {
            _context.Songs.Add(obj);
            await _context.SaveChangesAsync();
        }

        public void Delete(Song obj)
        {
            _context.Songs.Remove(obj);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Song obj)
        {
            _context.Songs.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public void DeleteByID(int ID)
        {
            Song SongToDelete = GetById(ID);
            if (SongToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Songs.Remove(SongToDelete);
            _context.SaveChanges();
        }

        public async Task DeleteByIDAsync(int ID)
        {
            Song SongToDelete = await GetByIdAsync(ID);
            if (SongToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Songs.Remove(SongToDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Song> GetAll()
        {
            return _context.Songs
                .Include(song => song.Genre)
                .Include(song => song.Album)
                .ThenInclude(album => album.Artist)
                .ToList();
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await Task.Run(
                () => _context.Songs
                .Include(song => song.Genre)
                .Include(song => song.Album)
                .ThenInclude(album => album.Artist)
                .ToList());
        }

        public Song GetById(int id)
        {
            List<Song> AllSongs = (List<Song>)GetAll();

            return AllSongs.First(Song => Song.Id == id);
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            List<Song> AllSongs = (List<Song>)GetAll();

            return await Task.Run(
                () => AllSongs.First(Song => Song.Id == id)
                );
        }

        public void Update(Song obj)
        {
            _context.Songs.Update(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Song obj)
        {
            _context.Songs.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}

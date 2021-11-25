using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Data;
using MusicAPIMVC.Models;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Repository
{
    public class AlbumRepository : IRepositoryCRUD<Album>
    {
        public AlbumRepository(MusicDBAccess context)
        {
            _context = context;
        }

        private MusicDBAccess _context { get; set; }
        public void Add(Album obj)
        {
            _context.Albums.Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(Album obj)
        {
            _context.Albums.Add(obj);
            await _context.SaveChangesAsync();
        }

        public void Delete(Album obj)
        {
            _context.Albums.Remove(obj);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Album obj)
        {
            _context.Albums.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public void DeleteByID(int ID)
        {
            Album albumToDelete = GetById(ID);
            if (albumToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Albums.Remove(albumToDelete);
            _context.SaveChanges();
        }

        public async Task DeleteByIDAsync(int ID)
        {
            Album albumToDelete = await GetByIdAsync(ID);
            if (albumToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Albums.Remove(albumToDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums
                .Include(album => album.Songs)
                .Include(album => album.Artist)
                .ToList();
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await Task.Run(
                () => _context.Albums
                .Include(album => album.Songs)
                .Include(album => album.Artist)
                .ToList());
        }

        public Album GetById(int id)
        {
            List<Album> AllAlbums = (List<Album>)GetAll();

            return AllAlbums.First(album => album.Id == id);
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            List<Album> AllAlbums = (List<Album>)GetAll();

            return await Task.Run(
                () => AllAlbums.First(album => album.Id == id)
                );
        }

        public void Update(Album obj)
        {
            _context.Albums.Update(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Album obj)
        {
            _context.Albums.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}

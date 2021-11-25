using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Data;
using MusicAPIMVC.Models;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Repository
{
    public class GenreRepository : IRepositoryCRUD<Genre>
    {
<<<<<<< Updated upstream
=======
        public GenreRepository(MusicDBAccess context)
        {
            _context = context;
        }

>>>>>>> Stashed changes
        private MusicDBAccess _context { get; set; }
        public void Add(Genre obj)
        {
            _context.Genres.Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(Genre obj)
        {
            _context.Genres.Add(obj);
            await _context.SaveChangesAsync();
        }

        public void Delete(Genre obj)
        {
            _context.Genres.Remove(obj);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Genre obj)
        {
            _context.Genres.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public void DeleteByID(int ID)
        {
            Genre GenreToDelete = GetById(ID);
            if (GenreToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Genres.Remove(GenreToDelete);
            _context.SaveChanges();
        }

        public async Task DeleteByIDAsync(int ID)
        {
            Genre GenreToDelete = await GetByIdAsync(ID);
            if (GenreToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Genres.Remove(GenreToDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres
                .Include(genre => genre.AllSongs)
                .ToList();
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await Task.Run(
                () => _context.Genres
                .Include(genre => genre.AllSongs)
                .ToList());
        }

        public Genre GetById(int id)
        {
            List<Genre> AllGenres = (List<Genre>)GetAll();

            return AllGenres.First(Genre => Genre.Id == id);
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            List<Genre> AllGenres = (List<Genre>)GetAll();

            return await Task.Run(
                () => AllGenres.First(Genre => Genre.Id == id)
                );
        }

        public void Update(Genre obj)
        {
            _context.Genres.Update(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Genre obj)
        {
            _context.Genres.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MusicAPIMVC.Data;
using MusicAPIMVC.Models;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Repository
{
    public class ArtistRepository : IRepositoryCRUD<Artist>
    {
<<<<<<< Updated upstream
=======
        public ArtistRepository(MusicDBAccess context)
        {
            _context = context;
        }

>>>>>>> Stashed changes
        private MusicDBAccess _context { get; set; }
        public void Add(Artist obj)
        {
            _context.Artists.Add(obj);
            _context.SaveChanges();
        }

        public async Task AddAsync(Artist obj)
        {
            _context.Artists.Add(obj);
            await _context.SaveChangesAsync();
        }

        public void Delete(Artist obj)
        {
            _context.Artists.Remove(obj);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Artist obj)
        {
            _context.Artists.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public void DeleteByID(int ID)
        {
            Artist ArtistToDelete = GetById(ID);
            if (ArtistToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Artists.Remove(ArtistToDelete);
            _context.SaveChanges();
        }

        public async Task DeleteByIDAsync(int ID)
        {
            Artist ArtistToDelete = await GetByIdAsync(ID);
            if (ArtistToDelete is null)
            {
                throw new ArgumentException();
            }
            _context.Artists.Remove(ArtistToDelete);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists
                .Include(artist => artist.Albums)
                .ToList();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await Task.Run(
                () => _context.Artists
                .Include(artist => artist.Albums)
                .ToList());
        }

        public Artist GetById(int id)
        {
            List<Artist> AllArtists = (List<Artist>)GetAll();

            return AllArtists.First(Artist => Artist.Id == id);
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            List<Artist> AllArtists = (List<Artist>)GetAll();

            return await Task.Run(
                () => AllArtists.First(Artist => Artist.Id == id)
                );
        }

        public void Update(Artist obj)
        {
            _context.Artists.Update(obj);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Artist obj)
        {
            _context.Artists.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}

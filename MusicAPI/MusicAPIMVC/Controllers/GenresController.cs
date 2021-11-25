using Microsoft.AspNetCore.Mvc;
using MusicAPIMVC.Models;
using MusicAPIMVC.Repository;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public GenresController(IRepositoryCRUD<Genre> genreRepository)
        {
            _GenreRepository = genreRepository;
        }

        private IRepositoryCRUD<Genre> _GenreRepository { get; init; }

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetAllGenres()
        {
            List<Genre> AllGenres = _GenreRepository.GetAll().ToList();
            
            return Ok(AllGenres);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Genre>> GetSpecificGenre(int id)
        {
            Genre Genre = new();

            try
            {
                Genre = _GenreRepository.GetById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(Genre);
        }
    }
}
 
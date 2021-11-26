using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MusicAPIMVC.Models;
using MusicAPIMVC.Models.DTOs.Genre;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public GenresController(IRepositoryCRUD<Genre> genreRepository, IMapper mapper)
        {
            _GenreRepository = genreRepository;
            _mapper = mapper;
        }

        private IRepositoryCRUD<Genre> _GenreRepository { get; init; }

        private readonly IMapper _mapper;

        [HttpGet]
        public ActionResult<IEnumerable<GenreReadDTO>> GetAllGenres()
        {
            List<Genre> AllGenres = _GenreRepository.GetAll().ToList();

            return Ok(_mapper.Map<List<GenreReadDTO>>(AllGenres));
        }

        [HttpGet("{id}", Name = "GetSpecificGenre")]
        public ActionResult<IEnumerable<GenreReadDTO>> GetSpecificGenre(int id)
        {
            Genre Genre = new();

            try
            {
                Genre = _GenreRepository.GetById(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

            return Ok(_mapper.Map<GenreReadDTO>(Genre));
        }

        [HttpPost]
        public ActionResult<GenreReadDTO> CreateGenre(GenreCreateDTO genreDTO)
        {
            var Genre = _mapper.Map<Genre>(genreDTO);
            _GenreRepository.Add(Genre);

            var GenreRead = _mapper.Map<GenreReadDTO>(Genre);

            return CreatedAtRoute(nameof(GetSpecificGenre), new { Id = GenreRead.Id }, GenreRead);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGenre(int id, GenreUpdateDTO genreDTO)
        {
            Genre genre;
            try
            {
                genre = _GenreRepository.GetById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            var GenreUpdated = _mapper.Map(genreDTO, genre);
            _GenreRepository.Update(GenreUpdated);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialGenreUpdate(int id, JsonPatchDocument<GenreUpdateDTO> patchDocument)
        {
            Genre genre;
            try
            {
                genre = _GenreRepository.GetById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            var GenreToPatch = _mapper.Map<GenreUpdateDTO>(genre);
            patchDocument.ApplyTo(GenreToPatch, ModelState);

            if (!TryValidateModel(GenreToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _GenreRepository.Update(_mapper.Map<Genre>(GenreToPatch));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGenreByID(int id)
        {
            Genre genre;
            try
            {
                genre = _GenreRepository.GetById(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            _GenreRepository.Delete(genre);
            return NoContent();
        }
    }
}

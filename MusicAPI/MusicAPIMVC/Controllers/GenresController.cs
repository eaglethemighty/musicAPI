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
        public async Task<ActionResult<IEnumerable<GenreReadDTO>>> GetAllGenres()
        {
            List<Genre> AllGenres = (await _GenreRepository.GetAllAsync()).ToList();

            return Ok(_mapper.Map<List<GenreReadDTO>>(AllGenres));
        }

        [HttpGet("{id}", Name = "GetSpecificGenre")]
        public async Task<ActionResult<IEnumerable<GenreReadDTO>>> GetSpecificGenre(int id)
        {
            Genre Genre = new();

            try
            {
                Genre = await _GenreRepository.GetByIdAsync(id);
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
        public async Task<ActionResult<GenreReadDTO>> CreateGenre(GenreCreateDTO genreDTO)
        {
            var Genre = _mapper.Map<Genre>(genreDTO);
            await _GenreRepository.AddAsync(Genre);

            var GenreRead = _mapper.Map<GenreReadDTO>(Genre);

            return CreatedAtRoute(nameof(GetSpecificGenre), new { Id = GenreRead.Id }, GenreRead);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGenre(int id, GenreUpdateDTO genreDTO)
        {
            Genre genre;
            try
            {
                genre = await _GenreRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            var GenreUpdated = _mapper.Map(genreDTO, genre);
            await _GenreRepository.UpdateAsync(GenreUpdated);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialGenreUpdate(int id, JsonPatchDocument<GenreUpdateDTO> patchDocument)
        {
            Genre genre;
            try
            {
                genre = await _GenreRepository.GetByIdAsync(id);
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

            await _GenreRepository.UpdateAsync(_mapper.Map<Genre>(GenreToPatch));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenreByID(int id)
        {
            Genre genre;
            try
            {
                genre = await _GenreRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            await _GenreRepository.DeleteAsync(genre);
            return NoContent();
        }
    }
}

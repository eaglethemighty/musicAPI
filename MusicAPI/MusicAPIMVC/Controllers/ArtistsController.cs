using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MusicAPIMVC.Models;
using MusicAPIMVC.Models.DTOs.Artist;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Controllers
{
    [ApiController]
    [Route("api/artist")]
    public class ArtistsController : ControllerBase
    {
        public ArtistsController(IRepositoryCRUD<Artist> artistRepository, IMapper mapper)
        {
            _ArtistRepository = artistRepository;
            _mapper = mapper;
        }
        private IRepositoryCRUD<Artist> _ArtistRepository { get; init; }

        private readonly IMapper _mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistReadDTO>>> GetAllArtists()
        {
            List<Artist> AllArtists = (await _ArtistRepository.GetAllAsync()).ToList();

            return Ok(_mapper.Map<List<ArtistReadDTO>>(AllArtists));
        }

        [HttpGet("{id}", Name = "GetSpecificArtist")]
        public async Task<ActionResult<IEnumerable<ArtistReadDTO>>> GetSpecificArtist(int id)
        {
            Artist Artist = new();

            try
            {
                Artist = await _ArtistRepository.GetByIdAsync(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

            return Ok(_mapper.Map<ArtistReadDTO>(Artist));
        }

        [HttpPost]
        public async Task<ActionResult<ArtistReadDTO>> CreateArtist(ArtistCreateDTO ArtistDTO)
        {
            var Artist = _mapper.Map<Artist>(ArtistDTO);
            await _ArtistRepository.AddAsync(Artist);

            var ArtistRead = _mapper.Map<ArtistReadDTO>(Artist);

            return CreatedAtRoute(nameof(GetSpecificArtist), new { Id = ArtistRead.Id }, ArtistRead);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArtist(int id, ArtistUpdateDTO ArtistDTO)
        {
            Artist Artist;
            try
            {
                Artist = await _ArtistRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            var ArtistUpdated = _mapper.Map(ArtistDTO, Artist);
            await _ArtistRepository.UpdateAsync(ArtistUpdated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtistByID(int id)
        {
            Artist Artist;
            try
            {
                Artist = await _ArtistRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            await _ArtistRepository.DeleteAsync(Artist);
            return NoContent();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicAPIMVC.Models;
using MusicAPIMVC.Models.DTOs.Album;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Controllers
{
    [ApiController]
    [Route("api/album")]
    public class AlbumController : ControllerBase
    {
        public AlbumController(IRepositoryCRUD<Album> albumRepository, IMapper mapper)
        {
            _AlbumRepository = albumRepository;
            _mapper = mapper;
        }
        private IRepositoryCRUD<Album> _AlbumRepository { get; init; }
        private readonly IMapper _mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumReadDTO>>> GetAllAlbums()
        {
            List<Album> AllAlbums = (await _AlbumRepository.GetAllAsync()).ToList();

            return Ok(_mapper.Map<List<AlbumReadDTO>>(AllAlbums));
        }

        [HttpGet("{id}", Name = "GetSpecificAlbum")]
        public async Task<ActionResult<IEnumerable<AlbumReadDTO>>> GetSpecificAlbum(int id)
        {
            Album Album = new();

            try
            {
                Album = await _AlbumRepository.GetByIdAsync(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

            return Ok(_mapper.Map<AlbumReadDTO>(Album));
        }

        [HttpPost]
        public async Task<ActionResult<AlbumReadDTO>> CreateAlbum(AlbumCreateDTO AlbumDTO)
        {
            var Album = _mapper.Map<Album>(AlbumDTO);
            await _AlbumRepository.AddAsync(Album);

            var AlbumRead = _mapper.Map<AlbumReadDTO>(Album);

            return CreatedAtRoute(nameof(GetSpecificAlbum), new { Id = AlbumRead.Id }, AlbumRead);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlbum(int id, AlbumUpdateDTO AlbumDTO)
        {
            Album Album;
            try
            {
                Album = await _AlbumRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            var AlbumUpdated = _mapper.Map(AlbumDTO, Album);
            await _AlbumRepository.UpdateAsync(AlbumUpdated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbumByID(int id)
        {
            Album Album;
            try
            {
                Album = await _AlbumRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            await _AlbumRepository.DeleteAsync(Album);
            return NoContent();
        }
    }
}

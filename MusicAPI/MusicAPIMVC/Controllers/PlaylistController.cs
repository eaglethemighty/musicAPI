using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MusicAPIMVC.Models;
using MusicAPIMVC.Models.DTOs.Playlist;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Controllers
{
    [ApiController]
    [Route("api/playlist")]
    public class PlaylistController : ControllerBase
    {
        private IRepositoryCRUD<Playlist> _PlaylistRepository { get; init; }

        private readonly IMapper _mapper;

        public PlaylistController(IRepositoryCRUD<Playlist> PlaylistRepository, IMapper mapper)
        {
            _PlaylistRepository = PlaylistRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistReadDTO>>> GetAllPlaylists()
        {
            List<Playlist> AllPlaylists = (await _PlaylistRepository.GetAllAsync()).ToList();

            return Ok(_mapper.Map<List<PlaylistReadDTO>>(AllPlaylists));
        }

        [HttpGet("{id}", Name = "GetSpecificPlaylist")]
        public async Task<ActionResult<IEnumerable<PlaylistReadDTO>>> GetSpecificPlaylist(int id)
        {
            Playlist Playlist = new();

            try
            {
                Playlist = await _PlaylistRepository.GetByIdAsync(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

            return Ok(_mapper.Map<PlaylistReadDTO>(Playlist));
        }

        [HttpPost]
        public async Task<ActionResult<PlaylistReadDTO>> CreatePlaylist(PlaylistCreateDTO PlaylistDTO)
        {
            var Playlist = _mapper.Map<Playlist>(PlaylistDTO);
            await _PlaylistRepository.AddAsync(Playlist);

            var PlaylistRead = _mapper.Map<PlaylistReadDTO>(Playlist);

            return CreatedAtRoute(nameof(GetSpecificPlaylist), new { Id = PlaylistRead.Id }, PlaylistRead);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlaylist(int id, PlaylistUpdateDTO PlaylistDTO)
        {
            Playlist Playlist;
            try
            {
                Playlist = await _PlaylistRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            var PlaylistUpdated = _mapper.Map(PlaylistDTO, Playlist);
            await _PlaylistRepository.UpdateAsync(PlaylistUpdated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlaylistByID(int id)
        {
            Playlist Playlist;
            try
            {
                Playlist = await _PlaylistRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            await _PlaylistRepository.DeleteAsync(Playlist);
            return NoContent();
        }
    }
}

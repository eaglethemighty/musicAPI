using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MusicAPIMVC.Models;
using MusicAPIMVC.Models.DTOs.Song;
using MusicAPIMVC.Repository.Interfaces;

namespace MusicAPIMVC.Controllers
{
    [ApiController]
    [Route("api/song")]
    public class SongsController : ControllerBase
    {
        private IRepositoryCRUD<Song> _SongRepository { get; init; }
        private readonly IMapper _mapper;
        public SongsController(IRepositoryCRUD<Song> SongRepository, IMapper mapper)
        {
            _SongRepository = SongRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetAllSongs()
        {
            List<Song> AllSongs = (await _SongRepository.GetAllAsync()).ToList();

            return Ok(_mapper.Map<List<SongReadDTO>>(AllSongs));
        }

        [HttpGet("{id}", Name = "GetSpecificSong")]
        public async Task<ActionResult<IEnumerable<SongReadDTO>>> GetSpecificSong(int id)
        {
            Song Song = new();

            try
            {
                Song = await _SongRepository.GetByIdAsync(id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
            return Ok(_mapper.Map<SongReadDTO>(Song));
        }

        [HttpPost]
        public async Task<ActionResult<SongReadDTO>> CreateSong(SongCreateDTO SongDTO)
        {
            var Song = _mapper.Map<Song>(SongDTO);
            await _SongRepository.AddAsync(Song);

            Song SongRead;

            try
            {
                SongRead = await _SongRepository.GetByIdAsync(Song.Id);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }

            return CreatedAtRoute(nameof(GetSpecificSong), new { Id = SongRead.Id }, _mapper.Map<SongReadDTO>(SongRead));
        }
/*
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSong(int id, SongUpdateDTO SongDTO)
        {
            Song Song;
            try
            {
                Song = await _SongRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            var SongUpdated = _mapper.Map(SongDTO, Song);
            await _SongRepository.UpdateAsync(SongUpdated);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialSongUpdate(int id, JsonPatchDocument<SongUpdateDTO> patchDocument)
        {
            Song Song;
            try
            {
                Song = await _SongRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            var SongToPatch = _mapper.Map<SongUpdateDTO>(Song);
            patchDocument.ApplyTo(SongToPatch, ModelState);

            if (!TryValidateModel(SongToPatch))
            {
                return ValidationProblem(ModelState);
            }

            await _SongRepository.UpdateAsync(_mapper.Map<Song>(SongToPatch));
            return NoContent();
        }*/

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSongByID(int id)
        {
            Song Song;
            try
            {
                Song = await _SongRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            await _SongRepository.DeleteAsync(Song);
            return NoContent();
        }
    }
}

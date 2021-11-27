using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicAPIMVC.Models;
using MusicAPIMVC.Models.DTOs;
using MusicAPIMVC.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAPIMVC.Controllers
{
    [Route("api/[playlistitem]")]
    [ApiController]
    public class PlaylistItemsController : ControllerBase
    {
        private IRepositoryCRUD<PlaylistItem> _PlaylistItemRepository { get; init; }
        private readonly IMapper _mapper;

        public PlaylistItemsController(IRepositoryCRUD<PlaylistItem> playlistItemRepository, IMapper mapper)
        {
            _PlaylistItemRepository = playlistItemRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlaylistItem(PlaylistItemCreateDTO PlaylistItemDTO)
        {
            var PlaylistItem = _mapper.Map<PlaylistItem>(PlaylistItemDTO);
            await _PlaylistItemRepository.AddAsync(PlaylistItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlaylistItemByID(int id)
        {
            PlaylistItem PlaylistItem;
            try
            {
                PlaylistItem = await _PlaylistItemRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            await _PlaylistItemRepository.DeleteAsync(PlaylistItem);
            return NoContent();
        }
    }
}

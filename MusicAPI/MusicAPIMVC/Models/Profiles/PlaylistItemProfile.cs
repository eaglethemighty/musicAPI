using AutoMapper;
using MusicAPIMVC.Models.DTOs.PlaylistItem;

namespace MusicAPIMVC.Models.Profiles
{
    public class PlaylistItemProfile : Profile
    {
        public PlaylistItemProfile()
        {
            CreateMap<PlaylistItemCreateDTO, PlaylistItem>();
        }
    }
}

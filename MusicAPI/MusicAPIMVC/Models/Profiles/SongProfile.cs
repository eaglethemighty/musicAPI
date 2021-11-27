using AutoMapper;
using MusicAPIMVC.Models.DTOs.Song;

namespace MusicAPIMVC.Models.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongDTO>();
        }
    }
}

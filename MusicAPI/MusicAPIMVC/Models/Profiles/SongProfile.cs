using AutoMapper;
using MusicAPIMVC.Models.DTOs.Song;

namespace MusicAPIMVC.Models.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongReadDTO>()
                .ForMember(dto => dto.ArtistStageName, opt => opt.MapFrom(song => song.Album.Artist.StageName))
                .ForMember(dto => dto.AlbumTitle, opt => opt.MapFrom(song => song.Album.Title));

            CreateMap<SongCreateDTO, Song>();
            CreateMap<SongUpdateDTO, Song>();
        }
    }
}

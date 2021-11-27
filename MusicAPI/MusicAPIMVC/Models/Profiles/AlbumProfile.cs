using AutoMapper;
using MusicAPIMVC.Models.DTOs.Album;
using MusicAPIMVC.Models.DTOs.Song;

namespace MusicAPIMVC.Models.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumReadDTO>()
                .ForMember(dto => dto.ArtistName, opt => opt.MapFrom(album  => album.Artist.StageName))
                .ForMember(dto => dto.NumberOfSongs, opt => opt.MapFrom(album => album.NumberOfSongs));

            CreateMap<AlbumCreateDTO, Album>();
            CreateMap<AlbumUpdateDTO, Album>();

            CreateMap<Song, AlbumReadSongDTO>()
                .ForMember(dto => dto.GenreName, opt => opt.MapFrom(song => song.Genre.Name));
        }
    }
}

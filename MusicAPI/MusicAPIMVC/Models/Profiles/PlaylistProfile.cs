using AutoMapper;
using MusicAPIMVC.Models.DTOs.Playlist;

namespace MusicAPIMVC.Models.Profiles
{
    public class PlaylistProfile : Profile
    {
        public PlaylistProfile()
        {
            CreateMap<Playlist, PlaylistReadDTO>()
                .ForMember(dto => dto.Length, opt => opt.MapFrom(playlist => playlist.Length))
                .ForMember(dto => dto.NumberOfSongs, opt => opt.MapFrom(playlist => playlist.NumberOfSongs));
            CreateMap<PlaylistCreateDTO, Playlist>();
            CreateMap<PlaylistUpdateDTO, Playlist>();

            CreateMap<PlaylistItem, PlaylistReadSong>()
                .ForMember(dto => dto.GenreId, opt => opt.MapFrom(item => item.Song.GenreId))
                .ForMember(dto => dto.AlbumId, opt => opt.MapFrom(item => item.Song.AlbumId))
                .ForMember(dto => dto.SequenceInPlaylist, opt => opt.MapFrom(item => item.SequenceInPlaylist))
                .ForMember(dto => dto.Length, opt => opt.MapFrom(item => item.Song.Length))
                .ForMember(dto => dto.AlbumName, opt => opt.MapFrom(item => item.Song.Album.Title))
                .ForMember(dto => dto.GenreName, opt => opt.MapFrom(item => item.Song.Genre.Name))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(item => item.Song.Name));
        }
    }
}
using AutoMapper;
using MusicAPIMVC.Models.DTOs.Artist;

namespace MusicAPIMVC.Models.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistReadDTO>()
                .ForMember(dto => dto.NumberOfSongs, opt => opt.MapFrom(artist => artist.NumberOfSongs));
            CreateMap<ArtistCreateDTO, Artist>();
            CreateMap<ArtistUpdateDTO, Artist>();

            CreateMap<Album, ArtistReadAlbumDTO>()
                .ForMember(dto => dto.ArtistName, opt => opt.MapFrom(album => album.Artist.StageName));
        }
    }
}

using AutoMapper;
using MusicAPIMVC.Models.DTOs.Genre;

namespace MusicAPIMVC.Models.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreReadDTO>();
            CreateMap<GenreCreateDTO, Genre>();
            CreateMap<GenreUpdateDTO, Genre>();
            CreateMap<Genre, GenreUpdateDTO>();
        }
    }
}

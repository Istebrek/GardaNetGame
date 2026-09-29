using AutoMapper;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreForGameDto>();
        }
    }
}

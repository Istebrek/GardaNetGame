using AutoMapper;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Profiles;

public class GamesProfile : Profile
{
    public GamesProfile()
    {
        CreateMap<Game, GamesOverviewDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.Product.ProductImageUrl));

        CreateMap<Game, GameDetailDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.Product.ProductImageUrl));
    }
}

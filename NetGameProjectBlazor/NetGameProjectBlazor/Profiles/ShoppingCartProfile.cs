using AutoMapper;
using NetGameProjectBlazor.Shared.DTOs;
using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Profiles;

public class ShoppingCartProfile : Profile
{
    public ShoppingCartProfile()
    {
        // DB (BE) --> FE
        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.ShoppingCartItems.Sum(i => i.PriceAtPurchase * i.Quantity)));

		// FE --> DB (BE)
		CreateMap<ShoppingCartCreateDto, ShoppingCart>()
	        .ForMember(dest => dest.Id, opt => opt.Ignore())
	        .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));

	}
}

/* SYNTAX
    CreateMap<SourceType, DestinationType>()
        .ForMember(dest => dest.DestinationProperty, opt => opt.MapFrom(src => src.RelatedEntity.Property)); 
*/
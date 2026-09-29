using AutoMapper;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Profiles;

public class ShoppingCartItemProfile : Profile
{
    public ShoppingCartItemProfile()
    {
        // DB (BE) --> FE
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.Product.ProductImageUrl))
            .ForMember(dest => dest.PriceAtPurchase, opt => opt.MapFrom(src => src.PriceAtPurchase))
            .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.PriceAtPurchase * src.Quantity));

        // FE --> DB (BE)
        CreateMap<ShoppingCartItemCreateDto, ShoppingCartItem>();
        CreateMap<ShoppingCartItemUpdateDto, ShoppingCartItem>();
    }
}

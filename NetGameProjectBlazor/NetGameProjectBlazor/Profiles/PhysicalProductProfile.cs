using AutoMapper;
using NetGameProjectBlazor.Shared.DTOs;
using NetGameProjectBlazor.Entities;

namespace NetGameProjectBlazor.Profiles;

public class PhysicalProductProfile : Profile
{
    public PhysicalProductProfile()
    {
        // Map entity → DTO
        CreateMap<PhysicalProduct, PhysicalProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Product!.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product!.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product!.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product!.Price))
            .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.Product!.ProductImageUrl))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Product!.IsActive))
            .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.StockQuantity));

        // Map DTO → Product (for updates)
        CreateMap<PhysicalProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)) // For updates, not creation
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.ProductImageUrl))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

        // Map DTO → PhysicalProduct (for updates)
        CreateMap<PhysicalProductDto, PhysicalProduct>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.StockQuantity));
    }
}

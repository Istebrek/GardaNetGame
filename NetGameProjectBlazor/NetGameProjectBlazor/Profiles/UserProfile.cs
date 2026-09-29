using AutoMapper;
using NetGameProjectBlazor.Data;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Profiles;

public class UserProfile : Profile
{
    public UserProfile() 
    {
        CreateMap<ApplicationUser, UserDto>().ForMember(dest => dest.Id,
                           otp => otp.MapFrom(scr => scr.Id))
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}".Trim()))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber,
                           opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address,
                           opt => opt.MapFrom(src => src.Address));

        CreateMap<UserDto, ApplicationUser>()                
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
    }

}

using AutoMapper;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Shared.DTOs;

namespace NetGameProjectBlazor.Profiles;

public class PegiProfile : Profile
{
    public PegiProfile()
    {
        CreateMap<Pegi, PegiNameDto>();
          
    }
}

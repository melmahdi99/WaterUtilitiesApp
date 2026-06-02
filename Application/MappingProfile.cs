using AutoMapper;
using Domain;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Building, GetBuildingDto>();
        CreateMap<CreateBuildingDto, Building>();
    }
}

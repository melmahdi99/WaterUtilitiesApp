using System;
using Application.WaterTreatmentPlant;
using AutoMapper;
using Domain;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.WaterTreatmentPlant, ReadWaterTreatmentPlantDto>().ReverseMap();
        CreateMap<CreateWaterTreatmentPlantDto, Domain.WaterTreatmentPlant>();
    }
}

using System;
using Application.WaterTreatmentPlant;
using AutoMapper;
using Domain;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Billing, ReadBillingDto>();
        CreateMap<CreateBillingDto, Billing>();
        CreateMap<Billing, FullBillingDto>();
        CreateMap<FullBillingDto, Billing>();

        CreateMap<Building, GetBuildingDto>();
        CreateMap<CreateBuildingDto, Building>();

        CreateMap<WaterMeter, WaterMeterResponseDTO>();
        CreateMap<CreateWaterMeterDTO, WaterMeter>();
        CreateMap<UpdateWaterMeterDTO, WaterMeter>();
        // CreateMap<UpdateMeterReadingDTO, WaterMeter>()
        //     .ForMember(
        //         destinationMember => destinationMember.MeterReading,
        //         memberOptions => memberOptions.MapFrom(
        //             sourceObject => sourceObject.NewReading
        //         )
        //     );

        CreateMap<Domain.WaterTreatmentPlant, ReadWaterTreatmentPlantDto>().ReverseMap();
        CreateMap<CreateWaterTreatmentPlantDto, Domain.WaterTreatmentPlant>();
    }
}

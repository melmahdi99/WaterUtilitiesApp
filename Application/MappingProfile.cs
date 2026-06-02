using System;
using Application.DTOS;
using AutoMapper;
using Domain;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<WaterMeter, WaterMeterResponseDTO>();

        CreateMap<CreateWaterMeterDTO, WaterMeter>();

        CreateMap<UpdateMeterReadingDTO, WaterMeter>()
            .ForMember(
                destinationMember => destinationMember.MeterReading,
                memberOptions => memberOptions.MapFrom(
                    sourceObject => sourceObject.NewReading
                )
            );
    }
}


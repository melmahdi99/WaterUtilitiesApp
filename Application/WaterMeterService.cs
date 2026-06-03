using System;
using Application.DTOS;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application;

public class WaterMeterService : IWaterMeterService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;


    public WaterMeterService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<WaterMeterResponseDTO> GetByIDAsync(Guid id)
    {
        var meter  = await _context.WaterMeters.FindAsync(id);
        if(meter == null)
        {
            throw new KeyNotFoundException($"Water meter {id} is not found");
        } else
        {
            return _mapper.Map<WaterMeterResponseDTO>(meter);
        }

    }


    public async Task<List<WaterMeterResponseDTO>> GetAllAsync()
    {
        var meters = await _context.WaterMeters.ToListAsync();
        return _mapper.Map<List<WaterMeterResponseDTO>>(meters);
    }



    public async Task<WaterMeterResponseDTO> Create(CreateWaterMeterDTO dto)
    {
         if(dto.MeterReading < 0)
        {
            throw new ArgumentException($"Water meter reading cannot be negative");
        }


        var meter = _mapper.Map<WaterMeter>(dto);

        _context.WaterMeters.Add(meter);
        await _context.SaveChangesAsync();


        return _mapper.Map<WaterMeterResponseDTO>(meter);
        
    }



    public async Task<WaterMeterResponseDTO> UpdateAsync(Guid id, UpdateWaterMeterDTO dto)
    {
        var meter = await _context.WaterMeters.FindAsync(id);
        if(meter == null)
        {
            throw new KeyNotFoundException($"Water meter {id} not found");
        }

        if(dto.MeterReading.HasValue)
        {
            if(dto.MeterReading.Value < 0)
            {
                throw new ArgumentException("Meter reading cannot be negative");
            }
            else
            {
                meter.MeterReading = dto.MeterReading.Value;
            }
        }


        if (dto.IsOnline.HasValue)
        {
            meter.IsOnline = dto.IsOnline.Value;
        }

        await _context.SaveChangesAsync();
        return _mapper.Map<WaterMeterResponseDTO>(meter);
    }


    // public async Task<WaterMeterResponseDTO> UpdatReadingAsync(Guid id, UpdateMeterReadingDTO dto)
    // {
    //     var meter = await _context.WaterMeters.FindAsync(id);
    //     if(meter == null)
    //     {
    //         throw new KeyNotFoundException($"Water meter {id} not found");
    //     }


    //     if(dto.NewReading < 0)
    //     {
    //         throw new ArgumentException($"Water meter reading cannot be negative");
    //     }


    //     meter.MeterReading = dto.NewReading;
    //     await _context.SaveChangesAsync();


    //     return _mapper.Map<WaterMeterResponseDTO>(meter);

    // }



    public async Task DeleteAsync(Guid id)
    {
        var meter = await _context.WaterMeters.FindAsync(id);
        if(meter == null)
        {
            throw new KeyNotFoundException($"Water meter {id} not found");
        }


        _context.WaterMeters.Remove(meter);
        await _context.SaveChangesAsync();
        
    }



}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    //business logic constants
    private const decimal MaxMeterValue = 999_999.999m;
    private const decimal LeakThresholdOccupied = 500m;
    private const decimal LeakThresholdVacant = 50m;
    private const int StaleReadingThresholdHours = 48;


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

        if(dto.BuildingId.HasValue)
        {
            meter.BuildingId = dto.BuildingId.Value;
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


    public async Task<WaterMeterUsageDTO> GetUsageAsync(Guid id)
    {
        var meter = await _context.WaterMeters.FindAsync(id);

        if (meter == null)
        {
        throw new KeyNotFoundException($"Water meter {id} not found");
        }


        var consumption = CalculateConsumption(meter.MeterReading, meter.PreviousReading);


        // estimate time window, default to 24 hours if unknown
        TimeSpan timeWindow;

        if (meter.LastReadingReceivedAt.HasValue)
        {
            timeWindow = DateTimeOffset.UtcNow - meter.LastReadingReceivedAt.Value;
        }
        else
        {
            timeWindow = TimeSpan.FromHours(24);
        }


        
        var flowRate = CalculateFlowRateLitersPerHour(consumption, timeWindow);
        var (isLeak, alertMsg) = DetectPotentialLeak(flowRate);


        return new WaterMeterUsageDTO
        {
             MeterId = meter.Id,
            CurrentReading = meter.MeterReading,
            PreviousReading = meter.PreviousReading,
            Consumption = consumption,
            FlowRatePerHour = flowRate,
            IsPotentialLeak = isLeak,
            AlertMessage = alertMsg
            
        };
        
    }




    public async Task<MeterHealthReportDTO> GetHealthReportAsync(Guid id)
    {
        var meter = await _context.WaterMeters.FindAsync(id);

        if (meter == null)
        {
            throw new KeyNotFoundException($"Water meter {id} not found");
        }

        //48 hour threshold
        var isStale = IsReadingStale(meter.LastReadingReceivedAt, TimeSpan.FromHours(48));


        var status = "Healthy";

        if (!meter.IsOnline)
        {
            status = "Offline";
        }
        else if (isStale)
        {
            status = "Warning: Stale reading";
        }

        // leak check
        if(meter.PreviousReading.HasValue)
        {
            var consumption = CalculateConsumption(meter.MeterReading, meter.PreviousReading);
            var flowRate = CalculateFlowRateLitersPerHour(consumption, TimeSpan.FromHours(24));
            var (isLeak, _) = DetectPotentialLeak(flowRate); //underscore is a dicared value

            if (isLeak)
            {
                status = "Critical: Potential leak detected";
            }

        }

        return new MeterHealthReportDTO
        {
            MeterId = meter.Id,
            IsOnline = meter.IsOnline,
            HasStaleReading = isStale,
            LastReadingReceivedAt = meter.LastReadingReceivedAt,
            HealthStatus = status
        };
        
    }



    public async Task<WaterMeterResponseDTO> SubmitReadingAsync(Guid id, UpdateMeterReadingDTO dto)
    {
        var meter = await _context.WaterMeters.FindAsync(id);

        if (meter == null)
        {
            throw new KeyNotFoundException($"Water meter {id} not found");
        }


        //this validates new reading
        var (isValid, errorMsg) = ValidateReading(dto.NewReading, meter.MeterReading);


        if (!isValid)
            throw new ArgumentException(errorMsg);


        //shift current reading to previous reading before updating
        meter.PreviousReading = meter.MeterReading;
        meter.MeterReading = dto.NewReading;
        meter.LastReadingReceivedAt = DateTimeOffset.UtcNow;


        //flags potential leaks on ingest
        var consumption = CalculateConsumption(dto.NewReading, meter.PreviousReading);
        var flowRate = CalculateFlowRateLitersPerHour(consumption, TimeSpan.FromHours(1));
        var (isLeak, alertMsg) = DetectPotentialLeak(flowRate);

        if (isLeak)
        {
            Console.WriteLine($"LEAK ALERT for meter {id}: {alertMsg}");
        }

         await _context.SaveChangesAsync();
        return _mapper.Map<WaterMeterResponseDTO>(meter);

    }


    
    public static decimal CalculateConsumption(decimal current, decimal? previous)
    {
        if (previous == null) return 0m;

        //reading has increased
        if (current >= previous.Value)
        {
            return current - previous.Value;
        }

        //meter reset to 0 after hitting max
        if (current < 10m && previous.Value > MaxMeterValue - 10m)
        {
            return MaxMeterValue - previous.Value + current;
        }

        return 0m;
    }


    public static decimal CalculateFlowRateLitersPerHour(decimal consumptionCubicMeters, TimeSpan timeWindow)
    {
        if (timeWindow.TotalHours <= 0) return 0m;


        // 1 m³ = 1,000 liters
        var consumptionLiters = consumptionCubicMeters * 1000m;
        return consumptionLiters / (decimal)timeWindow.TotalHours;
    }



    public static (bool IsLeak, string? Message) DetectPotentialLeak(decimal flowRateLitersPerHour, bool buildingOccupied = true)
    {
        //suspicous water usage if building is unoccupied 
        const decimal VacantBuildingThreshold = 50m; 

        //suspicouse water usage if builing is occupied 
        const decimal OccupiedBuildingThreshold = 500m;

        var threshold = buildingOccupied ? OccupiedBuildingThreshold : VacantBuildingThreshold;

        if (flowRateLitersPerHour > threshold * 2) // possible leak
        {
            return (true, $"Critical: Flow rate {flowRateLitersPerHour:N1} L/h exceeds critical threshold ({threshold * 2:N1} L/h)"); 
        } else if (flowRateLitersPerHour > threshold)
        {   //returns warning
            return (true, $"Warning: Flow rate {flowRateLitersPerHour:N1} L/h exceeds normal threshold ({threshold:N1} L/h)");
        }
        return (false, null);
    }



     //This function checks if a reading is stale or not updated
    public static bool IsReadingStale(DateTimeOffset? lastReceived, TimeSpan threshold)
    {
        if (lastReceived == null) return true;
        return DateTimeOffset.UtcNow - lastReceived > threshold;
    }



    public static (bool IsValid, string? ErrorMessage) ValidateReading(decimal newReading, decimal? previousReading, bool allowDecrease = false)
    {
        if (newReading < 0)
            return (false, "Reading cannot be negative");


        if (previousReading.HasValue && newReading < previousReading.Value && !allowDecrease)
        {
            if (!(newReading < 10m && previousReading.Value > MaxMeterValue - 10m)) //check to see if it is a valid rollover
            {
                return (false, $"Reading decreased from {previousReading.Value} to {newReading} without rollover. Possible meter reset or data error.");
                
            }
        }

        return (true, null);
        
    }



}

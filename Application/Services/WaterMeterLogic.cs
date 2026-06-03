using System;

namespace Application.Services;

public static class WaterMeterLogic
{
    private const decimal MaxMeterValue = 999_999.999m;


    // Calculates consumption between two readings
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


    // this function detects potential leaks based on flow rate thresholds
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


    //THis function Validates a new reading before accepting it
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

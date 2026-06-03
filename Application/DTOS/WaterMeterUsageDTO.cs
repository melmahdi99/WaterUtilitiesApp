using System;

namespace Application.DTOS;

public class WaterMeterUsageDTO
{
    public Guid MeterId { get; set; }
    public decimal CurrentReading { get; set; }
    public decimal? PreviousReading { get; set; }
    public decimal Consumption { get; set; } //  Current - Previous
    public decimal FlowRatePerHour { get; set; } // Liters/hour estimate
    public bool IsPotentialLeak { get; set; }
    public string? AlertMessage { get; set; }

}

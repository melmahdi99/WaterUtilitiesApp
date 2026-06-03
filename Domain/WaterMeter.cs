using System;

namespace Domain;

public class WaterMeter
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal MeterReading { get; set; }
    public decimal? PreviousReading { get; set; }
    public bool IsOnline { get; set; }

    //FK
    public Guid BuildingId { get; set; }

    public DateTimeOffset? LastReadingReceivedAt { get; set; }
}






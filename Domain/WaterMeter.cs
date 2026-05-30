using System;

namespace Domain;

public class WaterMeter
{
    public Guid Id { get; set; }
    public decimal MeterReading { get; set; }
    public bool IsOnline { get; set; }

    //FK
    public Guid BuildingId { get; set; }
}

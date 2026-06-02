using System;

namespace Application.DTOS;

public class WaterMeterResponseDTO
{
    public Guid Id { get; set; }

    public decimal MeterReading { get; set; }
    public bool IsOnline { get; set; }
    public Guid BuildingId { get; set; }

}

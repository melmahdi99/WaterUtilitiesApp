using System.ComponentModel.DataAnnotations;

namespace Application;

public class CreateWaterMeterDTO
{
    [Required]
    public Guid BuildingId { get; set; }
    [Range(0, 9_999_999.999)]
    public decimal MeterReading { get; set; } = 0m;

    public bool IsOnline { get; set; } = true;

}
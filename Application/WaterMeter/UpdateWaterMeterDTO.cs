using System.ComponentModel.DataAnnotations;

namespace Application;

public class UpdateWaterMeterDTO
{
    public Guid BuildingId { get; set; }
    [Range(0, 9_999_999.999)]
    public decimal? MeterReading { get; set; }
    public bool? IsOnline { get; set; }

}
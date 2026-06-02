using System;

namespace Application.WaterTreatmentPlant;

public class ReadWaterTreatmentPlantDto
{
    public Guid Id { get; set; }
    public int WaterVolumeCapacity { get; set; }
    public required string ServiceArea { get; set; }
    public decimal Turbidity { get; set; }
}

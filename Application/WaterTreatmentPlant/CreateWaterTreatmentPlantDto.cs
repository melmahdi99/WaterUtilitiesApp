using System;

namespace Application.WaterTreatmentPlant;

public class CreateWaterTreatmentPlantDto
{
    public int WaterVolumeCapacity { get; set; }
    public required string ServiceArea { get; set; }
    public decimal Turbidity { get; set; }
}

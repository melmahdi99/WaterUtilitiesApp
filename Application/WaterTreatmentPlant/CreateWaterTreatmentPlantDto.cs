using System;

namespace Application.WaterTreatmentPlant;

public class CreateWaterTreatmentPlantDto
{
    public int WaterVolumeCapacity { get; set; }
    public decimal Turbidity { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}
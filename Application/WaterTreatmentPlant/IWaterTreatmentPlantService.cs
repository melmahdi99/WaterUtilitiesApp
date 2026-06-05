using System;

namespace Application.WaterTreatmentPlant;

public interface IWaterTreatmentPlantService
{
    public Task<IEnumerable<ReadWaterTreatmentPlantDto>> GetWaterTreatmentPlantsAsync();
    public Task<ReadWaterTreatmentPlantDto> GetWaterTreatmentPlantAsync(Guid id);
    public Task<ReadWaterTreatmentPlantDto> CreateWaterTreatmentPlant(CreateWaterTreatmentPlantDto dto);
    public Task UpdateWaterTreatmentPlant(ReadWaterTreatmentPlantDto dto);
    public Task DeleteWaterTreatmentPlant(Guid id);
    public Task<IEnumerable<GetBuildingDto>> GetBuildingsInServiceAreaAsync(double Lat, double Long, double radius);

}
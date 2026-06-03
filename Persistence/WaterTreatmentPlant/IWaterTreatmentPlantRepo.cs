using System;
using Domain;
namespace Persistence;

public interface IWaterTreatmentPlantRepo
{
    public Task<IEnumerable<Domain.WaterTreatmentPlant>> GetWaterTreatmentPlantsAsync();
    public Task<Domain.WaterTreatmentPlant> GetWaterTreatmentPlantAsync(Guid id);
    public Task<Domain.WaterTreatmentPlant> CreateWaterTreatmentPlant(Domain.WaterTreatmentPlant waterTreatmentPlant);
    public Task<Domain.WaterTreatmentPlant> UpdateWaterTreatmentPlant(Domain.WaterTreatmentPlant waterTreatmentPlant);
    public Task DeleteWaterTreatmentPlant(Guid id);
}
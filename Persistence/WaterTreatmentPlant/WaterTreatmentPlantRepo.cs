using System;
using Persistence.WaterTreatmentPlant;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class WaterTreatmentPlantRepo : IWaterTreatmentPlantRepo
{
    private readonly AppDbContext _context;

    public WaterTreatmentPlantRepo (AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domain.WaterTreatmentPlant>> GetWaterTreatmentPlantsAsync()
    {
        var waterTreatmentPlants = await _context.WaterTreatmentPlants.AsNoTracking().ToListAsync();
        return waterTreatmentPlants;
    }

    public async Task<Domain.WaterTreatmentPlant> GetWaterTreatmentPlantAsync(Guid id)
    {
        var waterTreatmentPlant = await _context.WaterTreatmentPlants.FindAsync(id);
        return waterTreatmentPlant!;
    }

    public async Task<Domain.WaterTreatmentPlant> CreateWaterTreatmentPlant(Domain.WaterTreatmentPlant waterTreatmentPlant)
    {
        _context.WaterTreatmentPlants.Add(waterTreatmentPlant);
        await _context.SaveChangesAsync();
        return waterTreatmentPlant;
    }

    //Updates a waterTreatmentPlant that has a matching id
    public async Task<Domain.WaterTreatmentPlant> UpdateWaterTreatmentPlant(Domain.WaterTreatmentPlant waterTreatmentPlant)
    {
        _context.WaterTreatmentPlants.Update(waterTreatmentPlant);
        await _context.SaveChangesAsync();
        return waterTreatmentPlant;
    }

    //Finds a treatment plant in our DbSet with a matching Id and deletes it
    public async Task DeleteWaterTreatmentPlant(Guid id) =>
        await _context.WaterTreatmentPlants.Where(w => w.Id == id).ExecuteDeleteAsync();
    
}

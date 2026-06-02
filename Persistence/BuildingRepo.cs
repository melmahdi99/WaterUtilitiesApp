using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class BuildingRepo : IBuildingRepo
{
    private readonly AppDbContext _context;

    public BuildingRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Building>> GetBuildingAsync()
    {
        return await _context.Buildings.ToListAsync();
    }

    public async Task<Building?> FindBuildingById(Guid id)
    {
        return await _context.Buildings.FindAsync(id);
    }

    public async Task<string> CreateBuilding(Building building)
    {
        _context.Buildings.Add(building);
        await _context.SaveChangesAsync();
        return building.Id.ToString();
    }

    public async Task DeleteBuilding(Guid id)
    {
        var building = await _context.Buildings.FindAsync(id);
        if (building == null) throw new KeyNotFoundException("Building not found");
        await _context.Buildings.Where(a => a.Id == id).ExecuteDeleteAsync();
    }

    public async Task EditBuilding(Building building)
    {
        var a = await _context.Buildings.FindAsync(building.Id);

        if (a == null) 
        throw new KeyNotFoundException("Building not found");

        a.BuildingType = building.BuildingType;
        a.StreetNum = building.StreetNum;
        a.StreetName = building.StreetName;
        a.StreetSuffix = building.StreetSuffix;
        a.ZipCode = building.ZipCode;
        a.KingdomName = building.KingdomName;
        a.Latitude = building.Latitude;
        a.Longitude = building.Longitude;

        await _context.SaveChangesAsync();
    }
}

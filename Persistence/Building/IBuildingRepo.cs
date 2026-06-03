using Domain;

namespace Persistence;

public interface IBuildingRepo
{
    public Task<IEnumerable<Building>> GetBuildingAsync();
    public Task<Building?> FindBuildingById(Guid id);
    public Task<string> CreateBuilding(Building building);
    public Task DeleteBuilding(Guid id);
    public Task EditBuilding(Building building);
}
using Domain;

namespace Application;

public interface IBuildingService
{
    Task<IEnumerable<GetBuildingDto>> GetBuildingsAsync();
    Task<GetBuildingDto?> GetBuildingById(Guid id);
    Task<GetBuildingDto> CreateBuilding(CreateBuildingDto dto);
    Task EditBuilding(Guid id, CreateBuildingDto dto);
    Task DeleteBuilding(Guid id);
}
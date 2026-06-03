using AutoMapper;
using Domain;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application;

public class BuildingService : IBuildingService
{
    private readonly IBuildingRepo _repo;
    private readonly IMapper _mapper;
    private readonly ILogger<BuildingService> _logger;
    private readonly Random _random = new();

  
    private record KingdomRegion(
        string Name,
        decimal CenterLat,
        decimal CenterLong,
        decimal Range = 0.15m
    );

     private static readonly IReadOnlyList<KingdomRegion> _kingdoms = new List<KingdomRegion>
    {
        new KingdomRegion("Ethonia",    40.0m,  -105.0m),
        new KingdomRegion("Southport",  42.0m,  -107.0m),
        new KingdomRegion("Westhold",   38.5m,  -103.0m),
        new KingdomRegion("Northreach", 41.5m,  -101.5m)
    };

     private static readonly Dictionary<string, KingdomRegion> _kingdomLookup =
        _kingdoms.ToDictionary(k => k.Name, StringComparer.OrdinalIgnoreCase);


    public BuildingService(IBuildingRepo repo, IMapper mapper, ILogger<BuildingService> logger)
    {
        _repo = repo;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IEnumerable<GetBuildingDto>> GetBuildingsAsync()
    {
        _logger.LogInformation("Get all buildings");
        var buildings = await _repo.GetBuildingAsync();
        if (!buildings.Any())
            _logger.LogWarning("No buildings found");
        return _mapper.Map<IEnumerable<GetBuildingDto>>(buildings);
    }

    public async Task<GetBuildingDto?> GetBuildingById(Guid id)
    {
        _logger.LogInformation("Get building by id");
        var building = await _repo.FindBuildingById(id);
        if (building == null)
            _logger.LogWarning("Building not found");
        return building == null ? null : _mapper.Map<GetBuildingDto>(building);
    }

    public async Task<GetBuildingDto> CreateBuilding(CreateBuildingDto dto)
    {
        _logger.LogInformation("Create building");
        var building = _mapper.Map<Building>(dto);
        if (_kingdomLookup.TryGetValue(dto.KingdomName, out var kingdom))
        {
            building.Latitude  = kingdom.CenterLat  + (decimal)(_random.NextDouble() * (double)(kingdom.Range * 2) - (double)kingdom.Range);
            building.Longitude = kingdom.CenterLong + (decimal)(_random.NextDouble() * (double)(kingdom.Range * 2) - (double)kingdom.Range);
        }
        building.Id = Guid.NewGuid();
        await _repo.CreateBuilding(building);
        _logger.LogInformation("Building created successfully");
        return _mapper.Map<GetBuildingDto>(building);
    }

    public async Task EditBuilding(Guid id, CreateBuildingDto dto)
    {
        _logger.LogInformation("Edit building");
        var building = _mapper.Map<Building>(dto);
        if (_kingdomLookup.TryGetValue(dto.KingdomName, out var kingdom))
        {
            building.Latitude  = kingdom.CenterLat  + (decimal)(_random.NextDouble() * (double)(kingdom.Range * 2) - (double)kingdom.Range);
            building.Longitude = kingdom.CenterLong + (decimal)(_random.NextDouble() * (double)(kingdom.Range * 2) - (double)kingdom.Range);
        }
        building.Id = id;
        await _repo.EditBuilding(building);
    }

    public async Task DeleteBuilding(Guid id)
    {
        _logger.LogInformation("Delete building");
        await _repo.DeleteBuilding(id);
    }
}
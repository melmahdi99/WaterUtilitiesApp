using System;
using AutoMapper;
using Domain;
using Persistence;

namespace Application.WaterTreatmentPlant;

public class WaterTreatmentPlantService: IWaterTreatmentPlantService
{
    //
    private readonly IWaterTreatmentPlantRepo _repo;
    private readonly IMapper _mapper;

    public WaterTreatmentPlantService(IWaterTreatmentPlantRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadWaterTreatmentPlantDto>> GetWaterTreatmentPlantsAsync()
    {
        var waterTreatmentPlants = await _repo.GetWaterTreatmentPlantsAsync();
        return waterTreatmentPlants.Select(w => _mapper.Map<ReadWaterTreatmentPlantDto>(w));
    }

    public async Task<ReadWaterTreatmentPlantDto> GetWaterTreatmentPlantAsync(Guid id)
    {
        var waterTreatmentPlant = await _repo.GetWaterTreatmentPlantAsync(id);
        return _mapper.Map<ReadWaterTreatmentPlantDto>(waterTreatmentPlant);
    }

    public async Task UpdateWaterTreatmentPlant(ReadWaterTreatmentPlantDto dto)
    {
        var entity = _mapper.Map<Domain.WaterTreatmentPlant>(dto);
        await _repo.UpdateWaterTreatmentPlant(entity);
    }

    public async Task<ReadWaterTreatmentPlantDto> CreateWaterTreatmentPlant(CreateWaterTreatmentPlantDto dto)
    {
        var waterTreatmentPlant = _mapper.Map<Domain.WaterTreatmentPlant>(dto);
        var wtp = await _repo.CreateWaterTreatmentPlant(waterTreatmentPlant);
        return _mapper.Map<ReadWaterTreatmentPlantDto>(wtp);
    }

    public async Task DeleteWaterTreatmentPlant(Guid id)
    {
        await _repo.DeleteWaterTreatmentPlant(id);
    }
}
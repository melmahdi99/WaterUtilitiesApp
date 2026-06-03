using System;
using Application.DTOS;

namespace Application;

public interface IWaterMeterService
{
    Task<WaterMeterResponseDTO> GetByIDAsync(Guid id);
    Task<List<WaterMeterResponseDTO>> GetAllAsync();
    Task<WaterMeterResponseDTO> Create(CreateWaterMeterDTO dto);
    Task<WaterMeterResponseDTO> UpdateAsync(Guid id, UpdateWaterMeterDTO dto);
    // Task<WaterMeterResponseDTO> UpdatReadingAsync(Guid id, UpdateMeterReadingDTO dto);
    Task DeleteAsync(Guid id);

}

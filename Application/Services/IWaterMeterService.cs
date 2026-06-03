using System;
using Application.DTOS;

namespace Application;

public interface IWaterMeterService
{
    Task<WaterMeterResponseDTO> GetByIDAsync(Guid id);
    Task<List<WaterMeterResponseDTO>> GetAllAsync();
    Task<WaterMeterResponseDTO> Create(CreateWaterMeterDTO dto);
    Task<WaterMeterResponseDTO> UpdateAsync(Guid id, UpdateWaterMeterDTO dto);
    
    Task DeleteAsync(Guid id);
    //business logic
    Task<WaterMeterUsageDTO> GetUsageAsync(Guid id);
    Task<MeterHealthReportDTO> GetHealthReportAsync(Guid id);
    Task<WaterMeterResponseDTO> SubmitReadingAsync(Guid id, UpdateMeterReadingDTO dto);

}

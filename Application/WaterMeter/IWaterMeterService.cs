namespace Application;

public interface IWaterMeterService
{
    Task<WaterMeterResponseDTO> GetByIDAsync(Guid id);
    Task<List<WaterMeterResponseDTO>> GetAllAsync();
    Task<WaterMeterResponseDTO> Create(CreateWaterMeterDTO dto);
    Task<WaterMeterResponseDTO> UpdateAsync(Guid id, UpdateWaterMeterDTO dto);
    // Task<WaterMeterResponseDTO> UpdateReadingAsync(Guid id, UpdateMeterReadingDTO dto);
    Task DeleteAsync(Guid id);

}
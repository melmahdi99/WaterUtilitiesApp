using System;
using Domain;

namespace Persistence;

public interface IWaterMeterRepo
{
    public Task<IEnumerable<WaterMeter>> GetAllAsync();
    public Task<WaterMeter?> GetByIdAsync(Guid id);
    public Task<string> Create(WaterMeter watermeter);
    public Task DeleteAsync(Guid id);
    public Task UpdateAsync(WaterMeter watermeter);

}

using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistence;

public class WaterMeterRepo :  IWaterMeterRepo
{
     private readonly AppDbContext _context;

    public WaterMeterRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WaterMeter>> GetAllAsync()
    {
        return await _context.WaterMeters.ToListAsync();
    }

    public async Task<WaterMeter?> GetByIdAsync(Guid id)
    {
        return await _context.WaterMeters.FindAsync(id);
    }

    public async Task<string> Create(WaterMeter WaterMeter)
    {
        _context.WaterMeters.Add(WaterMeter);
        await _context.SaveChangesAsync();
        return WaterMeter.Id.ToString();
    }

    public async Task DeleteAsync(Guid id)
    {
        var WaterMeter = await _context.WaterMeters.FindAsync(id);
        if (WaterMeter == null) throw new KeyNotFoundException("WaterMeter not found");
        await _context.WaterMeters.Where(a => a.Id == id).ExecuteDeleteAsync();
    }

    public async Task UpdateAsync(WaterMeter WaterMeter)
    {
        var a = await _context.WaterMeters.FindAsync(WaterMeter.Id);

        if (a == null) 
        throw new KeyNotFoundException("WaterMeter not found");

        a.MeterReading = WaterMeter.MeterReading;
        a.IsOnline = WaterMeter.IsOnline;
        
        

        await _context.SaveChangesAsync();
    }

}
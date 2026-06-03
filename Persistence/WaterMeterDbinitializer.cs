using System;
using Domain;
namespace Persistence;

public class WaterMeterDbinitializer
{
    public WaterMeterDbinitializer(AppDbContext context, Guid buildingIdMain, Guid buildingIdIndustrial)
    {
        context.Database.EnsureCreated();

        

        var meters = new[]
        {
            new WaterMeter
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                MeterReading = 1250.750m,
                IsOnline = true,
                BuildingId = buildingIdMain,
                PreviousReading = 1200.000m, // Simulate prior reading
                LastReadingReceivedAt = DateTimeOffset.UtcNow.AddHours(-12)
            },

            new WaterMeter
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                MeterReading = 890.000m,
                IsOnline = false,
                BuildingId = buildingIdIndustrial,
                PreviousReading = 1200.000m, // Simulate prior reading
                LastReadingReceivedAt = DateTimeOffset.UtcNow.AddHours(-12)
            },

            new WaterMeter
            {
                Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                MeterReading = 5420.333m,
                IsOnline = true,
                BuildingId = buildingIdMain,
                PreviousReading = 1200.000m, // Simulate prior reading
                LastReadingReceivedAt = DateTimeOffset.UtcNow.AddHours(-12)
            }
        };

        context.WaterMeters.AddRange(meters);
        context.SaveChanges();
    }
}

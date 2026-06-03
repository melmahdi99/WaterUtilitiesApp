using System;

namespace Application.DTOS;

public class MeterHealthReportDTO
{
     public Guid MeterId { get; set; }
    public bool IsOnline { get; set; }
    public bool HasStaleReading { get; set; }
    public DateTimeOffset? LastReadingReceivedAt { get; set; }
    public string HealthStatus { get; set; } = "Unknown"; // "Healthy", "Warning", "Critical"

}

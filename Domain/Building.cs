using System;

namespace Domain;

public class Building
{
    public Guid Id { get; set; }
    public required string BuildingType { get; set; }
    public int StreetNum { get; set; }
    public string StreetName { get; set; }
    public string StreetSuffix { get; set; }
    public int ZipCode { get; set; }
    public string KingdomName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    //FKs
    public int WaterMeterId { get; set; }
}

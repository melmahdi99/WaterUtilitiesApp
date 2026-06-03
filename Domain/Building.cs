using System;

namespace Domain;

public class Building
{
    public Guid Id { get; set; }
    public required string BuildingType { get; set; }
    public int StreetNum { get; set; }
    public required string StreetName { get; set; }
    public required string StreetSuffix { get; set; }
    public int ZipCode { get; set; }
    public required string CityName { get; set; }
    public required string KingdomName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    //unsure of the plan for this one
    public required string ServiceArea { get; set; }

    //FKs
    public Guid AddressId { get; set; }

    //I think this is a foreign key?
    public int WaterMeterId { get; set; }
}

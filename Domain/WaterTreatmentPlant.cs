using System;
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class WaterTreatmentPlant
{
    [Key]
    public Guid Id { get; set; }
    public int WaterVolumeCapacity { get; set; }
    public required string ServiceArea { get; set; }
    public decimal Turbidity { get; set; }
    public int StreetNum { get; set; }
    public string StreetName { get; set; }
    public string StreetSuffix { get; set; }
    public int ZipCode { get; set; }
    public string KingdomName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    //FKs
    // Not sure if we're keeping this
    // public Guid WaterCompanyId { get; set; }
}

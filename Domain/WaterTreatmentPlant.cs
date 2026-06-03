using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class WaterTreatmentPlant
{
    [Key] 
    public Guid Id { get; set; } = Guid.NewGuid();
    public int WaterVolumeCapacity { get; set; }
    // public required string ServiceArea { get; set; }
    [Column(TypeName ="decimal(7,2)")]
    public decimal Turbidity { get; set; }
    public int StreetNum { get; set; }
    public string StreetName { get; set; }
    public string StreetSuffix { get; set; }
    public int ZipCode { get; set; }
    public string KingdomName { get; set; }
    [Column(TypeName ="decimal(10,5)")]
    public decimal Latitude { get; set; }
    [Column(TypeName ="decimal(10,5)")]
    public decimal Longitude { get; set; }
    //FKs
    // Not sure if we're keeping this
    // public Guid WaterCompanyId { get; set; }
}

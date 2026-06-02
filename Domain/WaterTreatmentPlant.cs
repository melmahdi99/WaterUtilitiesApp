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
    
    //FKs
    // Not sure if we're keeping this
    // public Guid WaterCompanyId { get; set; }
}

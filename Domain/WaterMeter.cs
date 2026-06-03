using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class WaterMeter
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName ="decimal(7, 2)")]
    public decimal MeterReading { get; set; }
    public bool IsOnline { get; set; }

    //FK
    [ForeignKey(nameof(Building))]
    public Guid BuildingId { get; set; }
}

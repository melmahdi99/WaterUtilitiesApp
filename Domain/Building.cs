
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Building
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string BuildingType { get; set; }
    public int StreetNum { get; set; }
    public string StreetName { get; set; }
    public string StreetSuffix { get; set; }

    [Range(10000, 99999)]
    public int ZipCode { get; set; }
    public string KingdomName { get; set; }

    [Column(TypeName = "decimal(10,5)")]
    public decimal Latitude { get; set; }
    [Column(TypeName = "decimal(10,5)")]
    public decimal Longitude { get; set; }
}

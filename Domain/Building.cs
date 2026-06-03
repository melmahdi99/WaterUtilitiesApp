using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Building
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column(TypeName="nvarchar(55)")]
    public required string BuildingType { get; set; }
    public int StreetNum { get; set; }
    [Column(TypeName="nvarchar(55)")]
    public required string StreetName { get; set; }
    [Column(TypeName="nvarchar(55)")]
    public string? StreetSuffix { get; set; }
    public int ZipCode { get; set; }
    [Column(TypeName="nvarchar(55)")]
    public required string KingdomName { get; set; }
    [Column(TypeName="decimal(10,5)")]
    public decimal Latitude { get; set; }
    [Column(TypeName="decimal(10,5)")]
    public decimal Longitude { get; set; }
}

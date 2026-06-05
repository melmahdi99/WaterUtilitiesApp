using System.ComponentModel.DataAnnotations;

public class CreateBuildingDto
{
    public required string BuildingType { get; set; }
    public int StreetNum { get; set; }
    public required string StreetName { get; set; }
    public required string StreetSuffix { get; set; }

    [Range(10000, 99999)]
    public int ZipCode { get; set; }
    public required string KingdomName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}
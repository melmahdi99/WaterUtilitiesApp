namespace Application;

public class GetBuildingDto
{
    public Guid Id { get; set; }
    public required string BuildingType { get; set; }
    public int StreetNum { get; set; }
    public required string StreetName { get; set; }
    public required string StreetSuffix { get; set; }
    public int ZipCode { get; set; }
    public required string KingdomName { get; set; }
    public int WaterMeterId { get; set; }
}

using Domain;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Buildings.Any()) 
            return;

        var random = new Random();

        var buildingTypes = new List<string>
        {
            "Cottage", "Tavern", "Tower", "Castle", "Public Hall", "Forge",
            "Shop", "Inn", "Mill", "Cathedral", "Farm"
        };
        var streetNames = new List<string>
        {
            "Amber", "Ancient Oak", "Arcane", "Ashen", "Azure",
            "Blackstone", "Briarwood", "Brightforge", "Crystal Brook",
            "Dragonfire", "Emerald Grove", "Frostfall", "Golden Griffin",
            "Hearthstone", "Ironforge", "King", "Moonlit", "Ravencrest",
            "Silverbrook", "Stormwatch", "Willowshade", "Golden Meadow",
            "Frost Oak", "Skyfire", "Winter Watch", "Riverbend", "Copper Leaf",
            "Westerly", "Wandering", "Verdant", "Summerberry", "Runic",
            "White Stag", "Wildflower", "Obsidian", "Oakshade", "Knightwatch",
            "Jester", "Firefly", "Moonstone", "Hollow Creek", "Lantern Lit", "Easterly"
        };
        var streetSuffixes = new List<string> 
        { 
            "Way", "Road", "Street", "Lane", "Path" 
        };
        var cityNames = new List<string>
        {
            "Ashenvale", "Brightwater", "Coldhaven", "Dawnmere", "Elderstone",
            "Frostholm", "Grimwatch", "Hearthford", "Ironpeak", "Jadehollow"
        };
        var kingdomNames = new List<string>
        {
            "Ethonia", "Southport", "Westhold", "Northreach"
        };

        var kingdoms = new List<(string Name, decimal Lat, decimal Lon)>
        {
            ("Ethonia", 40.0m, -105.0m),
            ("Southport", 42.0m, -107.0m),
            ("Westhold", 38.5m, -103.0m),
            ("Northreach", 41.5m, -101.5m)
        };

        var buildings = new List<Building>();

        for (int i = 0; i < 1000; i++)
        {
            var kingdom = kingdoms[random.Next(kingdoms.Count)];

            var lat = kingdom.Lat + (decimal)(random.NextDouble() * 0.3 - 0.15);
            var lon = kingdom.Lon + (decimal)(random.NextDouble() * 0.3 - 0.15);

            buildings.Add(new Building
        {
            Id = Guid.NewGuid(),
            BuildingType = buildingTypes[random.Next(buildingTypes.Count)],
            StreetNum = random.Next(1, 9999),
            StreetName = streetNames[random.Next(streetNames.Count)],
            StreetSuffix = streetSuffixes[random.Next(streetSuffixes.Count)],
            ZipCode = random.Next(10000, 99999),
            KingdomName = kingdom.Name, 
            Latitude = lat,
            Longitude = lon,
        });
        }

        context.Buildings.AddRange(buildings);
        await context.SaveChangesAsync();
    }
}

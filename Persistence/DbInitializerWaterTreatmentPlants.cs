using System;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence;

public class DbInitializerWaterTreatmentPlant
{
    public static async Task SeedData(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<string>{"Admin", "User"};
        foreach(var role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        if (!userManager.Users.Any())
        {
            var users = new List<User>
            {
                new User{FirstName = "John", LastName = "Doe", UserName = "jdoe@test.com", Email= "jdoe@test.com"},
                new User{FirstName = "Tom", LastName = "Felton", UserName = "tom@test.com", Email= "tom@test.com"},
                new User{FirstName = "Jane", LastName = "Doe", UserName = "jane@test.com", Email= "jane@test.com"}
            };

            foreach(var user in users)
            {
                await userManager.CreateAsync(user, "Pa$$w0rd");
                if(!(user.UserName == "jdoe@test.com"))
                {
                    await userManager.AddToRoleAsync(user, "User");
                } else 
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }

        if (context.WaterTreatmentPlants.Any()) 
            return;

        var random = new Random();
        var waterTreatmentPlants = new List<Domain.WaterTreatmentPlant>();

        var waterVolumeCapacity = new List<int>
        {
            17000000, 22000000, 10000000, 24000000, 60000000, 45000000, 
            65000000, 11000000, 80000000, 12500000, 20000000, 15000000
        };

        var turbidity = new List<decimal>
        {
            12.40m, 0.03m, 11.01m, 10.06m, 35.30m, 40.32m, 0.30m,
            9.23m, 18.10m, 0.95m, 4.03m, 16.34m, 17.34m, 34.9m
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

        

        for (int i = 0; i < 200; i++)
        {
            var kingdom = kingdoms[random.Next(kingdoms.Count)];

            var lat = kingdom.Lat + (decimal)(random.NextDouble() * 0.3 - 0.15);
            var lon = kingdom.Lon + (decimal)(random.NextDouble() * 0.3 - 0.15);

            waterTreatmentPlants.Add(new Domain.WaterTreatmentPlant
            {
                Id = Guid.NewGuid(),
                WaterVolumeCapacity = waterVolumeCapacity[random.Next(waterVolumeCapacity.Count)],
                Turbidity = turbidity[random.Next(turbidity.Count)],
                StreetNum = random.Next(1, 9999),
                StreetName = streetNames[random.Next(streetNames.Count)],
                StreetSuffix = streetSuffixes[random.Next(streetSuffixes.Count)],
                ZipCode = random.Next(10000, 99999),
                KingdomName = kingdom.Name, 
                Latitude = lat,
                Longitude = lon
            });
        }

        context.WaterTreatmentPlants.AddRange(waterTreatmentPlants);
        await context.SaveChangesAsync();
    }
}
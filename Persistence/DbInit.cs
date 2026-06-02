using Domain;

namespace Persistence;

public class DbInit
{
    public static async Task SeedData(AppDbContext context)
    {
        if (context.Buildings.Any()) return;

        var buildings = new List<Building>();

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
        
        // populating the Customers DbSet
        // 200 customers
        var customers = new List<Customer>();

            var firstNames = new List<string>
            {
                "Kang", "Preminin", "Kasiya", "Tasnim", "Artur", "Austin",
                "Benita", "Aksenov", "Ptolemy", "Ishii", "Thuy-Doan", "Rodrigues",
                "Bebti", "Datah", "Jivan", "Goto", "Yun-Jeong", "Shukla",
                "Hayat", "Tayco", "Alejandro", "Awan", "Vitaliya", "Salg",
                "Ndu", "Sajib", "Milana", "Maher", "Agung", "Afanasyev" 
            };
            var lastNames = new List<string>
            {
                "Hilario", "Kǒng", "Jaylen", "Gù", "Ega", "Pi",
                "Guozhi", "Olaiya", "Jitu", "Jones", "Olamina", "Maurya",
                "Chenguang", "Siy", "Shawn", "Hartono", "Angel", "Fàn",
                "Sukarno", "Yasser", "Tiago", "Matheos", "Pedro", "Ariana",
                "de Perio", "Maaz", "Hoai", "Satomi", "Felix", "Urmi"

            };
            for (int i = 0; i < 200; i++)
            {
                customers.Add(new Customer
                {
                    FirstName = firstNames[random.Next(firstNames.Count)],
                    LastName = lastNames[random.Next(lastNames.Count)]
                });
            }

        // populating the WaterMeters DbSet 
        // creates 1 WaterMeter per Customer, but does not attach the WaterMeter to the Customer
        var meters = new List<WaterMeter>();
            foreach (var c in customers) {
                var b = random.Next(0, 1);
                var Bool = false;
                if (b == 1)
                {
                    Bool = true;
                }
                var randBuilding = random.Next(buildings.Count);
                new WaterMeter
                {
                    Id = Guid.NewGuid(),
                    MeterReading = random.Next(0, 99999) * 0.999m,
                    IsOnline = Bool,
                    BuildingId = buildings[randBuilding].Id
                };
            }

        var billings = new List<Billing>();
        var metersCopy = meters;
            foreach (var c in customers)
            {
                var i = random.Next(metersCopy.Count);
                billings.Add(new Billing
                    {
                        PriceRate = random.Next(1, 100), // this should be in dollars per gallon
                        TotalAmountDue = 0, //this should be in dollars, calculated by multiplying the PriceRate by the MeterReading field in the WaterMeter table
                        DueDate = DateOnly.FromDateTime(DateTime.Now).AddDays(random.Next(-10, 30)), //FromDateTime is a method that converts DateTime to DateOnly, this is needed because the AddDays method is for DateTime not DateOnly
                        TimePaid = DateTime.Now.AddDays(random.Next(-10,30)), //adds a random time 
                        IsPaid = false, //this should be determined through a conditional that determines whether the TimePaid is after the DueDate
                        CustomerId = c.Id,
                        WaterMeterId = metersCopy[i].Id
                    }
                );
                metersCopy.Remove(metersCopy[i]);

            }


            foreach(var billing in billings) //loop to correctly assign true values to IsPaid if the TimePaid is before the DueDate
            {
                if (billing.TimePaid < billing.DueDate.ToDateTime(new TimeOnly(23, 59, 59))) //to compare the 2 variables I converted the DueDate to DateTime from DateOnly assuming the time due is 11:59 PM
                {
                    billing.IsPaid = true;
                };
            };
        
        var waterTreatmentPlants = new List<WaterTreatmentPlant>();

        context.Billings.AddRange(billings);
        context.Buildings.AddRange(buildings);
        context.WaterMeters.AddRange(meters);
        context.Customers.AddRange(customers);
        context.WaterTreatmentPlants.AddRange(waterTreatmentPlants);
        await context.SaveChangesAsync();
    }
}
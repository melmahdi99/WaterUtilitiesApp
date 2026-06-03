using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Billing> Billings { get; set; }
    public required DbSet<Building> Buildings { get; set; }
    public required DbSet<Customer> Customers { get; set; } 
    public required DbSet<WaterMeter> WaterMeters { get; set; }   
    public required DbSet<Domain.WaterTreatmentPlant> WaterTreatmentPlants { get; set; }
       
}

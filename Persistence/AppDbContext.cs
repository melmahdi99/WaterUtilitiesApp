using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext (DbContextOptions options) : DbContext(options)
{
    public DbSet<Billing> Billings { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<WaterMeter> WaterMeters { get; set; }
    public DbSet<WaterTreatmentPlant> WaterTreatmentPlants { get; set; }
       
}

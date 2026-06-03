using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext (DbContextOptions options) : DbContext(options)
{
    public required DbSet<Billing> Billings { get; set; }
    public required DbSet<Building> Buildings { get; set; }
    public required DbSet<Customer> Customers { get; set; } 
    public required DbSet<WaterMeter> WaterMeters { get; set; }   
    public required DbSet<WaterTreatmentPlant> WaterTreatmentPlants { get; set; }
       
}

// entity.Property(e => e.PreviousReading)
//       .HasColumnType("decimal(10,3)")
//       .IsRequired(false); 

// entity.Property(e => e.LastReadingReceivedAt)
//       .IsRequired(false);

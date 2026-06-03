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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(customer => customer.FName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(customer => customer.LName)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasOne(customer => customer.Billing)
                .WithMany()
                .HasForeignKey(customer => customer.BillingId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Ignore(customer => customer.Bills);
        });

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.Property(billing => billing.PriceRate)
                .HasPrecision(18, 2);

            entity.Property(billing => billing.TotalAmountDue)
                .HasPrecision(18, 2);

            entity.ToTable(table =>
            {
                table.HasCheckConstraint("CK_Billings_PriceRate_NonNegative", "[PriceRate] >= 0");
                table.HasCheckConstraint("CK_Billings_TotalAmountDue_NonNegative", "[TotalAmountDue] >= 0");
            });
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.Property(building => building.BuildingType)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(building => building.StreetName)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(building => building.StreetSuffix)
                .HasMaxLength(25)
                .IsRequired();

            entity.Property(building => building.CityName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(building => building.KingdomName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(building => building.ServiceArea)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(building => building.Latitude)
                .HasPrecision(9, 6);

            entity.Property(building => building.Longitude)
                .HasPrecision(9, 6);

            entity.ToTable(table =>
            {
                table.HasCheckConstraint("CK_Buildings_StreetNum_Positive", "[StreetNum] > 0");
                table.HasCheckConstraint("CK_Buildings_ZipCode_Range", "[ZipCode] >= 0 AND [ZipCode] <= 99999");
            });
        });

        modelBuilder.Entity<WaterMeter>(entity =>
        {
            entity.Property(waterMeter => waterMeter.MeterReading)
                .HasPrecision(18, 2);

            entity.ToTable(table =>
            {
                table.HasCheckConstraint("CK_WaterMeters_MeterReading_NonNegative", "[MeterReading] >= 0");
            });
        });

        modelBuilder.Entity<WaterTreatmentPlant>(entity =>
        {
            entity.Property(plant => plant.ServiceArea)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(plant => plant.Turbidity)
                .HasPrecision(8, 3);

            entity.ToTable(table =>
            {
                table.HasCheckConstraint("CK_WaterTreatmentPlants_WaterVolumeCapacity_Positive", "[WaterVolumeCapacity] > 0");
                table.HasCheckConstraint("CK_WaterTreatmentPlants_Turbidity_NonNegative", "[Turbidity] >= 0");
            });
        });
    }
}

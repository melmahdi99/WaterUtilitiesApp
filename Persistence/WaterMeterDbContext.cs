using System;
using Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence;

public class WaterMeterDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Building> Buildings { get; set; }
    public required DbSet<WaterMeter> WaterMeters { get; set; }
    public required DbSet<Billing> Billings { get; set; }
    public required DbSet<Customer> Customers { get; set; } 
    public required DbSet<WaterTreatmentPlant> WaterTreatmentPlants { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
        //base.OnModelCreating(modelBuilder);


        //primaru key
        // modelBuilder.Entity<WaterMeter>(entity =>
        // {
        //     entity.HasKey(e => e.Id);
        //     entity.Property(e => e.Id)
        //           .ValueGeneratedOnAdd()
        //           .HasDefaultValueSql("NEWID()");


            

        //     entity.Property(e => e.MeterReading)
        //           .HasColumnType("decimal(10,3)")
        //           .IsRequired()
        //           .HasDefaultValue(0m);



            // entity.Property(e => e.IsOnline).HasDefaultValue(false);


            //foreign key
            // entity.Property(e => e.BuildingId).IsRequired();



            // entity.HasOne<Building>()
            //       .WithMany() 
            //       .HasForeignKey(e => e.BuildingId)
            //       .OnDelete(DeleteBehavior.Restrict) // Stops SQL from deleting a Building if meters exist
            //       .HasConstraintName("FK_WaterMeters_Buildings");



            // modelBuilder.Entity<Building>(e =>
            // {
            //     e.HasKey(b => b.Id);
            //     e.Property(b => b.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
                
            // });




            // modelBuilder.Entity<Customer>(e =>
            // {
            //     e.HasKey(c => c.Id);
            //     e.Property(c => c.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
                
            // });




            // modelBuilder.Entity<Billing>(e =>
            // {
            //     e.HasKey(b => b.Id);
            //     e.Property(b => b.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            // });


            // modelBuilder.Entity<WaterTreatmentPlant>(e =>
            // {
            //     e.HasKey(p => p.Id);
            //     e.Property(p => p.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            // });
        //});


    //}

    



    



    





    

}

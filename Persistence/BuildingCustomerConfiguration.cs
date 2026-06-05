using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence;

public class BuildingCustomerConfiguration : IEntityTypeConfiguration<BuildingCustomer>
{
    public void Configure(EntityTypeBuilder<BuildingCustomer> builder)
    {
        // setting up the m:n relationship between Buildings and Customers
        builder.HasKey( bc => new { bc.BuildingId, bc.CustomerId });
    }
}
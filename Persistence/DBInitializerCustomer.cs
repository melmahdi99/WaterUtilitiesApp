using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public static class DBInitializerCustomer
{
    public static async Task InitializeAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();

        if (await context.Customers.AnyAsync())
        {
            return;
        }

        var billingId = Guid.NewGuid();

        context.Billings.Add(new Billing
        {
            Id = billingId,
            PriceRate = 0m,
            TotalAmountDue = 0m,
            DueDate = DateTime.UtcNow,
            TimePaid = DateTime.UtcNow,
            IsPaid = false,
            CustomerId = Guid.Empty,
            WaterMeterId = Guid.Empty
        });

        context.Customers.Add(new Customer
        {
            Id = Guid.NewGuid(),
            FName = "Gian",
            LName = "Customer",
            BillingId = billingId
        });

        await context.SaveChangesAsync();
    }
}

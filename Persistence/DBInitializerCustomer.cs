using Microsoft.EntityFrameworkCore;

namespace Persistence;

public static class DBInitializerCustomer
{
    public static async Task InitializeAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class BillingRepo_Impl : IBillingRepo
{
    private readonly AppDbContext _context;

    public BillingRepo_Impl(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Billing>> GetBillingsAsync()
    {
        var billings = await _context.Billings
        .AsNoTracking()
        .ToListAsync();
        return billings;
    }

    public async Task<Billing> GetBillingAsync(Guid id)
    {
        var billing = await _context.Billings.FindAsync(id);
        return billing!;
    }

    public async Task<Billing> CreateBilling(Billing billing)
    {
        _context.Billings.Add(billing);
        await _context.SaveChangesAsync();
        return billing;
    }

    public async Task UpdateBilling(Billing billing)
    {
        var b = await _context.Billings.FindAsync(billing.Id);
        b.TimePaid = billing.TimePaid; //this is the only field that would make sense to be updated in the billing entity
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBilling(Guid id)
    {
        await _context.Billings.Where(b => b.Id == id).ExecuteDeleteAsync();
    }
}
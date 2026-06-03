using Domain;

namespace Persistence;

public interface IBillingRepo
{
    //GET method for all plants
    public Task<IEnumerable<Billing>> GetBillingsAsync();

    //GET method for individual plant
    public Task<Billing> GetBillingAsync(Guid id);

    //POST method
    public Task<Billing> CreateBilling(Billing billing);

    //PUT method
    public Task UpdateBilling(Billing billing);

    //DELETE method
    public Task DeleteBilling(Guid id);

}
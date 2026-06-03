namespace Application;

public interface IBillingService
{
    public Task<IEnumerable<ReadBillingDto>> GetBillingsAsync();

    public Task<FullBillingDto> GetBillingAsync(Guid id);

    public Task<ReadBillingDto> CreateBilling(CreateBillingDto dto);

    public Task UpdateBilling(FullBillingDto dto);

    public Task DeleteBilling(Guid id);
}
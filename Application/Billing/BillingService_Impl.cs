using Persistence;
using Domain;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace Application;

public class BillingService_Impl : IBillingService
{
    private readonly IBillingRepo _repo;
    
    private readonly IMapper _mapper;

    private readonly IMemoryCache _cache;

    public BillingService_Impl(IBillingRepo repo, IMapper mapper, IMemoryCache cache)
    {
        _repo = repo;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<IEnumerable<ReadBillingDto>> GetBillingsAsync()
    {
        var billings = await _repo.GetBillingsAsync();

        var mappedBillings = billings
        .Select(a => _mapper.Map<ReadBillingDto>(a))
        .ToList();

        return mappedBillings;
    }

    public async Task<FullBillingDto?> GetBillingAsync(Guid id)
    {
        var billing = await _repo.GetBillingAsync(id);

        if (billing == null)
            return null;

        var mappedBilling = _mapper.Map<FullBillingDto> (billing);

        return mappedBilling;
    }

    public async Task<ReadBillingDto> CreateBilling(CreateBillingDto dto)
    {
        var entity = _mapper.Map<Billing>(dto);
        var created = await _repo.CreateBilling(entity);
        return _mapper.Map<ReadBillingDto>(created);
    }

    public async Task UpdateBilling(FullBillingDto billing)
    {
        var b = _mapper.Map<Billing>(billing);
        await _repo.UpdateBilling(b);
    }

    public async Task DeleteBilling(Guid id)
    {
        await _repo.DeleteBilling(id);
    }
}
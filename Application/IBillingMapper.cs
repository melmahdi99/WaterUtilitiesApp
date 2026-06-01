using Domain;

namespace Application;

public interface IBillingMapper
{
    public ReadBillingDto ToDto(Billing billing);

    public Billing ToEntity(CreateBillingDto dto);

}
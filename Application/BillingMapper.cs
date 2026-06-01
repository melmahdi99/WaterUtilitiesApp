using Domain;

namespace Application;

public class BillingMapper :IBillingMapper
{
    public ReadBillingDto ToDto(Billing billing)
    {
        if (billing == null) return null;

        return new ReadBillingDto
        {
          Id = billing.Id,
          PriceRate = billing.PriceRate,
          TotalAmountDue = billing.TotalAmountDue,
          DueDate = billing.DueDate,
          TimePaid = billing.TimePaid,
          IsPaid = billing.IsPaid,
          CustomerId = billing.CustomerId,
          WaterMeterId = billing.WaterMeterId  
        };
    }

    public Billing ToEntity(CreateBillingDto dto)
    {
        return new Billing
        {
          PriceRate = dto.PriceRate,
          TotalAmountDue = dto.TotalAmountDue,
          DueDate = dto.DueDate,
          TimePaid = dto.TimePaid,
          IsPaid = dto.IsPaid,
          CustomerId = dto.CustomerId,
          WaterMeterId = dto.WaterMeterId  
        };
    }
}
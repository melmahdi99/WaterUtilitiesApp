namespace Application;

public class FullBillingDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal PriceRate { get; set; }
    public decimal TotalAmountDue { get; set; }
    public DateOnly DueDate { get; set; }
    public DateTime TimePaid { get; set; }
    public bool IsPaid { get; set; }
    public Guid CustomerId { get; set; }
    public Guid WaterMeterId { get; set; }
}
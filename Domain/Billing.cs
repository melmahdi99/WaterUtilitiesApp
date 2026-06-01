using System;

namespace Domain;

public class Billing
{
    public Guid Id { get; set; }
    //This probably shouldn't be a property in here if it's already in the WaterMeter table
    // public decimal WaterMeterReading { get; set; }
    public decimal PriceRate { get; set; }
    public decimal TotalAmountDue { get; set; }
    public DateOnly DueDate { get; set; }
    public DateTime TimePaid { get; set; }
    public bool IsPaid { get; set; }

    //FKs
    public Guid CustomerId { get; set; }
    public Guid WaterMeterId { get; set; }
}

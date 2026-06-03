using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Billing
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    //This probably shouldn't be a property in here if it's already in the WaterMeter table
    [Column(TypeName="decimal(10,2)")]
    public decimal PriceRate { get; set; }
    [Column(TypeName="decimal(10,2)")]
    public decimal TotalAmountDue { get; set; }
    public DateOnly DueDate { get; set; }
    public DateTime TimePaid { get; set; }
    public bool IsPaid { get; set; }

    //FKs
    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }
    [ForeignKey(nameof(WaterMeter))]
    public Guid WaterMeterId { get; set; }
}

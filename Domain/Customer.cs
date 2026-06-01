using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Customer
{
    public Guid Id { get; set; }
    public required string FName { get; set; }
    public required string LName { get; set; }
    [ForeignKey(nameof(Billing))]
    public Guid BillingId { get; set; }
    public Billing? Billing { get; set; }
}
